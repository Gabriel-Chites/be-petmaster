using Microsoft.AspNetCore.Mvc;
using PetMaster.Domain.Entities;
using PetMaster.Domain.Services.Interfaces;

namespace PetMaster.Api.Enpoints;

public static class PetEnpoints
{
    public static void AddPetEnpoints(this IEndpointRouteBuilder app)
    {
        RouteGroupBuilder serviceGroup = app.MapGroup("pet").WithTags("Pet");

        serviceGroup.MapGet("/", async ([FromServices] IPetService service) =>
        {
            IEnumerable<Pet> pets = await service.GetAllAsync();
            return Results.Ok(pets);
        }).WithName("GetPets")
          .WithOpenApi();

        serviceGroup.MapGet("/{id:guid}", async([FromServices] IPetService service, [FromRoute] Guid id) =>
        {
            Pet? pet = await service.GetByIdAsync(id);
            return pet is not null ? Results.Ok(pet) : Results.NotFound();
        }).WithName("GetPetById")
         .WithOpenApi();

        serviceGroup.MapPost("/", async([FromServices] IPetService service, [FromBody] Pet pet) =>
        {
            Pet? created = await service.CreateAsync(pet);
            return created is not null ? Results.Created($"/servicos/{created.Id}", created) : Results.BadRequest();
        }).WithName("PostPet")
          .WithOpenApi();

        serviceGroup.MapPut("/{id:guid}", async([FromServices] IPetService service, [FromRoute] Guid id, [FromBody] Pet pet) =>
        {
            var updated = await service.UpdateAsync(id, pet);
            return updated ? Results.Ok() : Results.BadRequest();
        }).WithName("PutPet")
          .WithOpenApi();

        serviceGroup.MapDelete("/{id:guid}", async([FromServices] IPetService service, [FromRoute] Guid id) =>
        {
            await service.DeleteAsync(id);
            return Results.Ok();
        }).WithName("DeletePet")
          .WithOpenApi();
    }
}
