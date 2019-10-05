using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OneSchool.Core.ViewModels;
using OneSchool.Core.UmbracoModels;
using AutoMapper;
using YuzuDelivery.Umbraco.Grid;
using Skybrud.Umbraco.GridData;

namespace OneSchool.Core
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            RecognizePrefixes("Summary");
            CreateMap<Course, vmSub_CourseListItem>()
                .ForMember(x => x.Title, opt => opt.MapFrom(x => x.SummaryTitle));

            RecognizePrefixes("Header");
            CreateMap<Course, vmBlock_CourseTitle>()
                .ForMember(x => x.Title, opt => opt.MapFrom(x => x.BodyTitle))
                .ForMember(x => x.Schedule, opt => opt.MapFrom(x => x.BodySchedule));

            RecognizePrefixes("Hero");
            CreateMap<Course, vmBlock_PageHeader>(); ;

            CreateMap<Course, vmPage_Course>()
                .ForMember(x => x.Content, opt => opt.MapFrom<GridRowColumnConvertor<Course, vmPage_Course>, GridDataModel>(y => y.Content))
                .ForMember(x => x.Title, opt => opt.MapFrom(x => x))
                .ForMember(x => x.Header, opt => opt.MapFrom(x => x));
        }

    }
}
