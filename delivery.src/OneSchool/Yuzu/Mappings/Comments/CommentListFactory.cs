using System;
using System.Linq;
using System.Collections.Generic;
using YuzuDelivery.Core;
using YuzuDelivery.Umbraco.Core;
using YuzuDelivery.ViewModels;
using YuzuDelivery.UmbracoModels;

namespace OneSchool
{   
    public class CommentListFactory
    {
        public vmBlock_CommentList Create(List<Comment> comments)
        {
            return new vmBlock_CommentList()
            {
                Title = comments.Count == 1 ? "1 Comment" : string.Format("{0} Comments", comments.Count),
                Items = comments.Select(x => new vmSub_CommentListItem()
                {
                    Name = x.Name,
                    Comment = x.Message,
                    Headshot = new vmBlock_DataImage() { Src = x.HeaderShotUrl },

                    Timestamp = x.TimeStamp.ToString("dd/MM/yyy")
                }).ToList()
            };
        }
    }
}