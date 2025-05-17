namespace PetMaster.Api.Enpoints;

public static class ResponsibleEnpoints
{
    public static void AddResponsibleEnpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/responsavel", () =>
        {
            return Results.Ok();
        }).WithName("GetResponsible")
          .WithOpenApi(); ;

        app.MapPost("/responsavel", () =>
        {
            return Results.Ok();
        }).WithName("GetResponsible")
          .WithOpenApi(); ;

        app.MapPut("/responsavel", () =>
        {
            return Results.Ok();
        }).WithName("GetResponsible")
          .WithOpenApi(); ;

        app.MapDelete("/responsavel", () =>
        {
            return Results.Ok();
        }).WithName("GetResponsible")
          .WithOpenApi(); ;
    }
}
