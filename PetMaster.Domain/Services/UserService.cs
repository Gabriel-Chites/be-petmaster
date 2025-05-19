using PetMaster.Domain.Entities;
using PetMaster.Domain.Repositories;
using PetMaster.Domain.Services.Interfaces;

namespace PetMaster.Domain.Services;
public class UserService(IUserRepository repository) : IUserService
{
    public async Task<IEnumerable<User>> GetAllAsync() => await repository.GetAllAsync();

    public async Task<User?> GetByIdAsync(Guid id) => await repository.GetByIdAsync(id);

    public async Task<User> CreateAsync(User user) => await repository.CreateAsync(user);

    public async Task<bool> UpdateAsync(Guid id, User user) => await repository.UpdateAsync(id, user);

    public async Task DeleteAsync(Guid id) => await repository.DeleteAsync(id);
}
