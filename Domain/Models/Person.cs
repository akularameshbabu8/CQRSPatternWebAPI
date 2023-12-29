using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace Domain.Models
{
    public class Person : BaseEntity
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
       
        [JsonPropertyName( "birth_year")]
        public string BirthYear { get; set; }
        
        [JsonPropertyName("eye_color")]
        public string EyeColor { get; set; }        
        [JsonPropertyName("gender")]
        public string Gender { get; set; }
        [JsonPropertyName("hair_color")]        
        public string HairColor { get; set; }       
        [JsonPropertyName("height")]
        public string Height { get; set; }
        [JsonPropertyName("mass")]
        public string Mass { get; set; }       
        [JsonPropertyName("skin_color")]
        public string SkinColor { get; set; }        
        [JsonPropertyName("homeworld")]
        public string Homeworld { get; set; }        
        [JsonPropertyName("films")]
        public ICollection<string> Films { get; set; }        
        [JsonPropertyName("species")]
        public ICollection<string> Species { get; set; }        
        [JsonPropertyName("starships")]
        public ICollection<string> Starships { get; set; }        
        [JsonPropertyName("vehicles")]
        public ICollection<string> Vehicles { get; set; }  
    }
}