using PetMaster.Domain.Entities;
using PetMaster.Domain.Repositories;
using PetMaster.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetMaster.Domain.Services;
public class ResponsibleService(IResponsibleRepository repository) : IResponsibleService
{
    public async Task<IEnumerable<Responsible>> GetAllAsync() => await repository.GetAllAsync();

    public async Task<Responsible?> GetByIdAsync(Guid id) => await repository.GetByIdAsync(id);

    public async Task<Responsible> CreateAsync(Responsible responsible) => await repository.CreateAsync(responsible);

    public async Task<bool> UpdateAsync(Guid id, Responsible responsible) => await repository.UpdateAsync(id, responsible);

    public async Task DeleteAsync(Guid id) => await repository.DeleteAsync(id);
}
