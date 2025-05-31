using Microsoft.AspNetCore.Mvc;
using PetMaster.Api.Models;
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
            var result = await service.GetAllAsync();
            return result.Success ? Results.Ok(result.Data) : Results.BadRequest(result.Message);
        }).WithName("GetPets")
          .WithOpenApi();

        serviceGroup.MapGet("/{id:guid}", async([FromServices] IPetService service, [FromRoute] Guid id) =>
        {
            var result = await service.GetByIdAsync(id);
            return result.Success && result.Data is not null ? Results.Ok(result.Data) : Results.NotFound();
        }).WithName("GetPetById")
         .WithOpenApi();

        serviceGroup.MapPost("/", async([FromServices] IPetService service, [FromBody] PetModel pet) =>
        {
            var result = await service.CreateAsync((Pet)pet);
            Pet? created = null;
            if (result.Data is Pet p)
                created = p;
            return result.Success ? Results.Created($"/pet/{created!.Id}", created) : Results.BadRequest(result.Message);
        }).WithName("PostPet")
          .WithOpenApi();

        serviceGroup.MapPut("/{id:guid}", async([FromServices] IPetService service, [FromRoute] Guid id, [FromBody] PetModel pet) =>
        {
            var result = await service.UpdateAsync(id, (Pet)pet);
            return result.Success ? Results.Ok() : Results.BadRequest(result.Message);
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
