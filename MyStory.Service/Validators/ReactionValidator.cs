using MediumStory.Domain.Entities;
using MediumStory.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStory.Service.Validators
{
    public static class ReactionValidator
    {
        public static bool IsExist(this Reaction reaction, IEnumerable<Reaction> reactions)
            => reactions.Any(r => r.UserId == reaction.UserId &&
                                  r.ArticleId == reaction.ArticleId &&
                                  r.Id == reaction.Id);
    }
}
