using DuxCommerce.StoreBuilder.SimpleTypes;
using OrchardCore.Navigation;

namespace DuxCommerce.Storefront.Extensions;

public static class PagerExtensions
{
    public static Pagination ToPagination(this Pager pager)
    {
        return new Pagination(pager.GetStartIndex(), pager.PageSize);
    }
}