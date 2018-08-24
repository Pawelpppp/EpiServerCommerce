﻿using EPiServer.Commerce.Catalog.ContentTypes;
using EPiServer.Commerce.Catalog.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using System.Net.Sockets;

namespace EpiserverCommerce.Models.Catalog
{
    [CatalogContentType(GUID = "612F6686-F528-42B0-AADF-DEDB059DAFCA", MetaClassName = "MyVariation ")]
    public class MyVariation : VariationContent
    {
        [CultureSpecific]
        [IncludeInDefaultSearch]
        [Searchable]
        [Tokenize]
        public virtual XhtmlString MainBody { get; set; }

        [IncludeInDefaultSearch]
        public virtual string Size { get; set; }

        [IncludeInDefaultSearch]
        public virtual string Color { get; set; }

        public virtual bool CanBeMonogrammed { get; set; }

        public virtual string ThematicTag { get; set; }


    }
}