namespace Domain.Models
{
    using System;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    public abstract class BaseEntity
    {
        [JsonPropertyName("url")]
        public string Url { get; set; }
        [JsonPropertyName("created")]
        public DateTime Created { get; set; }
        [JsonPropertyName("edited")]
        public DateTime Edited { get; set; }
       
    }
}