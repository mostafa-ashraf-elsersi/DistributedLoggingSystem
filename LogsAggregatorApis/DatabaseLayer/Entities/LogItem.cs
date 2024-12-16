using LogsAggregatorApis.DatabaseLayer.BaseEntityType;
using System.Text.Json.Serialization;

namespace LogsAggregatorApis.DatabaseLayer.Entities
{
    public class LogItem : BaseEntity<string>
    {
        [JsonPropertyName("@t")]
        public DateTime Timestamp { get; set; }

        [JsonPropertyName("@mt")]
        public string MessageTemplate { get; set; } = string.Empty;

        [JsonPropertyName("@l")]
        public string Level { get; set; } = string.Empty;

        [JsonPropertyName("@x")]
        public string Exception { get; set; } = string.Empty;

        [JsonPropertyName("@tr")]
        public string TraceId { get; set; } = string.Empty;

        [JsonPropertyName("@sp")]
        public string SpanId { get; set; } = string.Empty; 

        public string RequestPath { get; set; } = string.Empty;

        public string RequestMethod { get; set; } = string.Empty;

        public int StatusCode { get; set; }

        public double Elapsed { get; set; }

        public string SourceContext { get; set; } = string.Empty;

        public string RequestId { get; set; } = string.Empty;

        public string ConnectionId { get; set; } = string.Empty;

        public string MachineName { get; set; } = string.Empty;

        public int ThreadId { get; set; }
    }
}
