using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OneSchool.Core.ViewModels;
using Umbraco.Web.Mvc;
using YuzuDelivery.Core;

namespace OneSchool.Core
{

    public class CommentsController : SurfaceController
    {
        CommentsRepository cRepo;
        IYuzuDefinitionTemplates yuzuTemplates;

        public CommentsController(CommentsRepository cRepo, IYuzuDefinitionTemplates yuzuTemplates)
        {
            this.cRepo = cRepo;
            this.yuzuTemplates = yuzuTemplates;
        }

        public string Get(int courseId)
        {
            var comments = cRepo.List(courseId, true);

            return yuzuTemplates.Render<vmBlock_CommentList>(new RenderSettings()
            {
                Template = "parCommentList",
                MapFrom = comments,
                ShowJson = true
            }, null);
        }
    }
    
}
