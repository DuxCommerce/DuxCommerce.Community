using System.Collections.Generic;
using System.Threading.Tasks;
using DuxCommerce.StoreBuilder.Settings.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DuxCommerce.Storefront.Controllers;

[Authorize]
[Route("Country")]
public class CountryController(StateUseCases stateUseCases) : Controller
{
    [HttpGet]
    [Route(nameof(CountryStates))]
    public async Task<JsonResult> CountryStates(string countryCode)
    {
        var model = await stateUseCases.GetStates(countryCode);
        return Json(model);
    }

    [HttpGet]
    [Route(nameof(CountriesStates))]
    public async Task<JsonResult> CountriesStates(IEnumerable<string> countryCodes)
    {
        var model = await stateUseCases.GetStates(countryCodes);
        return Json(new { Countries = model.Item1, States = model.Item2 });
    }
}