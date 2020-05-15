using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YuzuDelivery.ViewModels;
using Umbraco.Web.Mvc;
using YuzuDelivery.Core;

namespace OneSchool.Yuzu
{
    public class CommentsController : SurfaceController
    {
        CommentsRepository cRepo;
        CommentListFactory commentListFactory;
        IYuzuDefinitionTemplates yuzuTemplates;

        public CommentsController(CommentsRepository cRepo, CommentListFactory commentListFactory, IYuzuDefinitionTemplates yuzuTemplates)
        {
            this.cRepo = cRepo;
            this.commentListFactory = commentListFactory;
            this.yuzuTemplates = yuzuTemplates;
        }

        public string Get(int courseId)
        {
            var comments = cRepo.List(courseId, true);
            var commentsModels = commentListFactory.Create(comments);

            return yuzuTemplates.Render(new RenderSettings()
            {
                Template = "parCommentList",
                Data = () => {
                    return commentsModels;
                },
                ShowJson = true
            });
        }
    }
}