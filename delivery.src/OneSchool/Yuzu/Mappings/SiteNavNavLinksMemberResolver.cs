using System;
using System.Linq;
using System.Collections.Generic;
using YuzuDelivery.Core;
using YuzuDelivery.Umbraco.Core;
using YuzuDelivery.UmbracoModels;
using YuzuDelivery.ViewModels;
using Umbraco.Web;

namespace OneSchool
{
    public class SiteNavNavLinksMemberResolver : IYuzuPropertyReplaceResolver<Home, List<vmBlock_DataLink>>
    {
        private readonly IMapper mapper;
        private readonly IPublishedContentQuery contentQuery;

        public SiteNavNavLinksMemberResolver(IMapper mapper, IPublishedContentQuery contentQuery)
        {
            this.mapper = mapper;
            this.contentQuery = contentQuery;
        }

        public List<vmBlock_DataLink> Resolve(Home source, UmbracoMappingContext context)
        {
            var root = contentQuery.ContentAtRoot().FirstOrDefault();
            var items = root.DescendantsOrSelf().Where(x => x.Level < 3);
            return mapper.Map<List<vmBlock_DataLink>>(items);
        }
    }
}