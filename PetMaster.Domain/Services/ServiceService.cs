using PetMaster.Domain.Entities;
using PetMaster.Domain.Repositories;
using PetMaster.Domain.Services.Interfaces;

namespace PetMaster.Domain.Services;
public class ServiceService(IServiceRepository repository) : IServiceService
{
    public async Task<IEnumerable<Service>> GetAllAsync() => await repository.GetAllAsync();

    public async Task<Service?> GetByIdAsync(Guid id) => await repository.GetByIdAsync(id);

    public async Task<Service> CreateAsync(Service product) => await repository.CreateAsync(product);

    public async Task<bool> UpdateAsync(Guid id, Service product) => await repository.UpdateAsync(id, product);

    public async Task DeleteAsync(Guid id) => await repository.DeleteAsync(id);
}
