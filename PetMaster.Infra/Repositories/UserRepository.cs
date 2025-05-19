using PetMaster.Domain.Entities;
using PetMaster.Domain.Repositories;
using PetMaster.Infra.Context;

namespace PetMaster.Infra.Repositories;
public class UserRepository(PetMasterContext context) 
    : RepositoryBase<User>(context), IUserRepository
{
}
