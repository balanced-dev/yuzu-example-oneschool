using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using OneSchool.Core.ViewModels;
using OneSchool.Core.UmbracoModels;
using YuzuDelivery.Umbraco.Blocks;
using System.Web.Mvc;

namespace OneSchool.Core
{
    public class CommentsProfile : Profile
    {

        public CommentsProfile()
        {
            CreateMap<Comments, vmBlock_Comments>()
                .ForMember(x => x.Endpoints, opt => opt.MapFrom<CommentsEndpointResolver>())
                .ForMember(x => x.CommentList, opt => opt.MapFrom<CommentResolver>());

            CreateMap<Comment, vmSub_CommentListItem>()
                .ForMember(x => x.Headshot, opt => opt.MapFrom(x => new vmBlock_DataImage() { Src = x.HeaderShotUrl }))
                .ForMember(x => x.Timestamp, opt => opt.MapFrom(x => x.TimeStamp.ToString("dd/MM/yyy")))
                .ForMember(x => x.Comment, opt => opt.MapFrom(x => x.Message));


            CreateMap<List<Comment>, vmBlock_CommentList>()
                .ForMember(x => x.Items, opt => opt.MapFrom<CommenListItemtResolver>())
                .ForMember(x => x.Title, opt => opt.MapFrom(comments => comments.Count == 1 ? "1 Comment" : string.Format("{0} Comments", comments.Count)));
        }

    }

    public class CommenListItemtResolver : IValueResolver<List<Comment>, vmBlock_CommentList, List<vmSub_CommentListItem>>
    {
        public List<vmSub_CommentListItem> Resolve(List<Comment> source, vmBlock_CommentList destination, List<vmSub_CommentListItem> destMember, ResolutionContext context)
        {
            var mapper = DependencyResolver.Current.GetService<IMapper>();

            return mapper.Map<List<vmSub_CommentListItem>>(source);
        }
    }

    public class CommentsEndpointResolver : IValueResolver<Comments, vmBlock_Comments, vmSub_CommentsEndpoints>
    {
        public vmSub_CommentsEndpoints Resolve(Comments source, vmBlock_Comments destination, vmSub_CommentsEndpoints destMember, ResolutionContext context)
        {
            var model = context.Items["Model"] as Course;

            return new vmSub_CommentsEndpoints()
            {
                CommentForm = "?alttemplate=commentsform",
                CommentList = string.Format("/umbraco/surface/comments/get?courseId={0}", model.Id) 
            };
        }
    }

    public class CommentResolver : IValueResolver<Comments, vmBlock_Comments, vmBlock_CommentList>
    {
        public vmBlock_CommentList Resolve(Comments source, vmBlock_Comments destination, vmBlock_CommentList destMember, ResolutionContext context)
        {
            var model = context.Items["Model"] as Course;
            var cRepo = DependencyResolver.Current.GetService<CommentsRepository>();
            var mapper = DependencyResolver.Current.GetService<IMapper>();
            var comments = cRepo.List(model.Id, false);

            return mapper.Map<vmBlock_CommentList>(comments);
        }
    }
}
