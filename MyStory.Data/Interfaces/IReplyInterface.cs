﻿using MediumStory.Domain.Entities;

namespace MyStory.Data.Interfaces;

public interface IReplyInterface : IRepository<Reply>
{
    Task<ICollection<Reply>> GetAllWithEntities();
}
