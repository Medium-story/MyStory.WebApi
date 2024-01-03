using MyStory.DTOs.Dtos.ArticleDtos;
using MyStory.DTOs.Dtos.LikeDtos;
using MyStory.Service.Interfaces;

namespace MyStory.Service.Services;

public class LikeService : ILikeService
{
    public Task CreateAsync(AddLikeDto articleDto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int Id)
    {
        throw new NotImplementedException();
    }

    public Task<List<LikeDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }
}
