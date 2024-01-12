using MediumStory.Domain.Entities;
using MyStory.Data.Interfaces;

namespace MyStory.Service.Validators;

public static class ReplyValidator
{
    public static bool IsExist(this Reply like, IEnumerable<User> likes)
        => likes.Any(


        );
}
