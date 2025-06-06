using PetMaster.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetMaster.Domain.Repositories;
public interface IUserRepository : IRepositoryBase<User>
{
    Task<(bool CanAccess, bool? FirstAccess)> CanAccessAsync(string registrationNumber, string password);
    Task<User?> GetByRegistrationNumberAsync(string registrationNumber);
}
