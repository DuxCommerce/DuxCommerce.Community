using DuxCommerce.Storefront.Views.StoreHome.ViewModels;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DuxCommerce.Storefront.Views.Category.ViewModels;

public class CategoryHome
{
    public CategoryMenuVm CategoryMenu { get; set; }
    public BreadCrumbsVm BreadCrumbs { get; set; }
    public SortOptionsVm SortOptions { get; set; }
    public ProductsVm Products { get; set; }
    [BindNever] public dynamic Pager { get; set; }
}