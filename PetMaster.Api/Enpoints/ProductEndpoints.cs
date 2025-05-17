namespace PetMaster.Api.Enpoints;

public static class ProductEndpoints
{
    public static void AddProductEnpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/produtos", () =>
        {
            return Results.Ok();
        }).WithName("GetProducts")
          .WithOpenApi(); ;

        app.MapPost("/produtos", () =>
        {
            return Results.Ok();
        }).WithName("PostProduct")
          .WithOpenApi(); ;

        app.MapPut("/produtos", () =>
        {
            return Results.Ok();
        }).WithName("PutProduct")
          .WithOpenApi(); ;

        app.MapDelete("/produtos", () =>
        {
            return Results.Ok();
        }).WithName("DeleteProduct")
          .WithOpenApi(); ;
    }
}
