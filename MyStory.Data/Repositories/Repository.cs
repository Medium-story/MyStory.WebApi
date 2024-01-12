using MediumStory.Data.DataContext;
using MediumStory.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using MyStory.Data.Interfaces;

namespace MyStory.Data.Repositories;

public class Repository<T>(AppDbContext appDb) : IRepository<T> where T : BaseEntity
{
    protected DbSet<T> _dbSet = appDb.Set<T>();

    public async Task CreateAsync(T entity) => await _dbSet.AddAsync(entity);

    public void Delete(T entity) => _dbSet.Remove(entity);

    public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.AsNoTracking().ToListAsync();

    public async Task<T> GetByIdAsync(int id) => await _dbSet.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);

    public void Update(T entity) => _dbSet.Update(entity);
}
