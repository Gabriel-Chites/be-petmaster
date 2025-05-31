using PetMaster.Domain.Entities;
using PetMaster.Domain.Repositories;
using PetMaster.Domain.Response;
using PetMaster.Domain.Services.Interfaces;

namespace PetMaster.Domain.Services;
public class ServiceService(IServiceRepository repository) : IServiceService
{
    public async Task<Result> GetAllAsync()
    {
        var services = await repository.GetAllAsync();
        return new Result(true, services);
    }

    public async Task<Result> GetByIdAsync(Guid id)
    {
        var service = await repository.GetByIdAsync(id);
        return new Result(service is not null, service);
    }

    public async Task<Result> CreateAsync(Service product)
    {
        var serviceCreated = await repository.CreateAsync(product);
        return new Result(serviceCreated is not null, serviceCreated);
    }

    public async Task<Result> UpdateAsync(Guid id, Service product)
    {
        var updated = await repository.UpdateAsync(id, product);
        return new Result(updated, updated ? "Serviço atualizado" : "Erro ao atualizar o serviço");
    }

    public async Task DeleteAsync(Guid id) => await repository.DeleteAsync(id);
}
