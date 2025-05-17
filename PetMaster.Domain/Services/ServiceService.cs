using PetMaster.Domain.Entities;
using PetMaster.Domain.Repositories;

namespace PetMaster.Domain.Services;
public class ServiceService(IServiceRepository repository)
{
    public async Task<IEnumerable<Service>> GetAllAsync()
    {
        return await repository.GetAllAsync();
    }

    public async Task<Service?> GetByIdAsync(Guid id)
    {
        return await repository.GetByIdAsync(id);
    }

    public async Task<Service> CreateAsync(Service product)
    {
        return await repository.CreateAsync(product);
    }

    public async Task<Service> UpdateAsync(Service product)
    {
        return await repository.UpdateAsync(product);
    }

    public async Task DeleteAsync(Guid id)
    {
        await repository.DeleteAsync(id);
    }
}
