using ArtPromptChallenge.Models;
namespace ArtPromptChallenge.Controllers;

public static class PromptFieldsEndpoints
{
    public static void MapPromptFieldsResponseModelEndpoints (this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/generate", () =>
        {
            return new [] { new PromptFieldsResponseModel { world = "" } };
        })
        .WithName("generate")
        .Produces<PromptFieldsResponseModel[]>(StatusCodes.Status200OK);
    }
}
