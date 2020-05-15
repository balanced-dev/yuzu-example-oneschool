using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Web.WebApi;
using YuzuDelivery.ViewModels;

namespace OneSchool
{
    public class TeacherController : UmbracoApiController
    {
        protected TeacherProfilesService svc;

        public TeacherController(TeacherProfilesService svc)
        {
            this.svc = svc;
        }

        public vmBlock_TeacherProfiles GetProfiles(int page)
        {
            return svc.GetProfiles(page);
        }
    }
}