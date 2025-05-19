using PetMaster.Domain.Entities;
using PetMaster.Domain.Repositories;
using PetMaster.Infra.Context;

namespace PetMaster.Infra.Repositories;
public class ResponsibleRepository(PetMasterContext context) 
    : RepositoryBase<Responsible>(context), IResponsibleRepository
{
}
