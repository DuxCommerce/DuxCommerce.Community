using DuxCommerce.OrchardCore.Shared;
using DuxCommerce.StoreBuilder.Orders.DataStores;
using DuxCommerce.StoreBuilder.Orders.DataTypes;
using DuxCommerce.StoreBuilder.Orders.Plugins;
using DuxCommerce.StoreBuilder.Orders.Requests;
using YesSql;
using IIdGenerator = OrchardCore.Entities.IIdGenerator;

namespace DuxCommerce.OrchardCore.Orders;

public class OrderStore(ISession session, IIdGenerator generator, IOrderNumberGenerator orderNumberGenerator)
    : PartStore(session, generator), IOrderStore
{
    public async Task<string> Create(OrderRow row)
    {
        row.OrderNumber = orderNumberGenerator.Generate();

        foreach (var payment in row.Payments)
            payment.Id = IdGenerator.GenerateUniqueId();

        foreach (var orderItem in row.Items)
            orderItem.Id = IdGenerator.GenerateUniqueId();
        
        return await base.Create<OrderPart, OrderRow>(row);
    }

    public async Task<OrderRow> Get(string id)
    {
        return await base.Get<OrderPart, OrderRow, OrderIndex>(id);
    }

    public async Task<OrderRow?> GetByPaymentReference(string reference)
    {
        var part = await Session
            .Query<OrderPart, OrderPaymentIndex>(x => x.PaymentReference == reference)
            .FirstOrDefaultAsync();

        return part?.Row;
    }

    public async Task<bool> Update(OrderRow row)
    {
        foreach (var payment in row.Payments.Where(x => string.IsNullOrEmpty(x.Id)))
            payment.Id = IdGenerator.GenerateUniqueId();
        
        foreach (var shipment in row.Shipments.Where(x => string.IsNullOrEmpty(x.Id)))
            shipment.Id = IdGenerator.GenerateUniqueId();

        return await base.Update<OrderPart, OrderRow, OrderIndex>(row);
    }

    public async Task<int> CountOrders(OrderSearchOptions options)
    {
        var query = Search(options);

        return await query.CountAsync();
    }

    public async Task<IEnumerable<OrderRow>> SearchOrders(OrderSearchOptions options, int startIndex, int pageSize)
    {
        var query = Search(options);

        var parts = await query.Skip(startIndex).Take(pageSize).ListAsync();

        return parts.Select(x => x.Row);
    }

    public async Task<IEnumerable<OrderRow>> GetCustomerOrders(string userId)
    {
        var parts = await Session.Query<OrderPart, OrderIndex>()
            .Where(x => x.UserId == userId)
            .OrderByDescending(x => x.CreatedAtUtc)
            .ListAsync();

        return parts.Select(x => x.Row);
    }

    private IQuery<OrderPart, OrderIndex> Search(OrderSearchOptions options)
    {
        var query = Session.Query<OrderPart, OrderIndex>();

        if (options.StartTime.HasValue)
            query = query.Where(x => x.CreatedAtUtc >= options.StartTime.Value);
        
        if (options.EndTime.HasValue)
            query = query.Where(x => x.CreatedAtUtc < options.EndTime.Value);

        if (!string.IsNullOrEmpty(options.EmailAddress))
            query = query.Where(x => x.UserId.Contains(options.EmailAddress));

        if (!string.IsNullOrEmpty(options.OrderStatus))
            query = query.Where(x => x.OrderStatus == options.OrderStatus);

        if (!string.IsNullOrEmpty(options.PaymentStatus))
            query = query.Where(x => x.PaymentStatus == options.PaymentStatus);

        if (!string.IsNullOrEmpty(options.ShippingStatus))
            query = query.Where(x => x.ShippingStatus == options.ShippingStatus);

        query = query.OrderByDescending(x => x.CreatedAtUtc);

        return query;
    }
}