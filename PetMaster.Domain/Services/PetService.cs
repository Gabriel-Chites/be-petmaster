using PetMaster.Domain.Entities;
using PetMaster.Domain.Repositories;
using PetMaster.Domain.Services.Interfaces;

namespace PetMaster.Domain.Services;
public class PetService(IPetRepository petRepository) : IPetService
{
    public async Task<IEnumerable<Pet>> GetAllAsync()
    {
        return await petRepository.GetAllAsync();
    }

    public async Task<Pet?> GetByIdAsync(Guid id)
    {
        return await petRepository.GetByIdAsync(id);
    }

    public async Task<Pet> CreateAsync(Pet pet)
    {
        return await petRepository.CreateAsync(pet);
    }

    public async Task<bool> UpdateAsync(Guid id, Pet pet)
    {
        return await petRepository.UpdateAsync(id, pet);
    }

    public async Task DeleteAsync(Guid id)
    {
        await petRepository.DeleteAsync(id);
    }
}

