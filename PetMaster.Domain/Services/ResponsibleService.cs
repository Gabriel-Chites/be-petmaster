using PetMaster.Domain.Entities;
using PetMaster.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetMaster.Domain.Services;
public class ResponsibleService(IResponsibleRepository repository)
{
    public async Task<IEnumerable<Responsible>> GetAllAsync()
    {
        return await repository.GetAllAsync();
    }

    public async Task<Responsible?> GetByIdAsync(Guid id)
    {
        return await repository.GetByIdAsync(id);
    }

    public async Task<Responsible> CreateAsync(Responsible responsible)
    {
        return await repository.CreateAsync(responsible);
    }

    public async Task<Responsible> UpdateAsync(Responsible responsible)
    {
        return await repository.UpdateAsync(responsible);
    }

    public async Task DeleteAsync(Guid id)
    {
        await repository.DeleteAsync(id);
    }
}
