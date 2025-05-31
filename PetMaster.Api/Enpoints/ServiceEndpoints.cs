using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PetMaster.Api.Models;
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
            var result = await service.GetAllAsync();
            return result.Success ? Results.Ok(result.Data) : Results.BadRequest(result.Message);
        })
        .WithName("GetServices")
        .WithOpenApi();

        serviceGroup.MapGet("/{id:guid}", async ([FromServices] IServiceService service, [FromRoute] Guid id) =>
        {
            var result = await service.GetByIdAsync(id);
            return result.Success && result.Data is not null ? Results.Ok(result.Data) : Results.NotFound();
        })
        .WithName("GetServiceById")
        .WithOpenApi();

        serviceGroup.MapPost("/", async ([FromServices] IServiceService service, [FromBody] ServiceModel serv) =>
        {
            var result = await service.CreateAsync((Service)serv);
            Service? created = null;
            if (result.Data is Service s)
                created = s;
            return result.Success ? Results.Created($"/servicos/{created!.Id}", created) : Results.BadRequest(result.Message);
        })
        .WithName("PostService")
        .WithOpenApi();

        serviceGroup.MapPut("/{id:guid}", async ([FromServices] IServiceService service, [FromRoute] Guid id, [FromBody] ServiceModel serv) =>
        {
            var result = await service.UpdateAsync(id, (Service)serv);
            return result.Success ? Results.Ok() : Results.BadRequest(result.Message);
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
