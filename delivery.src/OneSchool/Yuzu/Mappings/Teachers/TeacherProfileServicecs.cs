using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YuzuDelivery.Core;
using Umbraco.Web;
using YuzuDelivery.ViewModels;
using YuzuDelivery.UmbracoModels;
using Umbraco.Web.Composing;

namespace OneSchool
{
    public class TeacherProfilesService
    {
        protected IMapper mapper;

        public TeacherProfilesService(IMapper mapper, IPublishedContentQuery contentService)
        {
            this.mapper = mapper;
        }

        public vmBlock_TeacherProfiles GetProfiles(int page)
        {
            var pageSize = 3;
            var root = Current.UmbracoHelper.ContentQuery.ContentAtRoot().FirstOrDefault();
            var teachers = root.DescendantsOrSelf<Teacher>().Skip(page * pageSize).Take(pageSize);
            int pageCount = (int)Math.Ceiling((double)teachers.Count() / pageSize);

            return new vmBlock_TeacherProfiles()
            {
                Teachers = teachers.Select(x => mapper.Map<vmSub_TeacherProfilesTeacher>(x)).ToList(),
                NextPageEndpoint = (pageCount > page) ? string.Format("http://oneschool.hifi.agency/umbraco/api/teacher/getProfiles?page={0}", page + 1) : string.Empty
            };
        }

    }
}