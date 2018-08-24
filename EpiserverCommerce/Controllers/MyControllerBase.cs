using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Commerce.Catalog;
using EPiServer.Commerce.Catalog.ContentTypes;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using EPiServer.Web.Routing;

namespace EpiserverCommerce.Controllers
{
    public class MyControllerBase<T> : ContentController<T> where T : CatalogContentBase
    {

        private  IContentLoader ContentLoader { get; set; }
        public UrlResolver UrlResolver { get; }
        public AssetUrlResolver AssetUrlResolver { get; }
        public ThumbnailUrlResolver ThumbnailUrlResolver { get; }

        public MyControllerBase(IContentLoader contentLoader, UrlResolver urlResolver, AssetUrlResolver assetUrlResolver, ThumbnailUrlResolver thumbnailUrlResolver)
        {
            ContentLoader = contentLoader;
            UrlResolver = urlResolver;
            AssetUrlResolver = assetUrlResolver;
            ThumbnailUrlResolver = thumbnailUrlResolver;
        }

    }
}