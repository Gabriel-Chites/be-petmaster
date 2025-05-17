using PetMaster.Domain.Entities;
using PetMaster.Domain.Repositories;

namespace PetMaster.Infra.Repositories;
public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : Entity, new()
{
    public Task<T> CreateAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<T>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<T?> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<T> UpdateAsync(T entity)
    {
        throw new NotImplementedException();
    }
}
