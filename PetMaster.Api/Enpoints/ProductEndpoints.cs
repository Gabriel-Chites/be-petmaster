using Microsoft.AspNetCore.Mvc;
using PetMaster.Api.Models;
using PetMaster.Domain.Entities;
using PetMaster.Domain.Services.Interfaces;

namespace PetMaster.Api.Enpoints;

public static class ProductEndpoints
{
    public static void AddProductEnpoints(this IEndpointRouteBuilder app)
    {
        RouteGroupBuilder serviceGroup = app.MapGroup("produtos").WithTags("Produtos");

        serviceGroup.MapGet("/", async ([FromServices] IProductService service) =>
        {
            var result = await service.GetAllAsync();
            return Results.Ok(result.Data);
        }).WithName("GetProducts")
          .WithOpenApi();

        serviceGroup.MapGet("/{id:guid}", async ([FromServices] IProductService service, [FromRoute] Guid id) =>
        {
            var result = await service.GetByIdAsync(id);
            return result.Data is not null ? Results.Ok((Product)result.Data) : Results.NotFound();
        }).WithName("GetProductById")
          .WithOpenApi();

        serviceGroup.MapPost("/", async ([FromServices] IProductService service, [FromBody] ProductModel product) =>
        {
            var result = await service.CreateAsync((Product)product);
            Product? productCreated = null;

            if (result.Data is Product p)
                productCreated = p;

            return result.Success ? Results.Created($"/servicos/{productCreated!.Id}", productCreated) : Results.BadRequest();
        }).WithName("PostProduct")
          .WithOpenApi();

        serviceGroup.MapPut("/{id:guid}", async ([FromServices] IProductService service, [FromRoute] Guid id, [FromBody] ProductModel product) =>
        {
            var updated = await service.UpdateAsync(id, (Product)product);
            return updated.Success ? Results.Ok() : Results.BadRequest();
        }).WithName("PutProduct")
          .WithOpenApi();

        serviceGroup.MapDelete("/{id:guid}", async ([FromServices] IProductService service, [FromRoute] Guid id) =>
        {
            await service.DeleteAsync(id);
            return Results.Ok();
        }).WithName("DeleteProduct")
          .WithOpenApi();
    }
}
