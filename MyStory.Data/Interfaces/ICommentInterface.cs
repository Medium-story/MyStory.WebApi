using MediumStory.Domain.Entities;

namespace MyStory.Data.Interfaces;

public interface ICommentInterface : IRepository<Comment>
{
    Task<ICollection<Comment>> GetAllWithReplies();
    Task<Comment?> GetByIdWithLike(int id);
}
