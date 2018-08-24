﻿using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;

namespace EpiserverCommerce.Models.Pages
{
    [ContentType(DisplayName = "StartPage", GUID = "f7ecc40d-77e8-414f-ae32-b25bfe6fd5bf", Description = "")]
    public class StartPage : PageData
    {
        /*
                [CultureSpecific]
                [Display(
                    Name = "Main body",
                    Description = "The main body will be shown in the main content area of the page, using the XHTML-editor you can insert for example text, images and tables.",
                    GroupName = SystemTabNames.Content,
                    Order = 1)]
                public virtual XhtmlString MainBody { get; set; }
         */
        [Display(
           Name = "Description",
           GroupName = SystemTabNames.Content,
           Order = 10)]
        public virtual XhtmlString Description { get; set; }
    }
}