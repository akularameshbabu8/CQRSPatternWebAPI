namespace Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class Film : BaseEntity
    {
        [JsonPropertyName("Title")]
        public string Title { get; set; }        
        [JsonPropertyName("episode_id")]
        public int EpisodeId { get; set; }
        [JsonPropertyName("opening_crawl")]
        public string OpeningCrawl { get; set; }
        [JsonPropertyName("director")]
        public string Director { get; set; }
        [JsonPropertyName("producer")]
        public string Producer { get; set; }
        [JsonPropertyName("release_date")]
        public string ReleaseDate { get; set; }
        [JsonPropertyName("species")]
        public ICollection<string> Species { get; set; }
        [JsonPropertyName("starships")]
        public ICollection<string> Starships { get; set; }
        [JsonPropertyName("vehicles")]
        public ICollection<string> Vehicles { get; set; }
        [JsonPropertyName("characters")]
        public ICollection<string> Characters { get; set; }
        [JsonPropertyName("planets")]
        public ICollection<string> Planets { get; set; }
       

    }
}