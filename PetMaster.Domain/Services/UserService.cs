using PetMaster.Domain.Entities;
using PetMaster.Domain.Repositories;
using PetMaster.Domain.Request;
using PetMaster.Domain.Response;
using PetMaster.Domain.Services.Interfaces;
using System.Xml;

namespace PetMaster.Domain.Services;
public class UserService(IUserRepository repository) : IUserService
{
    public async Task<Result> GetAllAsync()
    {
        var users = await repository.GetAllAsync();
        return new Result(true, users);
    }

    public async Task<Result> GetByIdAsync(Guid id)
    {
        var user = await repository.GetByIdAsync(id);
        return new Result(user is not null, user);
    }

    public async Task<Result> CreateAsync(User user)
    {
        user.RegistrationNumber = new Random().Next(100000, 999999).ToString();
        user.SetPassword(new Random().Next(100000, 999999).ToString());

        var userCreated = await repository.CreateAsync(user);
        return new Result(userCreated is not null, userCreated);
    }

    public async Task<Result> UpdateAsync(Guid id, User user)
    {
        var updated = await repository.UpdateAsync(id, user);
        return new Result(updated, updated ? "Usuário atualizado" : "Erro ao atualizar o usuário");
    }

    public async Task DeleteAsync(Guid id) => await repository.DeleteAsync(id);

    public async Task<Result> UpdatePasswordAsync(FirstAccessRequest request)
    {
        User? user = await repository.GetByRegistrationNumberAsync(request.RegistrationNumber);

        if (user is null) return new Result(false, $"Usuário com número de matrícula {request.RegistrationNumber}");;

        user.SetPassword(request.Password);

        var updated = await repository.UpdateAsync(user.Id, user);

        return new Result(updated, updated ? "Senha atualizada com sucesso" : "Erro ao atualizar a senha");
    }

    public async Task<Result> LoginAsync(LoginRequest request)
    {
        (bool canAccess, bool? firstAccess) = await repository.CanAccessAsync(request.RegistrationNumber, request.Password);
        if (!canAccess)
        {
            return new Result(false, "Número de matrícula ou senha inválidos", new LoginResponse
            {
                CanAccess = canAccess,
                FirstAccess = firstAccess
            });
        }

        return new Result(true, "Login realizado com sucesso", new LoginResponse
        {
            CanAccess = canAccess,
            FirstAccess = firstAccess
        });
    }
}
