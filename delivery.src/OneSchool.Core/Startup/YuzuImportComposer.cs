using System;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;
using System.Linq;
using System.Web;
using Umbraco.Core;
using Umbraco.Core.Composing;
using YuzuDelivery.Core;
using YuzuDelivery.Umbraco.Blocks;
using YuzuDelivery.Umbraco.Grid;
using YuzuDelivery.Umbraco.Forms;
using YuzuDelivery.Umbraco.Import;
using OneSchool.Core.ViewModels;
using OneSchool.Core.UmbracoModels;

namespace OneSchool.Core
{

    [RuntimeLevel(MinLevel = RuntimeLevel.Run)]
    [ComposeBefore(typeof(YuzuStartup))]
    public class YuzuImportsComposer : IUserComposer
    {
        public void Compose(Composition composition)
        {
            var Server = HttpContext.Current.Server;
            var localAssembly = Assembly.GetAssembly(typeof(YuzuImportsComposer));
            var gridAssembly = Assembly.GetAssembly(typeof(YuzuGridStartup));

            var config = new YuzuDeliveryImportConfiguration()
            {
                IsActive = ConfigurationManager.AppSettings["YuzuImportActive"] == "true",
                DocumentTypeAssemblies = new Assembly[] { localAssembly },
                ViewModelQualifiedTypeName = "OneSchool.Core.ViewModels.{0}, OneSchool.Core",
                UmbracoModelsQualifiedTypeName = "OneSchool.Core.UmbracoModels.{0}, OneSchool.Core",
                DataTypeFolder = new DataTypeFolder()
                {
                    Name = "One School",
                    Level = 1
                },
                DataLocations = new List<IDataLocation>()
                {
                    new DataLocation()
                    {
                        Name = "Main",
                        Path = Server.MapPath(ConfigurationManager.AppSettings["HandlebarsData"])
                    }
                },
                ImageLocations = new List<IDataLocation>()
                {
                    new DataLocation()
                    {
                        Name = "Main",
                        Path = Server.MapPath(ConfigurationManager.AppSettings["HandlebarsImages"])
                    }
                },
                CustomConfigFileLocation = Server.MapPath(ConfigurationManager.AppSettings["YuzuImportCustomConfig"])
            };

            config.IgnoreViewmodels.Add<vmBlock_Form>();
            config.IgnoreViewmodels.Add<vmBlock_FormButton>();
            config.IgnoreViewmodels.Add<vmBlock_FormTextArea>();
            config.IgnoreViewmodels.Add<vmBlock_FormTextInput>();

            config.IgnoreViewmodels.Add<vmBlock_SectionGridConfig>();
            config.IgnoreViewmodels.Add<vmBlock_CourseGridSizes>();
            config.IgnoreViewmodels.Add<vmBlock_CommentList>();

            config.IgnoreProperties.Add("Form");

            config.IgnorePropertiesInViewModels.Add<vmBlock_TeacherProfiles, string>(x => x.NextPageEndpoint);

            config.IgnorePropertiesInViewModels.Add<vmBlock_Comments, vmSub_CommentsEndpoints>(x => x.Endpoints);
            config.IgnorePropertiesInViewModels.Add<vmBlock_Comments, vmBlock_CommentList>(x => x.CommentList);

            config.IgnoreUmbracoModelsForAutomap.Add<Course>();
            config.IgnoreUmbracoModelsForAutomap.Add<Comments>();
            config.IgnoreUmbracoModelsForAutomap.Add<SectionGridPage>();
            config.IgnoreUmbracoModelsForAutomap.Add<ContactUs>();
            config.IgnoreUmbracoModelsForAutomap.Add<PageHeroSignupForm>();
            config.IgnoreUmbracoModelsForAutomap.Add<SiteFooterNewsletterSection>();
            config.IgnoreUmbracoModelsForAutomap.Add<CommentsCommentForm>();

            YuzuDeliveryImport.Initialize(config);
        }

    }

}
