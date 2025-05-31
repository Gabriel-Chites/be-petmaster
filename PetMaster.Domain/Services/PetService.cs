using PetMaster.Domain.Entities;
using PetMaster.Domain.Repositories;
using PetMaster.Domain.Response;
using PetMaster.Domain.Services.Interfaces;

namespace PetMaster.Domain.Services;
public class PetService(IPetRepository petRepository) : IPetService
{
    public async Task<Result> GetAllAsync()
    {
        var pets = await petRepository.GetAllAsync();
        return new Result(true, pets);
    }

    public async Task<Result> GetByIdAsync(Guid id)
    {
        var pet = await petRepository.GetByIdAsync(id);
        return new Result(pet is not null, pet);
    }

    public async Task<Result> CreateAsync(Pet pet)
    {
        var petCreated = await petRepository.CreateAsync(pet);
        return new Result(petCreated is not null, petCreated);
    }

    public async Task<Result> UpdateAsync(Guid id, Pet pet)
    {
        var petResult = await petRepository.UpdateAsync(id, pet);
        return new Result(petResult, petResult ?"Pet atualizado" : "Erro ao atualizar o pet");
    }

    public async Task DeleteAsync(Guid id)
    {
        await petRepository.DeleteAsync(id);
    }
}

