using PetMaster.Domain.Entities;
using PetMaster.Domain.Repositories;
using PetMaster.Infra.Context;

namespace PetMaster.Infra.Repositories;
public class ServiceRepository(PetMasterContext context) 
    : RepositoryBase<Service>(context), IServiceRepository
{
}
