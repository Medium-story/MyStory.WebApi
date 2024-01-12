using MediumStory.Domain.Entities;

namespace MyStory.Service.Validators;

public static class LikeValidator
{
    public static bool IsExist(this Like like, IEnumerable<Like> likes)
        => likes.Any(
                      
         
        );
}
