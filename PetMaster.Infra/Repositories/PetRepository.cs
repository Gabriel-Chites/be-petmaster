using PetMaster.Domain.Entities;
using PetMaster.Domain.Repositories;
using PetMaster.Infra.Context;

namespace PetMaster.Infra.Repositories;
public class PetRepository(PetMasterContext context)
    : RepositoryBase<Pet>(context), IPetRepository
{
}
