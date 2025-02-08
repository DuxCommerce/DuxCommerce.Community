namespace DuxCommerce.Storefront.Views.Product.ViewModels;

public class ProductVariantVm
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Sku { get; set; }
    public string PriceIncTax { get; set; }
    public string PriceExcTax { get; set; }
    public string Summary { get; set; }
    public string Description { get; set; }
    public bool IsPurchasable { get; set; }
    public string[] Images { get; set; }
}