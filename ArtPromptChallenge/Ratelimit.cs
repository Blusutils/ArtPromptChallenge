using System.Net;

namespace ArtPromptChallenge {
    public enum RatelimitUnit {
        Second,
        Minute,
        Hour,
        Day,
        Total
    }
    public class Ratelimit {
        public static List<Ratelimit> Ratelimits { get; set; } = new();

        public string Id { get; set; } = "";
        public IPAddress Ip { get; set; } = null;
        public uint MaxRequests { get; set; } = 0;
        public RatelimitUnit MaxRequestsPer { get; set; } = RatelimitUnit.Total;
        public TimeSpan Timeout { get; set; } = TimeSpan.Zero;
        public List<DateTime> RequestHistory { get; set; } = new();

        public static Ratelimit Get(string id) {
            foreach (var ratelimit in Ratelimits) if (ratelimit.Id == id) return ratelimit;
            return null;
        }
        public static Ratelimit Get(IPAddress ip) {
            foreach (var ratelimit in Ratelimits) if (ratelimit.Ip == ip) return ratelimit;
            return null;
        }
        public bool IsRatelimited() {
            var now = DateTime.UtcNow;
            uint requestsDone = 0;
            foreach (var record in RequestHistory) {
                if (Timeout != TimeSpan.Zero) {
                    if (now - record > Timeout) {
                        RequestHistory.Remove(record);
                        continue;
                    } else return true;
                } else if (MaxRequests != 0) {
                    var c = now - record;
                    switch (MaxRequestsPer) {
                        case RatelimitUnit.Second:
                            if (c > new TimeSpan(0, 0, 1)) {
                                RequestHistory.Remove(record);
                                continue;
                            }
                            break;
                        case RatelimitUnit.Minute:
                            if (c > new TimeSpan(0, 1, 0)) {
                                RequestHistory.Remove(record);
                                continue;
                            }
                            break;
                        case RatelimitUnit.Hour:
                            if (c > new TimeSpan(1, 0, 0)) {
                                RequestHistory.Remove(record);
                                continue;
                            }
                            break;
                        case RatelimitUnit.Day:
                            if (c > new TimeSpan(24, 0, 0)) {
                                RequestHistory.Remove(record);
                                continue;
                            }
                            break;
                    }
                    if (++requestsDone >= MaxRequests) return true;
                }
            }
            return false;
        }
    }
}
