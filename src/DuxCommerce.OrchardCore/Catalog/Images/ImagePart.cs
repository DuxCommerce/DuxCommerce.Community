using OrchardCore.ContentManagement;
using OrchardCore.Media.Fields;

namespace DuxCommerce.OrchardCore.Catalog.Images;

public class ImagePart : ContentPart
{
    public MediaField Image { get; set; }
}