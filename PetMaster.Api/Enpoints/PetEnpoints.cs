namespace PetMaster.Api.Enpoints;

public static class PetEnpoints
{
    public static void AddPetEnpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/pet", () =>
        {
            return Results.Ok();
        }).WithName("GetPets")
          .WithOpenApi(); ;

        app.MapPost("/pet", () =>
        {
            return Results.Ok();
        }).WithName("PostPet")
          .WithOpenApi(); ;

        app.MapPut("/pet", () =>
        {
            return Results.Ok();
        }).WithName("PutPet")
          .WithOpenApi(); ;

        app.MapDelete("/pet", () =>
        {
            return Results.Ok();
        }).WithName("DeletePet")
          .WithOpenApi(); ;
    }
}
