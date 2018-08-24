using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Commerce.Catalog.ContentTypes;
using EPiServer.Commerce.Catalog.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;

namespace EpiserverCommerce.Models.Catalog
{
    [CatalogContentType(GUID = "ed9cdfde-5470-4314-b91f-3b9a6033a9b3", MetaClassName = "MyNode")]
    public class MyNode : NodeContent
    {
        [CultureSpecific]
        [IncludeInDefaultSearch]
        [Searchable]
        [Tokenize]
        //[Display(
        //    Name = "Name",
        //    GroupName = SystemTabNames.Content,
        //    Order = 10)]
        public virtual XhtmlString MainBody { get; set; }
    }
}