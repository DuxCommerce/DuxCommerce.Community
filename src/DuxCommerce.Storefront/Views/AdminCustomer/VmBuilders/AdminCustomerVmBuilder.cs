using System.Linq;
using System.Threading.Tasks;
using DuxCommerce.StoreBuilder.Customers.DataStores;
using DuxCommerce.StoreBuilder.Customers.DataTypes;
using DuxCommerce.StoreBuilder.Customers.Requests;
using DuxCommerce.StoreBuilder.Orders.UseCases;
using DuxCommerce.StoreBuilder.Shipping.UseCases;
using DuxCommerce.Storefront.Builders;
using DuxCommerce.Storefront.Views.AdminCustomer.ViewModels;

namespace DuxCommerce.Storefront.Views.AdminCustomer.VmBuilders;

public class AdminCustomerVmBuilder(
    OrderUseCases orderUseCases,
    ICustomerStore customerStore,
    StoreProfileUseCases storeProfileUseCases,
    OrdersVmBuilder ordersVmBuilder)
{
    public async Task<CustomersVm> BuildIndexModel()
    {
        var timeZone = await storeProfileUseCases.GetStoreTimeZone();
        var customers = await customerStore.GetAll();

        return new CustomersVm { Customers = customers.ToList(), TimeZone = timeZone };
    }

    public async Task<EditCustomerVm> BuildEditModel(string id)
    {
        var customer = await customerStore.Get(id);

        var customerModel = ToEditModel(customer);

        var links = new CustomerLinks { CustomerId = customer.Id, DetailsLink = true };

        return new EditCustomerVm { CustomerModel = customerModel, Links = links };
    }

    public EditCustomerVm BuildEditModel(EditCustomerVm model)
    {
        model.Links = new CustomerLinks { CustomerId = model.CustomerModel.Id, DetailsLink = true };

        return model;
    }

    public async Task<AdminCustomerVm> BuildViewModel(string customerId)
    {
        var customer = await customerStore.Get(customerId);
        var links = new CustomerLinks { CustomerId = customer.Id, AddressLink = true };

        return new AdminCustomerVm
        {
            Links = links,
            Customer = customer
        };
    }

    public async Task<CustomerOrdersVm> BuildOrdersModel(string customerId)
    {
        var timeZone = await storeProfileUseCases.GetStoreTimeZone();
        var orders = await orderUseCases.GetCustomerOrders(customerId);

        var ordersVm = await ordersVmBuilder.BuildViewModel(orders.ToList(), timeZone);

        return new CustomerOrdersVm
        {
            Links = new CustomerLinks { CustomerId = customerId, OrdersLink = true },
            OrdersVm = ordersVm
        };
    }

    private CustomerModel ToEditModel(CustomerRow customer)
    {
        return new CustomerModel
        {
            Id = customer.Id,
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            PhoneNumber = customer.PhoneNumber
        };
    }
}