using System;
using System.Collections.Generic;
using System.Linq;
using DuxCommerce.OrchardCore.Catalog.Categories;
using DuxCommerce.StoreBuilder.Catalog.Core;
using DuxCommerce.StoreBuilder.Catalog.DataTypes;
using DuxCommerce.Storefront.Views.Shared.ViewModels;
using DuxCommerce.Storefront.Views.StoreHome.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using OrchardCore.ContentManagement;

namespace DuxCommerce.Storefront.Extensions;

public static class CategoryExtensions
{
    public static List<SelectListItem> ToAllListItems(this IEnumerable<IEnumerable<CategoryRow>> trails)
    {
        var listItems = trails.ToListItems();

        listItems.Insert(0, new SelectListItem("All", ""));

        return listItems;
    }

    public static List<SelectListItem> ToListItems(this IEnumerable<IEnumerable<CategoryRow>> categoryTrails,
        string selectedId = null)
    {
        var listItems = new List<SelectListItem>();

        foreach (var trail in categoryTrails)
        {
            // Exclude selected category
            if (selectedId != null && trail.Any(x => x.Id == selectedId))
                continue;

            var name = GetFriendlyName(trail);
            listItems.Add(new SelectListItem(name, trail.Last().Id));
        }

        return listItems;
    }

    public static string GetFriendlyName(this IEnumerable<CategoryRow> trail)
    {
        const string separator = " > ";

        var name = string.Empty;

        foreach (var category in trail)
        {
            if (name != string.Empty)
                name += separator;

            name += category.Name;
        }

        return name;
    }

    public static CategoryMenuVm ToMenuVm(this List<ContentItem> contentItems)
    {
        var itemMap = contentItems.ToDictionary(x => x.ContentItemId);

        var allCategories = contentItems.Select(x => (CategoryRow)x.As<CategoryPart>().Row);
        var (parents, childMap) = CategoryCore.splitCategories(allCategories);

        return new CategoryMenuVm
        {
            Parents = parents,
            ChildMap = childMap,
            CategoryMap = itemMap
        };
    }

    public static CategoriesVm ToFeaturedCategories(this List<ContentItem> contentItems)
    {
        var items = contentItems.Where(x =>
        {
            var categoryRow = (CategoryRow)x.As<CategoryPart>().Row;
            return categoryRow.Featured;
        }).ToList();

        var categoryRows = items.Select(x => (CategoryRow)x.As<CategoryPart>().Row);

        return new CategoriesVm
        {
            Categories = categoryRows,
            CategoryMap = items.ToDictionary(x => x.ContentItemId)
        };
    }

    public static IEnumerable<CategoryTrail> ToCategoryTrails(this IEnumerable<ContentItem> contentItems)
    {
        var categoryRows = contentItems.Select(x => (CategoryRow)x.As<CategoryPart>().Row);
        var trails = CategoryCore.getCategoryTrails(categoryRows);

        return trails.Select(trail =>
        {
            var categoryList = trail.ToList();
            return new CategoryTrail
            {
                FriendlyName = categoryList.GetFriendlyName(),
                CategoryId = categoryList.Last().Id,
                SortOrder = categoryList.First().SortOrder
            };
        });
    }
}