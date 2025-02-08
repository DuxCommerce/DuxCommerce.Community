using System.Collections.Generic;
using DuxCommerce.OrchardCore.Catalog.Images;
using DuxCommerce.Storefront.Views.Shared.ViewModels;
using OrchardCore.ContentManagement;

namespace DuxCommerce.Storefront.Extensions;

public static class ImageExtensions
{
    public static ImageVm GetImage<TImagePart>(this IDictionary<string, ContentItem> itemMap, string contentItemId)
        where TImagePart : ImagePart
    {
        if (!itemMap.TryGetValue(contentItemId, out var contentItem))
            return DefaultImage();

        var imagePart = contentItem.As<TImagePart>();

        return ToImageVm(imagePart);
    }

    public static ImageVm GetImage<TImagePart>(this ContentItem contentItem) where TImagePart : ImagePart
    {
        var imagePart = contentItem.As<TImagePart>();

        return ToImageVm(imagePart);
    }

    private static ImageVm ToImageVm(ImagePart imagePart)
    {
        var media = imagePart.Image;

        return media.Paths.Length > 0
            ? new ImageVm { Path = media.Paths[0], Text = media.MediaTexts?[0] }
            : DefaultImage();
    }

    private static ImageVm DefaultImage()
    {
        return new ImageVm { Path = "NoImage.png", Text = "No Image" };
    }
}