using MediumStory.Data.DataContext;
using MediumStory.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using MyStory.Data.Interfaces;

namespace MyStory.Data.Repositories;

public class TagRepository(AppDbContext appDb) : Repository<Tag>(appDb), ITagInterface
{
    private readonly AppDbContext _appDb = appDb;

    public async Task<Tag> GetByName(string name)
    {
        var tags = await _appDb.Tags.FirstOrDefaultAsync(i => i.Name == name);
        return tags;
    }
}
