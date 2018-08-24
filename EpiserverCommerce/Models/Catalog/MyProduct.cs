using EPiServer.Commerce.Catalog.ContentTypes;
using EPiServer.Commerce.Catalog.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using System;

namespace EpiserverCommerce.Models.Catalog
{
    [CatalogContentType(GUID = "9D50D14B-12BC-42E5-BDAB-AFBE1AAE7009", MetaClassName = "MyProduct ")]
    public class MyProduct : ProductContent
    {
        [CultureSpecific]
        [IncludeInDefaultSearch]
        [Searchable]
        [Tokenize]
        public virtual XhtmlString MainBody { get; set; }

        public virtual string ClothesType { get; set; }

        public virtual string Brand { get; set; }
    }
}