using PetMaster.Domain.Entities;
using PetMaster.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetMaster.Domain.Services;
public class UserService(IUserRepository repository)
{
    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await repository.GetAllAsync();
    }

    public async Task<User?> GetByIdAsync(Guid id)
    {
        return await repository.GetByIdAsync(id);
    }

    public async Task<User> CreateAsync(User user)
    {
        return await repository.CreateAsync(user);
    }

    public async Task<User> UpdateAsync(User user)
    {
        return await repository.UpdateAsync(user);
    }

    public async Task DeleteAsync(Guid id)
    {
        await repository.DeleteAsync(id);
    }
}
