using EPiServer.Commerce.Catalog.ContentTypes;
using EPiServer.Commerce.Catalog.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Commerce.Catalog;
using System.Collections.Generic;
using EPiServer.Commerce.Catalog.Linking;
using EPiServer.ServiceLocation;

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

       // public virtual IEnumerable<MyVariation> ListOfVariation { get; set; }

        public void SetVariations(ContentReference referenceToProduct)
        {
            var relationRepository = ServiceLocator.Current.GetInstance<IRelationRepository>();
            var variations = relationRepository.GetChildren<ProductVariation>(referenceToProduct);
           // ListOfVariation = variations;
            //return variations;
        }
        
        

    }
}