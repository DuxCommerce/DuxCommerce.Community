using OrchardCore.Modules.Manifest;

[assembly: Module(
    Name = "DuxCommerce.Payments.Stripe",
    Author = "DuxCommerce Team",
    Website = "https://DuxCommerce.com",
    Version = "1.0.0",
    Description = "Stripe payment method for DuxCommerce",
    Category = "Commerce",
    Dependencies =
    [
        "OrchardCore.ContentTypes",
        "OrchardCore.Admin"
    ]
)]
