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
        RouteGroupBuilder serviceGroup = app.MapGroup("servicos").WithTags("Servicos");

        serviceGroup.MapGet("/", async ([FromServices] IServiceService service) =>
        {
            var services = await service.GetAllAsync();
            return Results.Ok(services);
        })
        .WithName("GetServices")
        .WithOpenApi();

        serviceGroup.MapGet("/{id:guid}", async ([FromServices] IServiceService service, [FromRoute] Guid id) =>
        {
            var result = await service.GetByIdAsync(id);
            return result is not null ? Results.Ok(result) : Results.NotFound();
        })
        .WithName("GetServiceById")
        .WithOpenApi();

        serviceGroup.MapPost("/", async ([FromServices] IServiceService service, [FromBody] Service serv) =>
        {
            Service? created = await service.CreateAsync(serv);
            return Results.Created($"/servicos/{created.Id}", created);
        })
        .WithName("PostService")
        .WithOpenApi();

        serviceGroup.MapPut("/{id:guid}", async ([FromServices] IServiceService service, [FromRoute] Guid id, [FromBody] Service serv) =>
        {
            var updated = await service.UpdateAsync(id, serv);
            return updated ? Results.Ok(updated): Results.BadRequest();
        })
        .WithName("PutService")
        .WithOpenApi();

        serviceGroup.MapDelete("/{id:guid}", async ([FromServices] IServiceService service, [FromRoute] Guid id) =>
        {
            await service.DeleteAsync(id);
            return Results.NoContent();
        })
        .WithName("DeleteService")
        .WithOpenApi();
    }
}
