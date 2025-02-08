using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DuxCommerce.Storefront.Views.Category.ViewModels;

public class CategoryPagerVm
{
    [BindNever] public dynamic Pager { get; set; }
}