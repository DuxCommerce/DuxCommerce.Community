using System.Collections.Generic;
using System.Threading.Tasks;
using DuxCommerce.OrchardCore.Customers;
using DuxCommerce.Storefront.Views.Product.VmBuilders;
using Microsoft.AspNetCore.Mvc;

namespace DuxCommerce.Storefront.Controllers;

[Route("Product")]
public class ProductController(ProductVariantBuilder productVariantBuilder, IShopperInfoProvider shopperInfoProvider)
    : Controller
{
    [HttpPost]
    [Route(nameof(Customize))]
    public async Task<JsonResult> Customize(string prototypeId, IEnumerable<string> choiceIds)
    {
        var userId = shopperInfoProvider.GetUserId();
        var variantModel = await productVariantBuilder.BuildVariantModel(userId, prototypeId, choiceIds);

        return Json(variantModel);
    }
}