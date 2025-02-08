using DuxCommerce.StoreBuilder.Catalog.Dto;
using DuxCommerce.StoreBuilder.Settings.DataTypes;

namespace DuxCommerce.Storefront.Views.Product.ViewModels;

public class ProductPricesVm
{
    public ProductPrices Prices { get; set; }
    public CurrencyRow Currency { get; set; }
}