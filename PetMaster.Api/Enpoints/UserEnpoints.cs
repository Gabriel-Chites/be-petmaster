using Microsoft.AspNetCore.Mvc;
using PetMaster.Api.Models;
using PetMaster.Domain.Entities;
using PetMaster.Domain.Request;
using PetMaster.Domain.Services.Interfaces;

namespace PetMaster.Api.Enpoints;

public static class UserEnpoints
{
    public static void AddUserEnpoints(this IEndpointRouteBuilder app)
    {
        RouteGroupBuilder serviceGroup = app.MapGroup("usuarios").WithTags("Usuários");

        serviceGroup.MapGet("/", async ([FromServices] IUserService service) =>
        {
            var result = await service.GetAllAsync();
            return result.Success ? Results.Ok(result.Data) : Results.BadRequest(result.Message);
        }).WithName("GetUsers")
          .WithOpenApi();

        serviceGroup.MapGet("/{id:guid}", async ([FromServices] IUserService service, [FromRoute] Guid id) =>
        {
            var result = await service.GetByIdAsync(id);
            return result.Success && result.Data is not null ? Results.Ok(result.Data) : Results.NotFound();
        }).WithName("GetUserById")
          .WithOpenApi();

        serviceGroup.MapPost("/", async ([FromServices] IUserService service, [FromBody] UserModel user) =>
        {
            var result = await service.CreateAsync((User)user);
            User? created = null;
            if (result.Data is User u)
                created = u;
            return result.Success ? Results.Created($"/usuarios/{created!.Id}", created) : Results.BadRequest(result.Message);
        }).WithName("PostUsers")
          .WithOpenApi();

        serviceGroup.MapPut("/{id:guid}", async ([FromServices] IUserService service, [FromRoute] Guid id, [FromBody] UserModel user) =>
        {
            var result = await service.UpdateAsync(id, (User)user);
            return result.Success ? Results.Ok() : Results.BadRequest(result.Message);
        }).WithName("PutUsers")
          .WithOpenApi();

        serviceGroup.MapPut("primeiroAcesso", async ([FromServices] IUserService service, [FromBody] FirstAccessRequest request) =>
        {
            var result = await service.UpdatePasswordAsync(request);
            return result.Success ? Results.Ok() : Results.BadRequest(result.Message);
        }).WithName("FirstAccessUsers")
          .WithOpenApi();

        serviceGroup.MapPut("login", async ([FromServices] IUserService service, [FromBody] LoginRequest request) =>
        {
            var result = await service.LoginAsync(request);
            return result.Success ? Results.Ok(result) : Results.BadRequest(result);
        }).WithName("Login")
          .WithOpenApi();

        serviceGroup.MapDelete("/{id:guid}", async ([FromServices] IUserService service, [FromRoute] Guid id) =>
            {
                await service.DeleteAsync(id);
                return Results.NoContent();
            }).WithName("DeleteUsers")
              .WithOpenApi();
    }
}
