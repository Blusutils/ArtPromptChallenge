namespace ArtPromptChallenge {
    public static class Config {
        public static MongoDB.Driver.MongoClient MongoClient { get; set; } = new("mongodb://localhost:27017");
        public static MongoDB.Driver.IMongoDatabase Database { get; set; } = MongoClient.GetDatabase("artpromptchallenge");
        public static class Api {
            public static class PromptGen {
                public static class RatelimitDefaults {
                    public static TimeSpan TimeoutGenerator = new TimeSpan(0, 0, 1);
                }
            }
        }
    }
}
