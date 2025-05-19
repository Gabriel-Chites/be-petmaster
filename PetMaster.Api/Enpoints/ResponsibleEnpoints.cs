using Microsoft.AspNetCore.Mvc;
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
            IEnumerable<Responsible> responsibles = await service.GetAllAsync();
            return Results.Ok(responsibles);
        }).WithName("GetResponsible")
          .WithOpenApi();

        serviceGroup.MapGet("/{id}", async ([FromServices] IResponsibleService service, [FromRoute] Guid id) =>
        {
            Responsible? responsible = await service.GetByIdAsync(id);
            return responsible is not null ? Results.Ok(responsible) : Results.NotFound();
        }).WithName("GetResponsibleById")
          .WithOpenApi();

        serviceGroup.MapPost("/", async ([FromServices] IResponsibleService service, [FromBody] Responsible responsable) =>
        {
            Responsible? created = await service.CreateAsync(responsable);
            return created is not null ? Results.Created($"/servicos/{created.Id}", created) : Results.BadRequest();
        }).WithName("PostResponsible")
          .WithOpenApi();

        serviceGroup.MapPut("/{id}", async ([FromServices] IResponsibleService service, [FromRoute] Guid id, [FromBody] Responsible responsable) =>
        {
            var updated = await service.UpdateAsync(id, responsable);
            return updated ? Results.Ok() : Results.BadRequest();
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
