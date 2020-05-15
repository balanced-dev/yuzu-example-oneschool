using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OneSchool
{
    public class CommentsRepository
    {
        public List<Comment> List(int courseId, bool fromController)
        {
            var output = new List<Comment>()
            {
                new Comment()
                {
                    HeaderShotUrl = "/_client/images/person_1.jpg",
                    Name = "Jean Doe",
                    TimeStamp = DateTime.Now,
                    Message = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Pariatur quidem laborum necessitatibus, ipsam impedit vitae autem, eum officia, fugiat saepe enim sapiente iste iure! Quam voluptas earum impedit necessitatibus, nihil?"
                }
            };

            if (fromController)
            {
                output.Add(new Comment()
                {
                    HeaderShotUrl = "/_client/images/person_2.jpg",
                    Name = "Dean Bradfield",
                    TimeStamp = DateTime.Now,
                    Message = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Pariatur quidem laborum necessitatibus, ipsam impedit vitae autem, eum officia, fugiat saepe enim sapiente iste iure! Quam voluptas earum impedit necessitatibus, nihil?"
                });
            }

            return output;
        }

    }

    public class Comment
    {
        public int CourseId { get; set; }
        public string HeaderShotUrl { get; set; }
        public string Name { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Message { get; set; }
    }
}