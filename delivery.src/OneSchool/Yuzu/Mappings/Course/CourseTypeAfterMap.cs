using System;
using System.Linq;
using System.Collections.Generic;
using YuzuDelivery.Umbraco.Core;
using YuzuDelivery.ViewModels;
using YuzuDelivery.UmbracoModels;

namespace OneSchool
{
    public class CourseTypeAfterMap : IYuzuTypeAfterConvertor<Course, vmPage_Course>
    {
        public void Apply(Course source, vmPage_Course dest, UmbracoMappingContext context)
        {
            dest.Title.Title = source.TitleTitle;
            dest.Header.Title = source.HeaderTitle;
        }
    }
}