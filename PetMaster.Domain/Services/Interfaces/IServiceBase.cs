using PetMaster.Domain.Entities;
using PetMaster.Domain.Response;

namespace PetMaster.Domain.Services.Interfaces;
public interface IServiceBase<T> where T : Entity
{
    Task<Result> GetAllAsync();
    Task<Result> GetByIdAsync(Guid id);
    Task<Result> CreateAsync(T entity);
    Task<Result> UpdateAsync(Guid id, T entity);
    Task DeleteAsync(Guid id);
}
