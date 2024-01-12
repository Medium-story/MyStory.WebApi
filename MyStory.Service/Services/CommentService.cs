using AutoMapper;
using MediumStory.Domain.Entities;
using MyStory.Data.Interfaces;
using MyStory.DTOs.Dtos.CommentDtos;
using MyStory.Service.Exceptions.CommentException;
using MyStory.Service.Interfaces;

namespace MyStory.Service.Services;

public class CommentService(IUnitOfWork unitOfWork,
                            IMapper mapper) : ICommentService

{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task CreateAsync(AddCommentDto commentDto)
    {
        if (commentDto == null)
        {
            throw new CommentNullException();
        }
        var comment = _mapper.Map<Comment>(commentDto);

        if (comment == null)
        {
            throw new CommentNotFoundException();
        }
        comment.Article = null;
        comment.User = null;
        await _unitOfWork.Comment.CreateAsync(comment);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(int Id)
    {
        if (Id == null)
        {
            throw new CommentNullException();
        }
        var comment = await _unitOfWork.Comment.GetByIdAsync(Id);
        if( comment == null)
        {
            throw new CommentNotFoundException();
        }
        _unitOfWork.Comment.Delete(comment);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<List<CommentDto>> GetAllAsync()
    {
        var comments = await _unitOfWork.Comment.GetAllWithReplies();
        if (comments == null)
        {
            throw new CommentNullException();
        }
        return comments.Select(i => _mapper.Map<CommentDto>(i)).ToList();
    }

    public async Task<CommentDto> getByIdAsync(int Id)
    {
        var comment = await _unitOfWork.Comment.GetByIdAsync(Id);
        if (comment is null)
        {
            throw new CommentNullException();
        }
        return _mapper.Map<CommentDto>(comment);
    }

    public async Task UpdateAsync(UpdateCommentDto commentDto)
    {
        if (commentDto == null)
        {
            throw new CommentNullException();
        }
        var comment = _mapper.Map<Comment>(commentDto);
        if(comment == null)
        {
            throw new CommentNotFoundException();
        }
        comment.User = null;
        _unitOfWork.Comment.Update(comment);
        await _unitOfWork.SaveChangesAsync();
    }
}
