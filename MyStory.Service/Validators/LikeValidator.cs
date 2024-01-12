using MediumStory.Domain.Entities;
using MyStory.Domain.Entities;

namespace MyStory.Service.Validators;

public static class LikeValidator
{
    public static bool IsExist(this Like like, IEnumerable<Like> likes)
        => likes.Any(
                      c => c.UserId == like.UserId &&
                      c.Id !=like.Id
        );
    public static bool IsExist(this ReplyLike replyLike, IEnumerable<ReplyLike> replyLikes)
        => replyLikes.Any(
                           c => c.UserId == replyLike.UserId &&
                           c.Id != replyLike.Id 
                           //c.ReplyId == replyLike.ReplyId

        );
}
