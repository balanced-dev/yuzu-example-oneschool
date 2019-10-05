using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OneSchool.Core.ViewModels;
using OneSchool.Core.UmbracoModels;
using AutoMapper;
using Umbraco.Web;

namespace OneSchool.Core
{
    public class TeacherProfilesService
    {
        protected IMapper mapper;
        private readonly IPublishedContentQuery contentService;

        public TeacherProfilesService(IMapper mapper, IPublishedContentQuery contentService)
        {
            this.mapper = mapper;
            this.contentService = contentService;
        }

        public vmBlock_TeacherProfiles GetProfiles(int page)
        {
            var pageSize = 3;
            var teachers = contentService.ContentAtRoot().FirstOrDefault().DescendantsOrSelf<Teacher>().Skip(page * pageSize).Take(pageSize);
            int pageCount = (int)Math.Ceiling((double)teachers.Count() / pageSize);

            return new vmBlock_TeacherProfiles()
            {
                Teachers = teachers.Select(x => mapper.Map<vmSub_TeacherProfilesTeacher>(x)).ToList(),
                NextPageEndpoint = (pageCount > page) ? string.Format("http://oneschool.hifi.agency/umbraco/api/teacher/getProfiles?page={0}", page + 1) : string.Empty
            };
        }

    }
}
