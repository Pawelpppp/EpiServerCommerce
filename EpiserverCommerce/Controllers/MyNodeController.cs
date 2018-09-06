using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Commerce.Catalog;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using EPiServer.Web.Routing;
using EpiserverCommerce.Models.Catalog;
using CommerceTraining.SupportingClasses;
using System;

namespace EpiserverCommerce.Controllers
{
    public class MyNodeController : MyControllerBase<MyNode>
    {
        public MyNodeController(IContentLoader contentLoader, UrlResolver urlResolver, AssetUrlResolver assetUrlResolver, ThumbnailUrlResolver thumbnailUrlResolver) : base(contentLoader, urlResolver, assetUrlResolver, thumbnailUrlResolver)
        {
        }

        public ActionResult Index(MyNode currentPage)
        {
            /* Implementation of action. You can create your own view model class that you pass to the view or
             * you can pass the page type for simpler templates */
            NodeEntryCombo nodeEntryCombo = new NodeEntryCombo();
            nodeEntryCombo.nodes = GetNodes(currentPage.ContentLink);
            nodeEntryCombo.entries = base.GetEntries(currentPage.ContentLink);
            return View(nodeEntryCombo);
        }
    }
}

