using DuxCommerce.OrchardCore.Shared;
using DuxCommerce.StoreBuilder.Catalog.DataTypes;

namespace DuxCommerce.OrchardCore.Catalog.CustomerFields;

public class CustomerFieldsPart : DuxPart<CustomerFieldsRow>
{
    public sealed override CustomerFieldsRow Row { get; set; } = new();
}