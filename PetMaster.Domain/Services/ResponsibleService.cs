using PetMaster.Domain.Entities;
using PetMaster.Domain.Repositories;
using PetMaster.Domain.Response;
using PetMaster.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetMaster.Domain.Services;
public class ResponsibleService(IResponsibleRepository repository) : IResponsibleService
{
    public async Task<Result> GetAllAsync()
    {
        var responsibles = await repository.GetAllAsync();
        return new Result(true, responsibles);
    }

    public async Task<Result> GetByIdAsync(Guid id)
    {
        var responsible = await repository.GetByIdAsync(id);
        return new Result(responsible is not null, responsible);
    }

    public async Task<Result> CreateAsync(Responsible responsible)
    {
        var responsibleCreated = await repository.CreateAsync(responsible);
        return new Result(responsibleCreated is not null, responsibleCreated);
    }

    public async Task<Result> UpdateAsync(Guid id, Responsible responsible)
    {
        var updated = await repository.UpdateAsync(id, responsible);
        return new Result(updated, updated ? "Responsável atualizado com sucesso" : "Erro ao atualizar responsável");
    }

    public async Task DeleteAsync(Guid id) => await repository.DeleteAsync(id);
}
