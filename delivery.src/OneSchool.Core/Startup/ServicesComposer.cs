using System;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Core;
using Umbraco.Core.Composing;

namespace OneSchool.Core
{
    [RuntimeLevel(MinLevel = RuntimeLevel.Run)]
    public class ServicesComposer : IUserComposer
    {
        public void Compose(Composition composition)
        {
            composition.Register<TeacherProfilesService>();
            composition.Register<CommentsRepository>();
        }
    }
}
