using ArtPromptChallenge.Models;
namespace ArtPromptChallenge.Controllers;

public static class PromptFieldsEndpoints {
    static string[] worlds = {
        "dystopian",
        "utopian",
        "chaotic",
        "peaceful",
        "corrupt",
        "ancient",
        "futuristic",
        "crime inferenced",
        "sci-fi",
        "real"
    };
    static string[] qualities = {
        "dangerous",
        "wild",
        "advanced",
        "lost",
        "flying",
        "armored",
        "walking",
        "magical",
        "broken",
        "beautiful",
        "luxuriuous",
        "dying"
    };
    static string[][] accentColors = {
        new string[] {"Gold", "#ffd700"},
        new string[] {"Chilli Pepper", "#c11b17"},
        new string[] {"Crystal Blue", "#5cb3ff"},
        new string[] {"Aquamarine", "#7fffd4"},
        new string[] {"Army Green", "#4b5320"},
        new string[] {"Neon Yellow", "#ffff33"},
        new string[] {"Caramel", "#c68e17"},
        new string[] {"Pumpkin Orange", "#f87217"},
        new string[] {"Rose Gold", "#ecc5c0"},
        new string[] {"Hot Deep Pink", "#f52887"},
        new string[] {"Magenta", "#ff00ff"},
        new string[] {"Cotton Candy", "#fcdfff"},
        new string[] {"Deep Emerald Green", "#046307"},
        new string[] {"Bronze", "#cd7f32"},
        new string[] {"Salmon", "#fa8072"},
        new string[] {"Lavender Blue", "#e3e4fa"},
        new string[] {"Egg Shell", "#fff9e3"},
        new string[] {"Brown Sand", "#ee9a4d"},
        new string[] {"Slime Green", "#bce954"},
        new string[] {"Polyfjord Blue", "#78c0ff"} // lol
    };
    static string[] motives = {
        "creature",
        "weapon",
        "toy",
        "vehicle",
        "robot",
        "city",
        "monster",
        "humanoid"
    };
    static string[] artStyles = {
        "pixelated/voxelated",
        "realistic",
        "low-detailed/low-poly",
        "abstract",
        "miniature",
        "isometric"
    };
    public static void MapPromptFieldsResponseModelEndpoints(this IEndpointRouteBuilder routes) {
        var rnd = new Random();
        T GetRndEntry<T>(T[] inp) {
            return inp[rnd.Next(0, inp.Length-1)];
        }
        routes.MapGet("/api/generate", () => {
            return new Dictionary<string, object>() {
                ["world"] = GetRndEntry(worlds),
                ["quality"] = GetRndEntry(qualities),
                ["accent_color"] = GetRndEntry(accentColors),
                ["motive"] = GetRndEntry(motives),
                ["art_style"] = GetRndEntry(artStyles)
            };
        })
        .WithName("generate")
        .Produces<PromptFieldsResponseModel[]>(StatusCodes.Status200OK);
    }
}
