using Microsoft.EntityFrameworkCore;
using PetMaster.Domain.Entities;
using PetMaster.Domain.Repositories;
using PetMaster.Infra.Context;

namespace PetMaster.Infra.Repositories;
public class UserRepository(PetMasterContext context)
    : RepositoryBase<User>(context), IUserRepository
{
    public async Task<(bool CanAccess, bool? FirstAccess)> CanAccessAsync(string registrationNumber, string password)
    {
        var user = await context.Users
            .Where(u => u.RegistrationNumber == registrationNumber && u.Password == password)
            .Select(u => new { CanAccess = true, u.FirstAccess })
            .FirstOrDefaultAsync(CancellationToken.None);

        return user != null ? (true, user.FirstAccess) : (false, null);
    }

    public async Task<User?> GetByRegistrationNumberAsync(string registrationNumber)
        => await context.Users.FirstOrDefaultAsync(u => u.RegistrationNumber == registrationNumber, CancellationToken.None);
}
