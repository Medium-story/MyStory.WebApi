﻿using MediumStory.Domain.Entities;

namespace MyStory.Data.Interfaces;

public interface IArticleInterface : IRepository<Article>
{
    Task<ICollection<Article>> GetAllWithEntities();
}
