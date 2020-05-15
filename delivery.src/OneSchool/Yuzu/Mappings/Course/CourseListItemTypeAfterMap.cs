using System;
using System.Linq;
using System.Collections.Generic;
using YuzuDelivery.Umbraco.Core;
using YuzuDelivery.ViewModels;
using YuzuDelivery.UmbracoModels;

namespace OneSchool
{
    public class CourseListItemTypeAfterMap : IYuzuTypeAfterConvertor<Course, vmSub_CourseListItem>
    {
        public void Apply(Course source, vmSub_CourseListItem dest, UmbracoMappingContext context)
        {
            dest.Title = source.Name;
        }
    }
}