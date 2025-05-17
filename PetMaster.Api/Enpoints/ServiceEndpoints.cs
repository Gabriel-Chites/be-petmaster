using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PetMaster.Domain.Entities;
using PetMaster.Domain.Services.Interfaces;
using System.Runtime.CompilerServices;

namespace PetMaster.Api.Enpoints;

public static class ServiceEndpoints
{
    public static void AddServiceEnpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/servicos", async ([FromServices] IServiceService service) =>
        {
            var services = await service.GetAllAsync();
            return Results.Ok(services);
        })
        .WithName("GetServices")
        .WithOpenApi();

        app.MapGet("/servicos/{id}", async ([FromServices] IServiceService service, [FromRoute] Guid id) =>
        {
            var result = await service.GetByIdAsync(id);
            return result is not null ? Results.Ok(result) : Results.NotFound();
        })
        .WithName("GetServiceById")
        .WithOpenApi();

        app.MapPost("/servicos", async ([FromServices] IServiceService service, [FromBody] Service serv) =>
        {
            var created = await service.CreateAsync(serv);
            return Results.Created($"/servicos/{created.Id}", created);
        })
        .WithName("PostService")
        .WithOpenApi();

        app.MapPut("/servicos", async ([FromServices] IServiceService service, [FromBody] Service serv) =>
        {
            var updated = await service.UpdateAsync(serv);
            return Results.Ok(updated);
        })
        .WithName("PutService")
        .WithOpenApi();

        app.MapDelete("/servicos/{id}", async ([FromServices] IServiceService service, Guid id) =>
        {
            await service.DeleteAsync(id);
            return Results.NoContent();
        })
        .WithName("DeleteService")
        .WithOpenApi();
    }
}
