using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Umbraco.Core;
using Umbraco.Core.Composing;
using YuzuDelivery.Umbraco.Blocks;
using YuzuDelivery.Umbraco.Grid;
using YuzuDelivery.Umbraco.Forms;
using AutoMapper.Configuration;
using OneSchool.Core.UmbracoModels;
using OneSchool.Core.ViewModels;

namespace OneSchool.Core
{
    [RuntimeLevel(MinLevel = RuntimeLevel.Run)]
    public class MappingComposer : IUserComposer
    {
        public void Compose(Composition composition)
        {
            var cfg = new MapperConfigurationExpression();
            cfg.AddMaps(typeof(MappingComposer));
            cfg.AddMaps(typeof(YuzuStartup));
            cfg.AddMaps(typeof(YuzuFormsStartup));

            cfg.AddGridWithRows<SectionGridPage, vmPage_SectionGridPage, vmBlock_SectionGridConfig>(src => src.Content, dest => dest.Content);

            cfg.AddForm<CommentsCommentForm, vmSub_CommentsCommentForm>(src => src.Form, dest => dest.Form);
            cfg.AddForm<ContactUs , vmBlock_ContactUs>(src => src.Form, dest => dest.Form);
            cfg.AddForm<PageHeroSignupForm, vmSub_PageHeroSignupForm>(src => src.Form, dest => dest.Form);
            cfg.AddForm<SiteFooterNewsletterSection, vmSub_SiteFooterNewsletterSection>(src => src.Form, dest => dest.Form);

            var mapperConfig = new MapperConfiguration(cfg);

            composition.Register<IMapper>(new Mapper(mapperConfig));
        }
    }
}
