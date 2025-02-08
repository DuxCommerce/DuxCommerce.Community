using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using DuxCommerce.Storefront.Views.StoreProfile.ViewModels;
using Microsoft.AspNetCore.Mvc;
using OrchardCore.Admin;

namespace DuxCommerce.Storefront.Controllers;

[Admin]
[Route("Admin/UnitSystem")]
public class UnitSystemController : Controller
{
    [HttpGet]
    [Route(nameof(Units))]
    public JsonResult Units(string systemId)
    {
        var systems = new List<UnitSystemVm> { new ImperialSystemVm(), new MetricSystemVm() };
        var system = systems.Single(x => x.SystemId == systemId);

        dynamic model = new ExpandoObject();
        model.WeightUnits = system.GetWeightUnits();
        model.LengthUnits = system.GetLengthUnits();

        return Json(model);
    }
}