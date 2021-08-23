using System;
using System.Text.Json.Serialization;

namespace otel_dotnet
{
    public class Vocab
    {
        [JsonPropertyName("word")]
        public string Word { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}