using AutoMapper;
using MediumStory.Domain.Entities;
using MyStory.Data.Interfaces;
using MyStory.DTOs.Dtos.ReplyDtos;
using MyStory.Service.Interfaces;

namespace MyStory.Service.Services;

public class ReplyService(IUnitOfWork unitOfWork,
                          IMapper mapper) : IReplyService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task CreateAsync(AddReplyDto replyDto)
    {
        var reply = _mapper.Map<Reply>(replyDto);
        reply.Article = null;
        reply.User = null;
        reply.Comment = null;
        await _unitOfWork.Reply.CreateAsync(reply);
        await _unitOfWork.SaveChangesAsync();
    }

    public Task DeleteAsync(int Id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<ReplyDto>> GetAllAsync()
    {
        var replies = await _unitOfWork.Reply.GetAllWithEntities();
        var result = replies.Select(i => _mapper.Map<ReplyDto>(i)).ToList();
        return result;
    }

    public Task UpdateAsync(UpdateReplyDto articleDto)
    {
        throw new NotImplementedException();
    }
}
