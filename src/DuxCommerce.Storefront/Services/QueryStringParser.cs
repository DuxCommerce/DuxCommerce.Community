using System;
using System.Threading.Tasks;
using DuxCommerce.StoreBuilder.Catalog.Requests;
using DuxCommerce.StoreBuilder.Catalog.SimpleTypes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using OrchardCore.DisplayManagement.ModelBinding;
using OrchardCore.Navigation;

namespace DuxCommerce.Storefront.Services;

public class QueryStringParser(IHttpContextAccessor contextAccessor, IUpdateModelAccessor modelAccessor)
{
    private const string SortOption = "sortoption";

    public ProductFilterOptions GetFilterOptions(string categoryId)
    {
        var filterOption = new ProductFilterOptions { CategoryId = categoryId };

        var querystring = contextAccessor.HttpContext?.Request.QueryString.Value;
        var queryValues = QueryHelpers.ParseQuery(querystring);

        if (!queryValues.TryGetValue(SortOption, out var value))
            return filterOption;

        if (Enum.TryParse<ProductSortOption>(value.ToString(), out var option))
            filterOption.SortOption = option;

        return filterOption;
    }

    public async Task<PagerParameters> ToPagerParameters()
    {
        var pagerParameters = new PagerParameters();
        await modelAccessor.ModelUpdater.TryUpdateModelAsync(pagerParameters);

        return pagerParameters;
    }

    public string GetUrlPath()
    {
        return contextAccessor.HttpContext?.Request.Path;
    }
}