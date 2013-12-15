using Newtonsoft.Json;

namespace DailyLog.Domain
{
    public class LogItem
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("number")]
        public int Number { get; set; }
    }
}