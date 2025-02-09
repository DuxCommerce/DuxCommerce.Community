using DuxCommerce.StoreBuilder.Carts.DataTypes;

namespace DuxCommerce.OrchardCore.Checkout;

public static class OrderExtensions
{
    public static List<ItemTaxRow> Summarize(this IEnumerable<ItemTaxRow> taxes)
    {
        return taxes
            .GroupBy(rate => rate.Name)
            .Select(g => new ItemTaxRow { Name = g.Key, Amount = g.Sum(x => x.Amount) })
            .ToList();
    }
}