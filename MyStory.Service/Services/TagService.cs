using AutoMapper;
using MediumStory.Domain.Entities;
using MyStory.Data.Interfaces;
using MyStory.Data.Repositories;
using MyStory.DTOs.Dtos.TagDtos;
using MyStory.Service.Exceptions.TagExceptions;
using MyStory.Service.Interfaces;

namespace MyStory.Service.Services;

public class TagService(IUnitOfWork unitOfWork,
                        IMapper mapper) : ITagService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task CreateAsync(AddTagDto tagDto)
    {
        if (tagDto == null)
        {
            throw new TagNullException();
        }
        var tag = _mapper.Map<Tag>(tagDto);
        if (tag == null)
        {
            throw new TagNotFoundException();
        }
        tag.User = null;
        await _unitOfWork.Tag.CreateAsync(tag);
        await _unitOfWork.SaveChangesAsync();

    }

    public async Task DeleteAsync(int Id)
    {
        if (Id == null)
        {
            throw new TagNullException();
        }
        var tag = await _unitOfWork.Tag.GetByIdAsync(Id);
        if (tag == null)
        {
            throw new TagNotFoundException();
        }
        _unitOfWork.Tag.Delete(tag);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<List<TagDto>> GetAllAsync()
    {

        var tag = await _unitOfWork.Tag.GetAllAsync();
        if (tag == null)
        {
            throw new TagNullException();
        }
        var tagDtos = tag.Select(i => _mapper.Map<TagDto>(i)).ToList();
        return tagDtos;
    }

    public async Task UpdateAsync(UpdateTagDto tagDto)
    {
        if (tagDto == null)
        {
            throw new TagNullException();
        }
        var tag = _mapper.Map<Tag>(tagDto);
        if (tag == null)
        {
            throw new TagNotFoundException();
        }
        tag.User = null;
        _unitOfWork.Tag.Update(tag);
        await _unitOfWork.SaveChangesAsync();
    }
}
