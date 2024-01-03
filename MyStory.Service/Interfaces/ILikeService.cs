using MyStory.DTOs.Dtos.ArticleDtos;
using MyStory.DTOs.Dtos.LikeDtos;

namespace MyStory.Service.Interfaces;

public interface ILikeService
{
    Task<List<LikeDto>> GetAllAsync();
    Task CreateAsync(AddLikeDto articleDto);
    Task DeleteAsync(int Id);
}
