using System;
using System.Net.Http.Headers;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using MongoDB.Bson;
using MongoDB.Driver;
using NuGet.Common;

namespace ArtPromptChallenge.Controllers.API {
    [Route("/api/generators")]
    [ApiController]
    public class AddGenerator : ControllerBase {
        bool ValidateToken(string token) {
            var d = new Dictionary<string, object>();
            var coll = Config.Database.GetCollection<BsonDocument>("apitokens");
            var cur = coll.FindSync(new BsonDocument("token", token));
            try {
                foreach (var a in cur.First().ToDictionary()) {
                    d[a.Key] = a.Value;
                }
            } catch (InvalidOperationException) {
                return false;
            }
            var createdAtTime = DateTime.Parse(d["created"] as string);
            var expriresAfter = (int)d["lifetime"];
            if (expriresAfter != 0)
                if (createdAtTime.AddSeconds(expriresAfter) - DateTime.UtcNow < TimeSpan.Zero)
                    return false;
            return true;
        }
        [Route("add")]
        [HttpPost]
        public async Task<IActionResult> GenerateArtPrompt() {
            var headerres = !Request.Headers.TryGetValue("Authorization", out StringValues header);
            var valtok = !ValidateToken(header);
            if (headerres || valtok) {
                return Unauthorized(new Dictionary<string, object>() {
                    ["error"] = "4003",
                    ["message"] = "provide \"Authorization\" header with valid token and repeat your request " + headerres.ToString() + " " + valtok.ToString()
                });
            }
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var genId = new string(Enumerable.Repeat(chars, 10).Select(s => s[new Random().Next(s.Length)]).ToArray());
            var coll = Config.Database.GetCollection<BsonDocument>("prompts");
            using var sr = new StreamReader(Request.Body);
            var doc = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, object>>(sr.ReadToEnd());
            doc["_id"] = genId;
            try {
                await coll.InsertOneAsync(BsonDocument.Parse(System.Text.Json.JsonSerializer.Serialize(doc)));
            } catch (MongoWriteException) {
                return Conflict(new Dictionary<string, object>() {
                    ["error"] = "4009",
                    ["message"] = "generator with this ID already exists"
                });
            }
            return Created(Request.Host.Value+"/api/prompts/generate?genId="+genId, "asd");
        }
    }
}
