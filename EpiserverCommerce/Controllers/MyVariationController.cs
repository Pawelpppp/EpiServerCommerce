using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Commerce.Catalog;
using EPiServer.Commerce.Catalog.ContentTypes;
using EPiServer.Commerce.Catalog.Linking;
using EPiServer.Commerce.SpecializedProperties;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.ServiceLocation;
using EPiServer.Web.Mvc;
using EPiServer.Web.Routing;
using EpiserverCommerce.Models.Catalog;
using EpiserverCommerce.ViewModels;
using Mediachase.Commerce.Website.Helpers;

namespace EpiserverCommerce.Controllers
{
    public class MyVariationController : MyControllerBase<MyVariation>

    {
        private readonly ReadOnlyPricingLoader pricingLoader;
        public MyVariationController(IContentLoader contentLoader, UrlResolver urlResolver, AssetUrlResolver assetUrlResolver, ThumbnailUrlResolver thumbnailUrlResolver) : base(contentLoader, urlResolver, assetUrlResolver, thumbnailUrlResolver)
        {
            pricingLoader = ServiceLocator.Current.GetInstance<ReadOnlyPricingLoader>();
        }

        public ActionResult Index(MyVariation currentContent)
        {
            /* Implementation of action. You can create your own view model class that you pass to the view or
             * you can pass the page type for simpler templates */

            FashionVariationViewModel viewModel = new FashionVariationViewModel();

            viewModel.MainBody = currentContent;
            //var asd = DefaultPrice(currentContent.ContentLink, pricingLoader);
            //viewModel.PriceString = asd?.UnitPrice.ToString();
            viewModel.PriceString = "Cokolwiek";
            viewModel.name = currentContent.Name;
            // var produc = GetProductByVariant(currentContent.ContentLink);

            viewModel.url = GetUrl(currentContent.ContentLink);
            viewModel.imageUrl = GetDefaultAsset(currentContent);
            viewModel.CanBeMonogrammed = currentContent.CanBeMonogrammed;
            viewModel.DiscountPrice = StoreHelper.GetDiscountPrice(currentContent.LoadEntry());

            return View(viewModel);
        }
        public ActionResult AddToCard(FashionVariationViewModel viewModel)
        {
            return new EmptyResult();
        }

        private Price DefaultPrice(IEnumerable<ContentReference> variationLinks, ReadOnlyPricingLoader pricingLoader)
        {
            if (pricingLoader == null)
            {
                throw new ArgumentNullException(nameof(pricingLoader));
            }

            var maxPrice = new Price();

            foreach (var variationLink in variationLinks)
            {
                var defaultPrice = pricingLoader.GetDefaultPrice(variationLink);
                if (defaultPrice.UnitPrice.Amount > maxPrice.UnitPrice.Amount)
                {
                    maxPrice = defaultPrice;
                }
            }

            return maxPrice;
        }

        //public IEnumerable<ProductVariation> GetProductByVariant(ContentReference variation)
        //{
        //    var relationRepository = ServiceLocator.Current.GetInstance<IRelationRepository>();
        //    var products = relationRepository.GetParents<ProductVariation>(variation);
        //    return products;
        //}
        //public IEnumerable<ContentReference> ListParentProduct(EntryContentBase entryContent)
        //{
        //    var parentProductLinks = entryContent.GetParentProducts();
        //    return parentProductLinks;
        //}


    }
}