using EPiServer.Core;
using EPiServer.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpiserverCommerce.Models.Media
{
    [ContentType(GUID = "474CE40A-27CA-4780-A111-2BC887C68899")]
    public class ImageFile : ImageData
    {
        public virtual string Description { get; set; }
    }
}