using System.Threading.Tasks;
using DuxCommerce.StoreBuilder.Catalog.Requests;
using DuxCommerce.Storefront.Views.StoreHome.ViewModels;
using DuxCommerce.Storefront.Views.StoreHome.VmBuilders;
using Microsoft.AspNetCore.Mvc;
using OrchardCore.DisplayManagement;
using OrchardCore.DisplayManagement.ModelBinding;
using OrchardCore.Navigation;

namespace DuxCommerce.Storefront.Controllers;

public class StoreHomeController(
    StoreHomeBuilder storeHomeVmBuilder,
    IDisplayManager<StoreHome> storeHomeDisplayManager,
    IUpdateModelAccessor updateModelAccessor)
    : Controller
{
    [Route("/")]
    public async Task<IActionResult> Index(ProductFilterOptions filterOptions, PagerParameters pagerParameters)
    {
        var model = await storeHomeVmBuilder.BuildIndexModel();

        var shape = await storeHomeDisplayManager.BuildDisplayAsync(model, updateModelAccessor.ModelUpdater);

        return View(shape);
    }
}