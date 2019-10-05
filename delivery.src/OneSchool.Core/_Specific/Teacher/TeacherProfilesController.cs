using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Web.WebApi;
using OneSchool.Core.ViewModels;
namespace OneSchool.Core
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
