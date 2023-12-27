using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    namespace Domain.Models
    {
        using System.Collections.Generic;
        using Newtonsoft.Json;

             
        public class PersonViewModel 
        {  
            [JsonProperty]
            public string Name { get; set; }
           
            [JsonProperty(PropertyName = "birth_year")]
            public string BirthYear { get; set; }           
            [JsonProperty(PropertyName = "eye_color")]
            public string EyeColor { get; set; }            
            [JsonProperty]
            public string Gender { get; set; }
            
            [JsonProperty(PropertyName = "hair_color")]
            public string HairColor { get; set; }           
            [JsonProperty]
            public string Height { get; set; }            
            [JsonProperty]
            public string Mass { get; set; }            
            [JsonProperty(PropertyName = "skin_color")]
            public string SkinColor { get; set; }             
            [JsonProperty]
            public int filmsCount { get; set; }                 
            [JsonProperty]
            public int starshipsCount { get; set; }           
            [JsonProperty]
            public int vehiclesCount { get; set; }            
        }
    }

}