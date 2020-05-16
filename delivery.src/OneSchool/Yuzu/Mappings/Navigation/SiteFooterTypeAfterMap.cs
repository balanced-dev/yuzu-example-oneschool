using System;
using System.Linq;
using System.Collections.Generic;
using YuzuDelivery.Umbraco.Core;
using YuzuDelivery.ViewModels;
using YuzuDelivery.UmbracoModels;

namespace OneSchool
{
    public class SiteFooterTypeAfterMap : IYuzuTypeAfterConvertor<Home, vmBlock_SiteFooter>
    {
        public void Apply(Home source, vmBlock_SiteFooter dest, UmbracoMappingContext context)
        {
            dest.LinkSection.Title = source.LinkSectionTitle;

            dest.NewsletterSection.Title = source.NewsletterSectionTitle;
            dest.NewsletterSection.Text = source.NewsletterSectionText;
        }
    }
}