using System.Text.Encodings.Web;
using DuxCommerce.StoreBuilder.Checkout.UseCases;
using OrchardCore.DisplayManagement;
using OrchardCore.Email;

namespace DuxCommerce.OrchardCore.Checkout;

public class OrderEmailSender(
    IEmailService emailService,
    IDisplayHelper displayHelper,
    HtmlEncoder htmlEncoder,
    OrderVmBuilder orderVmBuilder)
    : IOrderEmailSender
{
    public async Task ConfirmOrder(OrderEmailRequest request)
    {
        var orderVm = await orderVmBuilder.BuildCustomerOrder(request.Order);
        var viewModel = new OrderConfirmationVm { Order = orderVm, StoreProfile = request.StoreProfile };

        var mailMessage = new MailMessage
        {
            From = request.StoreProfile.SenderEmail,
            To = orderVm.Order.ShopperEmail,
            Subject = $"{request.StoreProfile.BusinessName} order #{request.Order.OrderNumber}"
        };

        await SendEmail(mailMessage, viewModel);
    }

    public async Task NotifyStoreAdmin(OrderEmailRequest request)
    {
        var orderDetails = await orderVmBuilder.BuildCustomerOrder(request.Order);
        var viewModel = new OrderNotificationVm { OrderVm = orderDetails, StoreProfile = request.StoreProfile };

        var mailMessage = new MailMessage
        {
            From = request.StoreProfile.SenderEmail,
            To = request.StoreProfile.SenderEmail,
            Subject = $"Your have a new order #{request.Order.OrderNumber}"
        };

        await SendEmail(mailMessage, viewModel);
    }

    private async Task SendEmail(MailMessage mailMessage, IShape viewModel)
    {
        await EnrichMessage(mailMessage, viewModel);

        var result = await emailService.SendAsync(mailMessage);

        ProcessEmailResult(result);
    }

    private async Task EnrichMessage(MailMessage mailMessage, IShape viewModel)
    {
        var htmlContent = await displayHelper.ShapeExecuteAsync(viewModel);

        string body;

        await using (var stringWriter = new StringWriter())
        {
            htmlContent.WriteTo(stringWriter, htmlEncoder);
            body = stringWriter.ToString();
        }

        mailMessage.Body = body;
        mailMessage.IsHtmlBody = true;
    }

    private void ProcessEmailResult(EmailResult result)
    {
        // Todo: handle unsuccessful delivery
    }
}