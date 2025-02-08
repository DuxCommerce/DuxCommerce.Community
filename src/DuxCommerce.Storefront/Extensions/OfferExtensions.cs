using DuxCommerce.StoreBuilder.Marketing.DataTypes;
using DuxCommerce.StoreBuilder.Marketing.Requests;

namespace DuxCommerce.Storefront.Extensions;

public static class OfferExtensions
{
    public static DiscountModel ToDiscountModel(this DiscountRow discountRow)
    {
        return discountRow != null
            ? new DiscountModel
            {
                Type = discountRow.Type,
                PercentOff = discountRow.PercentOff,
                AmountOff = discountRow.AmountOff
            }
            : null;
    }

    public static RuleModel ToRuleModel(this RuleRow ruleRow)
    {
        var productRule = ruleRow.Product != null
            ? new ProductRuleModel
            {
                Type = ruleRow.Product?.Type,
                Products = ruleRow.Product?.Products,
                Categories = ruleRow.Product?.Categories
            }
            : null;

        var miniRule = ruleRow.Min != null
            ? new MinRuleModel
            {
                Type = ruleRow.Min.Type,
                ItemQuantity = ruleRow.Min.ItemQuantity,
                PurchaseAmount = ruleRow.Min.PurchaseAmount
            }
            : null;

        var customerRule = ruleRow.Customer != null
            ? new CustomerRuleModel
            {
                Type = ruleRow.Customer.Type,
                Groups = ruleRow.Customer.Groups,
                Customers = ruleRow.Customer.Customers
            }
            : null;

        var countryRule = ruleRow.Country != null
            ? new CountryRuleModel
            {
                Type = ruleRow.Country?.Type,
                Countries = ruleRow.Country?.Countries
            }
            : null;

        var usageRule = ruleRow.Usage != null
            ? new UsageRuleModel
            {
                LimitStoreUsage = ruleRow.Usage.LimitStoreUsage,
                StoreLimit = ruleRow.Usage.StoreLimit,
                OneUsePerCustomer = ruleRow.Usage.OneUsePerCustomer
            }
            : null;

        var timeRule = ruleRow.Time != null
            ? new TimeRuleModel
            {
                StartTime = ruleRow.Time.StartTime,
                EndTime = ruleRow.Time.EndTime
            }
            : null;

        return new RuleModel
        {
            Product = productRule,
            Min = miniRule,
            Customer = customerRule,
            Country = countryRule,
            Usage = usageRule,
            Time = timeRule
        };
    }
}