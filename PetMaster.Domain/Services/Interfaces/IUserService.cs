using PetMaster.Domain.Entities;
using PetMaster.Domain.Request;
using PetMaster.Domain.Response;

namespace PetMaster.Domain.Services.Interfaces;
public interface IUserService : IServiceBase<User>
{
    Task<Result> UpdatePasswordAsync(FirstAccessRequest request);
}
