using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OneSchool.Core.ViewModels;
using OneSchool.Core.UmbracoModels;
using AutoMapper;

namespace OneSchool.Core
{
    public class TeacherProfile : Profile
    {
        public TeacherProfile()
        {
            CreateMap<Teacher, vmBlock_CourseTeacher>();
            CreateMap<Teacher, vmSub_TeacherProfilesTeacher>();
        }

    }
}
