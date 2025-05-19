using PetMaster.Domain.Entities;

namespace PetMaster.Domain.Repositories;
public interface IRepositoryBase<T> where T : Entity
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetByIdAsync(Guid id);
    Task<T> CreateAsync(T entity);
    Task<bool> UpdateAsync(Guid id, T entity);
    Task DeleteAsync(Guid id);
}
