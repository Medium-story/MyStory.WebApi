using AutoMapper;
using MediumStory.Domain.Entities;
using MyStory.Data.Interfaces;
using MyStory.DTOs.Dtos.ReactionDtos;
using MyStory.DTOs.Dtos.TagDtos;
using MyStory.Service.Exceptions.ReactionRxception;
using MyStory.Service.Exceptions.TagExceptions;
using MyStory.Service.Interfaces;

namespace MyStory.Service.Services;

public class ReactionService(IUnitOfWork unitOfWork,
                             IMapper mapper) : IReactionService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task CreateAsync(AddReactionDto reactiveDto)
    {
        if (reactiveDto == null)
        {
            throw new ReactionNullException();
        }
        var reaction = _mapper.Map<Reaction>(reactiveDto);
        reaction.Article = null;
        reaction.User = null;
        await _unitOfWork.Reaction.CreateAsync(reaction);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(int Id)
    {
        if (Id == null)
        {
            throw new ReactionNullException();
        }
        var reaction = await _unitOfWork.Reaction.GetByIdAsync(Id);
        if (reaction == null)
        {
            throw new TagNotFoundException();
        }
        _unitOfWork.Reaction.Delete(reaction);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<List<ReactionDto>> GetAllAsync()
    {
        var reactions = await _unitOfWork.Reaction.GetAllAsync();
        if (reactions == null)
        {
            throw new ReactionNullException();
        }
        var reactionDtos = reactions.Select(i => _mapper.Map<ReactionDto>(i));
        return reactionDtos.ToList();
    }
}
