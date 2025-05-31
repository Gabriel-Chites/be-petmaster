using Microsoft.AspNetCore.Mvc;
using PetMaster.Api.Models;
using PetMaster.Domain.Entities;
using PetMaster.Domain.Services.Interfaces;

namespace PetMaster.Api.Enpoints;

public static class ResponsibleEnpoints
{
    public static void AddResponsibleEnpoints(this IEndpointRouteBuilder app)
    {
        RouteGroupBuilder serviceGroup = app.MapGroup("responsavel").WithTags("Responsáveis");

        serviceGroup.MapGet("/", async ([FromServices] IResponsibleService service) =>
        {
            var result = await service.GetAllAsync();
            return Results.Ok(result.Data);
        }).WithName("GetResponsible")
          .WithOpenApi();

        serviceGroup.MapGet("/{id}", async ([FromServices] IResponsibleService service, [FromRoute] Guid id) =>
        {
            var result = await service.GetByIdAsync(id);
            return result.Success ? Results.Ok(result.Data!) : Results.NotFound();
        }).WithName("GetResponsibleById")
          .WithOpenApi();

        serviceGroup.MapPost("/", async ([FromServices] IResponsibleService service, [FromBody] ResponsibleModel responsible) =>
        {
            var result = await service.CreateAsync((Responsible)responsible);
            Responsible? responsibleCreated = null;

            if (result.Data is Responsible r)
                responsibleCreated = r;

            return result.Success? Results.Created($"/servicos/{responsibleCreated!.Id}", responsibleCreated) : Results.BadRequest();
        }).WithName("PostResponsible")
          .WithOpenApi();

        serviceGroup.MapPut("/{id}", async ([FromServices] IResponsibleService service, [FromRoute] Guid id, [FromBody] ResponsibleModel responsable) =>
        {
            var result = await service.UpdateAsync(id, (Responsible)responsable);
            return result.Success ? Results.Ok() : Results.BadRequest();
        }).WithName("PutResponsible")
          .WithOpenApi();

        serviceGroup.MapDelete("/{id}", async ([FromServices] IResponsibleService service, [FromRoute] Guid id) =>
        {
            await service.DeleteAsync(id);
            return Results.Ok();
        }).WithName("DeleteResponsible")
          .WithOpenApi();
    }
}
