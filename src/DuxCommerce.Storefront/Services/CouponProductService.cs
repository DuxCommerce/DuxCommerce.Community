using System.Linq;
using System.Threading.Tasks;
using DuxCommerce.StoreBuilder.Marketing.DataStores;
using DuxCommerce.Storefront.Views.Coupon.ViewModels;
using DuxCommerce.Storefront.Extensions;
using OrchardCore.ContentManagement;
using OrchardCore.Navigation;

namespace DuxCommerce.Storefront.Services;

public class CouponProductService(ProductService productService, ICouponStore couponStore)
{
    public async Task<CouponProducts> GetProducts(string couponId, Pager pager)
    {
        var coupon = await couponStore.Get(couponId);
        var productIds = coupon.GetPromotedProducts().ToList();

        var products = await productService.GetMany<ContentItem>(productIds)
            .Skip(pager.GetStartIndex())
            .Take(pager.PageSize)
            .ListAsync();

        var count = await productService.GetMany<ContentItem>(productIds)
            .CountAsync();

        return new CouponProducts
        {
            Coupon = coupon,
            Products = products,
            Count = count
        };
    }
}