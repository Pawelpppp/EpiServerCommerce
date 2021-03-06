﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Commerce.Catalog;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.ServiceLocation;
using EPiServer.Web.Mvc;
using EPiServer.Web.Routing;
using EpiserverCommerce.Models.Catalog;
using EPiServer.Commerce.Catalog.Linking;

namespace EpiserverCommerce.Controllers
{
    public class MyProductController : MyControllerBase<MyProduct>
    {
        public MyProductController(IContentLoader contentLoader, UrlResolver urlResolver, AssetUrlResolver assetUrlResolver, ThumbnailUrlResolver thumbnailUrlResolver) : base(contentLoader, urlResolver, assetUrlResolver, thumbnailUrlResolver)
        {
        }

        public ActionResult Index(MyProduct currentContent)
        {
            /* Implementation of action. You can create your own view model class that you pass to the view or
             * you can pass the page type for simpler templates */
            currentContent.SetVariations(currentContent.ContentLink);
            return View(currentContent);
        }

    }
}