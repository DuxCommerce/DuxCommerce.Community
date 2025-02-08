using System.Threading.Tasks;
using DuxCommerce.OrchardCore;
using DuxCommerce.Storefront.Views.ProductField.VmBuilders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrchardCore.Admin;

namespace DuxCommerce.Storefront.Controllers;

[Admin]
[Route("Admin/ProductField")]
public class ProductFieldController(
    ProductFieldBuilder productFieldBuilder,
    IAuthorizationService authorizationService)
    : Controller
{
    [Route(nameof(Index))]
    public async Task<IActionResult> Index(string productId)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageProducts))
            return Forbid();

        var model = await productFieldBuilder.BuildIndexModel(productId);

        return View(model);
    }
}