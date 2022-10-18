using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ArtPromptChallenge.Controllers.API {
    [Route("/api/prompts")]
    [ApiController]
    public class PromptGen : ControllerBase {
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
        List<Dictionary<string, object>> cache = new List<Dictionary<string, object>>();
        [Route("generate")]
        public async Task<IActionResult> GenerateArtPrompt(string genId = "0") {
            var trg = cache.Find((o) => { return o["_id"] as string == genId; });
            if (trg == null) {
                var d = new Dictionary<string, object>();
                var coll = Config.Database.GetCollection<BsonDocument>("prompts");
                var cur = await coll.FindAsync(new BsonDocument("_id", genId));
                try {
                    foreach (var a in cur.First().ToDictionary()) {
                        d[a.Key] = a.Value;
                    }
                } catch (InvalidOperationException) {
                    return NotFound("{\"error\":4004,\"message\":\"unable to find generator with id " + genId + "\"}");
                }
                cache.Add(d);
            }
            var rnd = new Random();
            T GetRndEntry<T>(T[] inp) {
                return inp[rnd.Next(0, inp.Length-1)];
            }
            trg = cache.Find((o) => { return o["_id"] as string == genId; });
            // if doc not found
            if (trg == null) {
                return NotFound("{\"error\":4004,\"message\":\"unable to find generator with id " + genId + "\"}");
            }
            Dictionary<string, object> outDict = new();
            outDict["variants"] = new Dictionary<string, object>();
            foreach (var kv in (trg["variants"] as Dictionary<string, object>)["original"] as Dictionary<string, object>) {
                (outDict["variants"] as Dictionary<string, object>)[kv.Key] = GetRndEntry(kv.Value as object[]);
            }
            outDict["templateString"] = trg["templateString"] as string;
            return Ok(outDict);
        }
    }
}
