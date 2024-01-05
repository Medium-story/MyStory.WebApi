using AutoMapper;
using MediumStory.Domain.Entities;
using MyStory.Data.Interfaces;
using MyStory.DTOs.Dtos.ReactionDtos;
using MyStory.Service.Interfaces;

namespace MyStory.Service.Services;

public class ReactionService(IUnitOfWork unitOfWork,
                             IMapper mapper) : IReactionService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task CreateAsync(AddReactionDto reactiveDto)
    {
        var reaction = _mapper.Map<Reaction>(reactiveDto);
        reaction.Article = null;
        reaction.User = null;
        await _unitOfWork.Reaction.CreateAsync(reaction);
        await _unitOfWork.SaveChangesAsync();
    }

    public Task DeleteAsync(int Id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<ReactionDto>> GetAllAsync()
    {
        var reactions = await _unitOfWork.Reaction.GetAllAsync();
        var reactionDtos = reactions.Select(i => _mapper.Map<ReactionDto>(i));
        return reactionDtos.ToList();
    }
}
