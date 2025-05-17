using PetMaster.Domain.Entities;
using PetMaster.Domain.Repositories;
using PetMaster.Domain.Services.Interfaces;

namespace PetMaster.Domain.Services;
public class PetService : IPetService
{
    private readonly IPetRepository _petRepository;

    public PetService(IPetRepository petRepository)
    {
        _petRepository = petRepository;
    }

    public async Task<IEnumerable<Pet>> GetAllAsync()
    {
        return await _petRepository.GetAllAsync();
    }

    public async Task<Pet?> GetByIdAsync(Guid id)
    {
        return await _petRepository.GetByIdAsync(id);
    }

    public async Task<Pet> CreateAsync(Pet pet)
    {
        return await _petRepository.CreateAsync(pet);
    }

    public async Task<Pet> UpdateAsync(Pet pet)
    {
        return await _petRepository.UpdateAsync(pet);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _petRepository.DeleteAsync(id);
    }
}

