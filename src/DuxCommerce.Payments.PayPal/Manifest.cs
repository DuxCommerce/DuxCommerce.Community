using OrchardCore.Modules.Manifest;

[assembly: Module(
    Name = "DuxCommerce.Payments.PayPal",
    Author = "DuxCommerce Team",
    Website = "https://DuxCommerce.com",
    Version = "1.1.0",
    Description = "PayPal payment method for DuxCommerce",
    Category = "Commerce",
    Dependencies =
    [
        "OrchardCore.ContentTypes",
        "OrchardCore.Admin"
    ]
)]
