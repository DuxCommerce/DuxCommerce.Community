using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DuxCommerce.StoreBuilder.Catalog.DataStores;
using DuxCommerce.StoreBuilder.Catalog.UseCases;
using DuxCommerce.StoreBuilder.Marketing.DataStores;
using DuxCommerce.StoreBuilder.Marketing.DataTypes;
using DuxCommerce.StoreBuilder.Marketing.DomainTypes;
using DuxCommerce.StoreBuilder.Marketing.Requests;
using DuxCommerce.StoreBuilder.Settings.UseCases;
using DuxCommerce.StoreBuilder.Shipping.UseCases;
using DuxCommerce.Storefront.Services;
using DuxCommerce.Storefront.Views.Promotion.ViewModels;
using DuxCommerce.Storefront.Views.Shared.ViewModels;
using DuxCommerce.Storefront.Views.Shared.VmBuilders;
using DuxCommerce.Storefront.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;
using OrchardCore.ContentManagement;
using OrchardCore.DisplayManagement;
using OrchardCore.Navigation;

namespace DuxCommerce.Storefront.Views.Promotion.VmBuilders;

public class PromotionVmBuilder(
    IPromotionStore promotionStore,
    ICategoryStore categoryStore,
    StoreProfileUseCases storeProfileUseCases,
    CurrencyUseCases currencyUseCases,
    CategoryUseCases categoryUseCases,
    PromotionProductService promotionProductService,
    ProductService productService,
    CategoryPickerVmBuilder categoryPickerVmBuilder,
    ProductSearchOptionsFactory searchOptionsFactory,
    IShapeFactory shapeFactory)
{
    private readonly dynamic _new = shapeFactory;

    public async Task<PromotionIndexVm> BuildIndexModel()
    {
        var timeZone = await storeProfileUseCases.GetStoreTimeZone();
        var promotions = await promotionStore.GetAll();

        return new PromotionIndexVm { Promotions = promotions, TimeZone = timeZone };
    }

    public async Task<PromotionVm> BuildCreateModel()
    {
        var timeZone = await storeProfileUseCases.GetStoreTimeZone();
        var model = new PromotionVm { Promotion = CreatePromotion(), TimeZone = timeZone };

        EnrichPromotion(model);

        return model;
    }

    public async Task<PromotionVm> BuildCreateModel(PromotionVm model)
    {
        var timeZone = await storeProfileUseCases.GetStoreTimeZone();
        model.TimeZone = timeZone;

        EnrichPromotion(model);

        return model;
    }

    public async Task<PromotionVm> BuildEditModel(string promotionId)
    {
        var promotion = await promotionStore.Get(promotionId);
        var links = new PromotionLinks { Promotion = promotion, General = true };
        var timeZone = await storeProfileUseCases.GetStoreTimeZone();

        var model = new PromotionVm { Links = links, Promotion = ToPromotionModel(promotion), TimeZone = timeZone };

        EnrichPromotion(model);

        return model;
    }

    public async Task<PromotionVm> BuildEditModel(PromotionVm model)
    {
        var timeZone = await storeProfileUseCases.GetStoreTimeZone();
        model.TimeZone = timeZone;

        EnrichPromotion(model);

        return model;
    }

    public async Task<PromotionProductsVm> BuildProductsModel(string promotionId, PagerParameters pagerParameters)
    {
        var currency = await currencyUseCases.GetCurrency();
        var pager = new Pager(pagerParameters, 10);

        var promotionProducts = await promotionProductService.GetProducts(promotionId, pager);
        var pagerShape = (await _new.Pager(pager)).TotalItemCount(promotionProducts.Count).RouteData(new RouteData());

        return new PromotionProductsVm
        {
            Promotion = promotionProducts.Promotion,
            Products = promotionProducts.Products,
            Currency = currency,
            Links = new PromotionLinks { Promotion = promotionProducts.Promotion, Products = true },
            Pager = pagerShape
        };
    }

    public async Task<LinkProductsVm> BuildLinkProductsModel(string promotionId, ProductSearchVm searchVm,
        PagerParameters pagerParams)
    {
        var currency = await currencyUseCases.GetCurrency();
        var promotion = await promotionStore.Get(promotionId);

        var searchOptions = await searchOptionsFactory.CreateSearchOptions(searchVm, promotion.GetPromotedProducts());

        var pager = new Pager(pagerParams, 10);
        var (count, products) = await productService.SearchProducts(searchOptions, pager);
        var pagerShape = (await _new.Pager(pager)).TotalItemCount(count).RouteData(new RouteData());

        var trails = await categoryUseCases.GetCategoryTrails();

        return new LinkProductsVm
        {
            Promotion = promotion,
            ProductSearch = new ProductSearchVm { Categories = trails.ToAllListItems() },
            ProductPicker = new ProductPickerVm { Products = products, Currency = currency, Pager = pagerShape }
        };
    }

    public async Task<PromotionCategoriesVm> BuildCategoriesModel(string promotionId)
    {
        var promotion = await promotionStore.Get(promotionId);
        var contentItems = (await categoryStore.GetAllItems<ContentItem>()).ToList();

        return new PromotionCategoriesVm
        {
            Promotion = promotion,
            CategoryTrails = contentItems.ToCategoryTrails(),
            CategoryMap = contentItems.ToDictionary(x => x.ContentItemId),
            Links = new PromotionLinks { Promotion = promotion, Categories = true }
        };
    }

    public async Task<LinkCategoriesVm> BuildLinkCategoriesModel(string promotionId)
    {
        var promotion = await promotionStore.Get(promotionId);
        var categoryIds = promotion.GetPromotedCategories().ToList();

        var pickerVm = await categoryPickerVmBuilder.BuildModel(categoryIds);

        return new LinkCategoriesVm
        {
            Promotion = promotion,
            CategoryPicker = pickerVm
        };
    }

    private void EnrichPromotion(PromotionVm model)
    {
        PopulatePromotionTypes(model);

        PopulateDiscountTypes(model);

        PopulateProductRules(model);

        PopulateMinRules(model);

        PopulateCustomerRules(model);

        PopulateCountryRules(model);
    }

    private PromotionModel ToPromotionModel(PromotionRow promotionRow)
    {
        return new PromotionModel
        {
            Id = promotionRow.Id,
            Name = promotionRow.Name,
            Type = promotionRow.Type,
            Discount = promotionRow.Discount.ToDiscountModel(),
            Rule = promotionRow.Rule.ToRuleModel(),
            Activated = promotionRow.Activated,
            StopAfter = promotionRow.StopAfter,
            Priority = promotionRow.Priority
        };
    }

    private void PopulatePromotionTypes(PromotionVm model)
    {
        var types = new List<TypeItem>
        {
            new() { Type = nameof(ProductPromotion), Name = "Product promotion" },
            new() { Type = nameof(OrderPromotion), Name = "Order promotion" },
            new() { Type = nameof(ShippingPromotion), Name = "Shipping promotion" }
        };

        model.PromotionTypes = types.Select(x => new SelectListItem(x.Name, x.Type));
    }

    private void PopulateDiscountTypes(PromotionVm model)
    {
        var types = new List<TypeItem>
        {
            new() { Type = nameof(Discount.PercentOff), Name = "Percent off" },
            new() { Type = nameof(Discount.AmountOff), Name = "Amount off" }
        };

        model.DiscountTypes = types;
    }

    private void PopulateProductRules(PromotionVm model)
    {
        var types = new List<TypeItem>
        {
            new() { Type = nameof(ProductRule.All), Name = "All products" },
            new() { Type = nameof(ProductRule.Products), Name = "Selected products" },
            new() { Type = nameof(ProductRule.Categories), Name = "Selected categories" }
        };

        model.ProductRules = types;
    }

    private void PopulateMinRules(PromotionVm model)
    {
        var types = new List<TypeItem>
        {
            new() { Type = nameof(MinRule.NoRestriction), Name = "No minimum requirements" },
            new() { Type = nameof(MinRule.ItemQuantity), Name = "Minimum quantity of items" },
            new() { Type = nameof(MinRule.PurchaseAmount), Name = "Minimum purchase amount" }
        };

        model.MinRules = types;
    }

    private void PopulateCustomerRules(PromotionVm model)
    {
        var types = new List<TypeItem>
        {
            new() { Type = nameof(CustomerRule.All), Name = "All customers" }

            // Todo: add this once customer search is implemented
            // new() { Type = nameof(CustomerRule.Customers), Name = "Selected customers" }

            // Todo: add this once customer group is implemented
            // new() { Type = nameof(CustomerRule.Groups), Name = "Selected customer groups" },
        };

        model.CustomerRules = types;
    }

    private void PopulateCountryRules(PromotionVm model)
    {
        var types = new List<TypeItem>
        {
            new() { Type = nameof(CountryRule.All), Name = "All countries" }

            // Todo: add this back once country search is implemented
            // new() { Type = nameof(CountryRule.Countries), Name = "Selected countries" }
        };

        model.CountryRules = types;
    }

    private PromotionModel CreatePromotion()
    {
        return new PromotionModel
        {
            Type = nameof(ProductPromotion),
            Discount = new DiscountModel { Type = nameof(Discount.PercentOff) },
            Rule = new RuleModel
            {
                Product = new ProductRuleModel { Type = nameof(ProductRule.All) },
                Min = new MinRuleModel { Type = nameof(MinRule.NoRestriction) },
                Customer = new CustomerRuleModel { Type = nameof(CustomerRule.All) },
                Country = new CountryRuleModel { Type = nameof(CountryRule.All) },
                Usage = new UsageRuleModel(),
                Time = new TimeRuleModel { StartTime = DateTime.Now, EndTime = DateTime.Now.AddDays(1) }
            },
            Activated = true
        };
    }
}