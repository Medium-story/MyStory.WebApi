using AutoMapper;
using MediumStory.Domain.Entities;
using MyStory.Data.Interfaces;
using MyStory.DTOs.Dtos.CommentDtos;
using MyStory.Service.Interfaces;

namespace MyStory.Service.Services;

public class CommentService(IUnitOfWork unitOfWork,
                            IMapper mapper) : ICommentService

{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task CreateAsync(AddCommentDto commentDto)
    {
        // Karochi commit uchun
        var comment = _mapper.Map<Comment>(commentDto);
        comment.Article = null;
        comment.User = null;
        await _unitOfWork.Comment.CreateAsync(comment);
        await _unitOfWork.SaveChangesAsync();
    }

    public Task DeleteAsync(int Id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<CommentDto>> GetAllAsync()
    {
        var comments = await _unitOfWork.Comment.GetAllWithReplies();
        return comments.Select(i => _mapper.Map<CommentDto>(i)).ToList();
    }

    public Task<CommentDto> getByIdAsync(int Id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(UpdateCommentDto commentDto)
    {
        throw new NotImplementedException();
    }
}
