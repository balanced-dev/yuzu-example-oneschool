using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YuzuDelivery.UmbracoModels;
using Skybrud.Umbraco.GridData;
using Skybrud.Umbraco.GridData.Dtge;
using Umbraco.Core.Models.PublishedContent;
using YuzuDelivery.Umbraco.Grid;
using System.Dynamic;
using System.Web.Mvc;

namespace OneSchool
{
    public class TeacherProfilesGridItem : IGridItem
    {
        protected TeacherProfilesService svc;

        public TeacherProfilesGridItem(TeacherProfilesService svc)
        {
            this.svc = svc;
        }

        public Type ElementType { get { return typeof(TeacherProfiles); } }

        public virtual bool IsValid(string name, GridControl control)
        {
            var content = control.GetValue<GridControlDtgeValue>();
            if (content != null)
            {
                return content.Content.ContentType.Alias == "teacherProfiles";
            }
            return false;
        }

        public virtual object Apply(GridItemData data)
        {
            var model = data.Control.GetValue<GridControlDtgeValue>();

            dynamic config = new ExpandoObject();
            config.gridSize = data.Control.Area.Grid;

            return CreateVm(model.Content, data.ContextItems, config);
        }

        public object CreateVm(IPublishedElement model, IDictionary<string, object> contextItems, dynamic config = null)
        {
            return svc.GetProfiles(0);
        }
    }
}