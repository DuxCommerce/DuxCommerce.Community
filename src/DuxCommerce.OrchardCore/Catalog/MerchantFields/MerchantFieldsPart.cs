using DuxCommerce.OrchardCore.Shared;
using DuxCommerce.StoreBuilder.Catalog.DataTypes;

namespace DuxCommerce.OrchardCore.Catalog.MerchantFields;

public class MerchantFieldsPart : DuxPart<MerchantFieldsRow>
{
    public sealed override MerchantFieldsRow Row { get; set; } = new();
}