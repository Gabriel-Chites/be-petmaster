using Microsoft.AspNetCore.Mvc;
using PetMaster.Domain.Entities;
using PetMaster.Domain.Services.Interfaces;

namespace PetMaster.Api.Enpoints;

public static class UserEnpoints
{
    public static void AddUserEnpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/usuarios", async ([FromServices] IUserService service) =>
        {
            IEnumerable<User> users = await service.GetAllAsync();
            return Results.Ok(users);
        }).WithName("GetUsers")
          .WithOpenApi();

        app.MapPost("/usuarios", async ([FromServices] IUserService service, [FromBody] User user) =>
        {
            User? created = await service.CreateAsync(user);
            return Results.Created($"/usuarios/{created.Id}", created);
        }).WithName("PostUsers")
          .WithOpenApi();

        app.MapPut("/usuarios/", async ([FromServices] IUserService service, [FromBody] User user) =>
        {
            var updated = await service.UpdateAsync(user);
            return Results.Ok(updated);
        }).WithName("PutUsers")
          .WithOpenApi();

        app.MapDelete("/usuarios/", async ([FromServices] IUserService service, [FromRoute] Guid id) =>
        {
            await service.DeleteAsync(id);
            return Results.NoContent();
        }).WithName("DeleteUsers")
          .WithOpenApi();
    }
}
