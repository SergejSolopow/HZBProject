using BeamlineX.Domain;

namespace BeamlineX.Repositories.Abstraction
{
    public interface IRepository
    {
        Task<ICollection<T>> GetAllAsync<T>()
            where T : Entity;

        Task<T?> GetByIdAsync<T>(Guid id)
            where T : Entity;

        Task InsertAsync<T>(T t)
            where T : Entity;

        Task RemoveAsync<T>(Guid id)
            where T : Entity;

        Task RemoveAsync<T>(T? t)
            where T : Entity;

        Task SaveChangesAsync();

        Task UpdateAsync<T>(T t)
            where T : Entity;
        Task ClearAll<T>()
            where T : Entity;
    }
}
