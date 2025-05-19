using Microsoft.AspNetCore.Mvc;
using PetMaster.Domain.Entities;
using PetMaster.Domain.Services.Interfaces;

namespace PetMaster.Api.Enpoints;

public static class UserEnpoints
{
    public static void AddUserEnpoints(this IEndpointRouteBuilder app)
    {
        RouteGroupBuilder serviceGroup = app.MapGroup("usuarios").WithTags("Usuários");

        serviceGroup.MapGet("/", async ([FromServices] IUserService service) =>
        {
            IEnumerable<User> users = await service.GetAllAsync();
            return Results.Ok(users);
        }).WithName("GetUsers")
          .WithOpenApi();

        serviceGroup.MapGet("/{id:guid}", async ([FromServices] IUserService service, [FromRoute] Guid id) =>
        {
            User? user = await service.GetByIdAsync(id);
            return user is not null ? Results.Ok(user) : Results.NotFound();
        }).WithName("GetUserById")
          .WithOpenApi();

        serviceGroup.MapPost("/", async ([FromServices] IUserService service, [FromBody] User user) =>
        {
            User? created = await service.CreateAsync(user);
            return created is not null ? Results.Created($"/usuarios/{created.Id}", created) : Results.BadRequest();
        }).WithName("PostUsers")
          .WithOpenApi();

        serviceGroup.MapPut("/{id:guid}", async ([FromServices] IUserService service, [FromRoute] Guid id, [FromBody] User user) =>
        {
            bool updated = await service.UpdateAsync(id, user);
            return updated ? Results.Ok() : Results.BadRequest();
        }).WithName("PutUsers")
          .WithOpenApi();

        serviceGroup.MapDelete("/{id:guid}", async ([FromServices] IUserService service, [FromRoute] Guid id) =>
        {
            await service.DeleteAsync(id);
            return Results.NoContent();
        }).WithName("DeleteUsers")
          .WithOpenApi();
    }
}
