using EpiserverCommerce.Models.Catalog;
using Mediachase.Commerce.Catalog.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpiserverCommerce.ViewModels
{
    public class FashionVariationViewModel
    {
        public MyVariation MainBody { get; set; }
        public string PriceString { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public string imageUrl { get; set; }
        public bool CanBeMonogrammed { get; set; }
        public Price DiscountPrice { get; set; }
    }
}