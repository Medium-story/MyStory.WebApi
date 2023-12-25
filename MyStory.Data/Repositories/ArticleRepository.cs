using MediumStory.Data.DataContext;
using MediumStory.Domain.Entities;
using MyStory.Data.Interfaces;

namespace MyStory.Data.Repositories;

public class ArticleRepository(AppDbContext appDb) : Repository<Article>(appDb), IArticleInterface
{

}
