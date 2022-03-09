using BeamlineX.Domain;
using BeamlineX.Repositories.Abstraction;

using Microsoft.EntityFrameworkCore;

namespace BeamlineX.Repositories
{
    public class Repository : IRepository
    {
        private readonly BeamlineXDbContext _context;

        public Repository(BeamlineXDbContext context)
        {
            _context = context;
        }

        public async Task ClearAll<T>()
            where T : Entity
        {
            var query = _context.Set<T>();
            _context.RemoveRange(query);
            await Task.CompletedTask;
        }

        public virtual async Task<ICollection<T>> GetAllAsync<T>()
            where T : Entity
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T?> GetByIdAsync<T>(Guid id)
            where T : Entity
        {
            return await _context.Set<T>().FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task InsertAsync<T>(T t) where T : Entity
        {
            await _context.Set<T>().AddAsync(t);
        }

        public async Task RemoveAsync<T>(Guid id)
            where T : Entity
        {
            T? t = await GetByIdAsync<T>(id);
            await RemoveAsync(t);
        }

        public async Task RemoveAsync<T>(T? t)
            where T : Entity
        {
            if (t is null)
            {
                throw new ArgumentNullException(nameof(t));
            }

            _context.Set<T>().Remove(t);
            await Task.CompletedTask;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public Task UpdateAsync<T>(T t) where T : Entity
        {
            throw new NotImplementedException();
        }
    }
}
