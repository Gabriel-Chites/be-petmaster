using Microsoft.AspNetCore.Mvc;
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
            IEnumerable<Product> products = await service.GetAllAsync();
            return Results.Ok(products);
        }).WithName("GetProducts")
          .WithOpenApi();

        serviceGroup.MapGet("/{id:guid}", async ([FromServices] IProductService service, [FromRoute] Guid id) =>
        {
            Product? product = await service.GetByIdAsync(id);
            return product is not null ? Results.Ok(product) : Results.NotFound();
        }).WithName("GetProductById")
          .WithOpenApi();

        serviceGroup.MapPost("/", async ([FromServices] IProductService service, [FromBody] Product product) =>
        {
            Product? created = await service.CreateAsync(product);
            return created is not null ? Results.Created($"/servicos/{created.Id}", created) : Results.BadRequest();
        }).WithName("PostProduct")
          .WithOpenApi();

        serviceGroup.MapPut("/{id:guid}", async ([FromServices] IProductService service, [FromRoute] Guid id, [FromBody] Product product) =>
        {
            var updated = await service.UpdateAsync(id, product);
            return updated ? Results.Ok() : Results.BadRequest();
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
