using AutoMapper;
using MediumStory.Domain.Entities;
using MyStory.Data.Interfaces;
using MyStory.DTOs.Dtos.ReplyDtos;
using MyStory.DTOs.Dtos.TagDtos;
using MyStory.Service.Exceptions.ReplyException;
using MyStory.Service.Exceptions.TagExceptions;
using MyStory.Service.Interfaces;

namespace MyStory.Service.Services;

public class ReplyService(IUnitOfWork unitOfWork,
                          IMapper mapper) : IReplyService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task CreateAsync(AddReplyDto replyDto)
    {
        if (replyDto == null)
        {
            throw new ReplyNullException();
        }
        var reply = _mapper.Map<Reply>(replyDto);

        reply.Article = null;
        reply.User = null;
        reply.Comment = null;
        await _unitOfWork.Reply.CreateAsync(reply);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(int Id)
    {
        if (Id == null)
        {
            throw new ReplyNullException();
        }
        var reply = await _unitOfWork.Reply.GetByIdAsync(Id);
        if (reply == null)
        {
            throw new ReplyNotFoundException();
        }
        reply.User = null;
        reply.Article = null;
        reply.Comment = null;

        _unitOfWork.Reply.Delete(reply);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<List<ReplyDto>> GetAllAsync()
    {
        var replies = await _unitOfWork.Reply.GetAllWithEntities();
        if (replies == null)
        {
            throw new TagNullException();
        }
        var result = replies.Select(i => _mapper.Map<ReplyDto>(i)).ToList();
        return result;
    }

    public async Task UpdateAsync(UpdateReplyDto articleDto)
    {
        if (articleDto == null)
        {
            throw new ReplyNullException();
        }
        var reply = _mapper.Map<Reply>(articleDto);
        if (reply == null)
        {
            throw new ReplyNotFoundException();
        }
        reply.User = null;
        _unitOfWork.Reply.Update(reply);
        await _unitOfWork.SaveChangesAsync();
    }
}
