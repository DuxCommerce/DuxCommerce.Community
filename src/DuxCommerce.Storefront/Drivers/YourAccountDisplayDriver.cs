using OrchardCore.DisplayManagement.Handlers;
using OrchardCore.DisplayManagement.Views;
using OrchardCore.Users.Models;

namespace DuxCommerce.Storefront.Drivers;

public class YourAccountDisplayDriver : DisplayDriver<UserMenu>
{
    public override IDisplayResult Display(UserMenu model, BuildDisplayContext context)
    {
        return View("YourAccount", model)
            .Location("Detail", "Content:1.2")
            .Differentiator("YourAccount");
    }
}