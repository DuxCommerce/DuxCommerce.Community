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
using DuxCommerce.Storefront.Views.Coupon.ViewModels;
using DuxCommerce.Storefront.Views.Shared.ViewModels;
using DuxCommerce.Storefront.Views.Shared.VmBuilders;
using DuxCommerce.Storefront.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;
using OrchardCore.ContentManagement;
using OrchardCore.DisplayManagement;
using OrchardCore.Navigation;
using TypeItem = DuxCommerce.Storefront.Views.Coupon.ViewModels.TypeItem;
using ViewModels_TypeItem = DuxCommerce.Storefront.Views.Coupon.ViewModels.TypeItem;

namespace DuxCommerce.Storefront.Views.Coupon.VmBuilders;

public class CouponVmBuilder(
    ICouponStore couponStore,
    ICategoryStore categoryStore,
    StoreProfileUseCases storeProfileUseCases,
    CategoryUseCases categoryUseCases,
    CurrencyUseCases currencyUseCases,
    CouponProductService couponProductService,
    ProductService productService,
    CategoryPickerVmBuilder categoryPickerVmBuilder,
    ProductSearchOptionsFactory searchOptionsFactory,
    IShapeFactory shapeFactory)
{
    private readonly dynamic _new = shapeFactory;

    public async Task<CouponIndexVm> BuildIndexModel()
    {
        var timeZone = await storeProfileUseCases.GetStoreTimeZone();
        var coupons = await couponStore.GetAll();

        return new CouponIndexVm { Coupons = coupons, TimeZone = timeZone };
    }

    public async Task<CouponVm> BuildCreateModel()
    {
        var timeZone = await storeProfileUseCases.GetStoreTimeZone();
        var model = new CouponVm { Coupon = CreateCoupon(), TimeZone = timeZone };

        PopulateStaticData(model);

        return model;
    }

    public async Task<CouponVm> BuildCreateModel(CouponVm model)
    {
        var timeZone = await storeProfileUseCases.GetStoreTimeZone();
        model.TimeZone = timeZone;

        PopulateStaticData(model);

        return model;
    }

    public async Task<CouponVm> BuildEditModel(string couponId)
    {
        var coupon = await couponStore.Get(couponId);
        var links = new CouponLinks { Coupon = coupon, General = true };
        var timeZone = await storeProfileUseCases.GetStoreTimeZone();

        var model = new CouponVm { Links = links, Coupon = ToCouponModel(coupon), TimeZone = timeZone };

        PopulateStaticData(model);

        return model;
    }

    public async Task<CouponVm> BuildEditModel(CouponVm model)
    {
        var timeZone = await storeProfileUseCases.GetStoreTimeZone();
        model.TimeZone = timeZone;

        PopulateStaticData(model);

        return model;
    }

    public async Task<CouponProductsVm> BuildProductsModel(string couponId, PagerParameters pagerParameters)
    {
        var currency = await currencyUseCases.GetCurrency();
        var pager = new Pager(pagerParameters, 10);

        var couponProducts = await couponProductService.GetProducts(couponId, pager);
        var pagerShape = (await _new.Pager(pager)).TotalItemCount(couponProducts.Count).RouteData(new RouteData());

        return new CouponProductsVm
        {
            Coupon = couponProducts.Coupon,
            Products = couponProducts.Products,
            Currency = currency,
            Links = new CouponLinks { Coupon = couponProducts.Coupon, Products = true },
            Pager = pagerShape
        };
    }

    public async Task<LinkProductsVm> BuildLinkProductsModel(string couponId, ProductSearchVm searchVm,
        PagerParameters pagerParams)
    {
        var currency = await currencyUseCases.GetCurrency();
        var coupon = await couponStore.Get(couponId);

        var searchOptions = await searchOptionsFactory.CreateSearchOptions(searchVm, coupon.GetPromotedProducts());

        var pager = new Pager(pagerParams, 10);
        var (count, products) = await productService.SearchProducts(searchOptions, pager);
        var pagerShape = (await _new.Pager(pager)).TotalItemCount(count).RouteData(new RouteData());

        var trails = await categoryUseCases.GetCategoryTrails();

        return new LinkProductsVm
        {
            Coupon = coupon,
            ProductSearch = new ProductSearchVm { Categories = trails.ToAllListItems() },
            ProductPicker = new ProductPickerVm { Products = products, Currency = currency, Pager = pagerShape }
        };
    }

    public async Task<CouponCategoriesVm> BuildCategoriesModel(string couponId)
    {
        var coupon = await couponStore.Get(couponId);
        var contentItems = (await categoryStore.GetAllItems<ContentItem>()).ToList();

        return new CouponCategoriesVm
        {
            Coupon = coupon,
            CategoryTrails = contentItems.ToCategoryTrails(),
            CategoryMap = contentItems.ToDictionary(x => x.ContentItemId),
            Links = new CouponLinks { Coupon = coupon, Categories = true }
        };
    }

    public async Task<LinkCategoriesVm> BuildLinkCategoriesModel(string couponId)
    {
        var coupon = await couponStore.Get(couponId);
        var categoryIds = coupon.GetPromotedCategories().ToList();

        var pickerVm = await categoryPickerVmBuilder.BuildModel(categoryIds);

        return new LinkCategoriesVm
        {
            Coupon = coupon,
            CategoryPicker = pickerVm
        };
    }

    private void PopulateStaticData(CouponVm model)
    {
        PopulateCouponTypes(model);

        PopulateDiscountTypes(model);

        PopulateProductRules(model);

        PopulateMinRules(model);

        PopulateCustomerRules(model);

        PopulateCountryRules(model);
    }

    private CouponModel ToCouponModel(CouponRow couponRow)
    {
        return new CouponModel
        {
            Id = couponRow.Id,
            Name = couponRow.Name,
            Code = couponRow.Code,
            Type = couponRow.Type,
            Discount = couponRow.Discount.ToDiscountModel(),
            Rule = couponRow.Rule.ToRuleModel(),
            Activated = couponRow.Activated
        };
    }

    private void PopulateCouponTypes(CouponVm model)
    {
        var types = new List<ViewModels_TypeItem>
        {
            new() { Type = nameof(ProductCoupon), Name = "Product coupon" },
            new() { Type = nameof(OrderCoupon), Name = "Order coupon" },
            new() { Type = nameof(ShippingCoupon), Name = "Shipping coupon" }
        };

        model.CouponTypes = types.Select(x => new SelectListItem(x.Name, x.Type));
    }

    private void PopulateDiscountTypes(CouponVm model)
    {
        var types = new List<ViewModels_TypeItem>
        {
            new() { Type = nameof(Discount.PercentOff), Name = "Percent off" },
            new() { Type = nameof(Discount.AmountOff), Name = "Amount off" }
        };

        model.DiscountTypes = types;
    }

    private void PopulateProductRules(CouponVm model)
    {
        var types = new List<ViewModels_TypeItem>
        {
            new() { Type = nameof(ProductRule.All), Name = "All products" },
            new() { Type = nameof(ProductRule.Products), Name = "Selected products" },
            new() { Type = nameof(ProductRule.Categories), Name = "Selected categories" }
        };

        model.ProductRules = types;
    }

    private void PopulateMinRules(CouponVm model)
    {
        var types = new List<ViewModels_TypeItem>
        {
            new() { Type = nameof(MinRule.NoRestriction), Name = "No minimum requirements" },
            new() { Type = nameof(MinRule.ItemQuantity), Name = "Minimum quantity of items" },
            new() { Type = nameof(MinRule.PurchaseAmount), Name = "Minimum purchase amount" }
        };

        model.MinRules = types;
    }

    private void PopulateCustomerRules(CouponVm model)
    {
        var types = new List<ViewModels_TypeItem>
        {
            new() { Type = nameof(CustomerRule.All), Name = "All customers" }

            // Todo: add this once customer group is implemented
            // new() { Type = nameof(CustomerRule.Groups), Name = "Selected customer groups" },

            // Todo: add this once customer search is implemented
            // new() { Type = nameof(CustomerRule.Customers), Name = "Selected customers" }
        };

        model.CustomerRules = types;
    }

    private void PopulateCountryRules(CouponVm model)
    {
        var types = new List<ViewModels_TypeItem>
        {
            new() { Type = nameof(CountryRule.All), Name = "All countries" }

            // Todo: add this back once country search is implemented
            // new() { Type = nameof(CountryRule.Countries), Name = "Selected countries" }
        };

        model.CountryRules = types;
    }

    private CouponModel CreateCoupon()
    {
        return new CouponModel
        {
            Type = nameof(ProductCoupon),
            Discount = new DiscountModel { Type = nameof(Discount.PercentOff) },
            Rule = new RuleModel
            {
                Product = new ProductRuleModel { Type = nameof(ProductRule.All) },
                Min = new MinRuleModel { Type = nameof(MinRule.NoRestriction) },
                Customer = new CustomerRuleModel { Type = nameof(CustomerRule.All) },
                Country = new CountryRuleModel { Type = nameof(CountryRule.All) },
                Usage = new UsageRuleModel(),
                Time = new TimeRuleModel { StartTime = DateTime.UtcNow, EndTime = DateTime.UtcNow }
            }
        };
    }
}