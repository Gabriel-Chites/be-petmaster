using PetMaster.Domain.Entities;

namespace PetMaster.Domain.Services.Interfaces;
public interface IServiceBase<T> where T : Entity
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetByIdAsync(Guid id);
    Task<T> CreateAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task DeleteAsync(Guid id);
}
