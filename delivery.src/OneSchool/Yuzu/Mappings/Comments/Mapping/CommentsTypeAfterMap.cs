using System;
using System.Linq;
using System.Collections.Generic;
using YuzuDelivery.Umbraco.Core;
using YuzuDelivery.ViewModels;
using YuzuDelivery.UmbracoModels;
using System.Web.Mvc;
using YuzuDelivery.Core;

namespace OneSchool
{
    public class CommentsTypeAfterMap : IYuzuTypeAfterConvertor<Course, vmBlock_Comments>
    {
        public void Apply(Course source, vmBlock_Comments dest, UmbracoMappingContext context)
        {
            var cRepo = DependencyResolver.Current.GetService<CommentsRepository>();
            var commentListFactory = DependencyResolver.Current.GetService<CommentListFactory>();
            var comments = cRepo.List(context.Model.Id, false);

            dest.Endpoints = new vmSub_CommentsEndpoints()
            {
                CommentForm = "?alttemplate=commentsform",
                CommentList = string.Format("/umbraco/surface/comments/get?courseId={0}", context.Model.Id)
            };

            dest.CommentList = commentListFactory.Create(comments);
        }
    }
}