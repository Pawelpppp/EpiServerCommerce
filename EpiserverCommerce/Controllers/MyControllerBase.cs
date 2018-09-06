using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CommerceTraining.SupportingClasses;
using EPiServer;
using EPiServer.Commerce.Catalog;
using EPiServer.Commerce.Catalog.ContentTypes;
using EPiServer.Core;
using EPiServer.Filters;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using EPiServer.Web.Routing;

namespace EpiserverCommerce.Controllers
{
    public class MyControllerBase<T> : ContentController<T> where T : CatalogContentBase
    {

        public readonly IContentLoader _contentLoader;
        public readonly UrlResolver UrlResolver;
        public readonly AssetUrlResolver AssetUrlResolver;
        public readonly ThumbnailUrlResolver _thumbnailUrlResolver;
        public List<NameAndUrls> nameAndUrls { get; }

        public MyControllerBase(IContentLoader contentLoader, UrlResolver urlResolver, AssetUrlResolver assetUrlResolver, ThumbnailUrlResolver thumbnailUrlResolver)
        {
            _contentLoader = contentLoader;
            UrlResolver = urlResolver;
            AssetUrlResolver = assetUrlResolver;
            _thumbnailUrlResolver = thumbnailUrlResolver;
        }

        public string GetDefaultAsset(EntryContentBase entryContentBase)
        {
            return AssetUrlResolver.GetAssetUrl(entryContentBase);
        }

        public string GetDefaultAsset(NodeContent nodeContent)
        {
            return AssetUrlResolver.GetAssetUrl(nodeContent);
        }

        public string GetNamedAsset(EntryContentBase entryContentBase, string str)
        {
            return _thumbnailUrlResolver.GetThumbnailUrl(entryContentBase, str);
        }
        public string GetNamedAsset(NodeContent nodeContent, string str)
        {
            return _thumbnailUrlResolver.GetThumbnailUrl(nodeContent, str);
        }

        public string GetUrl(ContentReference contentReference)
        {
            return UrlResolver.GetUrl(contentReference);
        }

        public List<NameAndUrls> GetNodes(ContentReference contentReference)
        {
            IEnumerable<IContent> asd = FilterForVisitor.Filter(_contentLoader.GetChildren<NodeContent>(contentReference));
            List<NameAndUrls> nameAndUrlsList = new List<NameAndUrls>();
            foreach (IContent item in asd)
            {
                var item2 = item as NodeContent;
                if (item2 != null)
                    nameAndUrlsList.Add(new NameAndUrls
                    {
                        name = item2.Name,
                        url = GetUrl(contentReference),
                        imageUrl = GetDefaultAsset(item2),
                        imageTumbUrl = GetNamedAsset(item2, "Thumbnail")
                    });
            }
            return nameAndUrlsList;
        }
        public List<NameAndUrls> GetEntries(ContentReference contentReference)
        {
            IEnumerable<IContent> asd = FilterForVisitor.Filter(_contentLoader.GetChildren<EntryContentBase>(contentReference));
            List<NameAndUrls> nameAndUrlsList = new List<NameAndUrls>();
            foreach (IContent item in asd)
            {
                var item2 = item as EntryContentBase;
                nameAndUrlsList.Add(new NameAndUrls
                {
                    name = item2.Name,
                    url = GetUrl(item2.ContentLink),
                    imageUrl = GetDefaultAsset(item2),
                    imageTumbUrl = GetNamedAsset(item2, "Thumbnail")
                });
            }
            return nameAndUrlsList;
        }
    }
}
