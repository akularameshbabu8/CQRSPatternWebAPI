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

        /// <summary>
        /// Class Person.
        /// </summary>
        /// <seealso cref="CQRSPatternWebAPI.BaseEntity" />
        public class PersonViewModel 
        {           

            /// <summary>
            /// Gets or sets the name.
            /// </summary>
            /// <value>The name.</value>
            [JsonProperty]
            public string Name { get; set; }

            /// <summary>
            /// Gets or sets the birth year. It can return "unknown" as value.
            /// </summary>
            /// <value>The birth year.</value>
            [JsonProperty(PropertyName = "birth_year")]
            public string BirthYear { get; set; }

            /// <summary>
            /// Gets or sets the color of the eye. It can return "unknown" as value.
            /// </summary>
            /// <value>The color of the eye.</value>
            [JsonProperty(PropertyName = "eye_color")]
            public string EyeColor { get; set; }

            /// <summary>
            /// Gets or sets the gender. It can return "n/a" as value
            /// </summary>
            /// <value>The gender.</value>
            [JsonProperty]
            public string Gender { get; set; }

            /// <summary>
            /// Gets or sets the color of the hair. It can return "unknown" as value.
            /// </summary>
            /// <value>The color of the hair.</value>
            [JsonProperty(PropertyName = "hair_color")]
            public string HairColor { get; set; }

            /// <summary>
            /// Gets or sets the height. It can return "unknown" as value.
            /// </summary>
            /// <value>The height.</value>
            [JsonProperty]
            public string Height { get; set; }

            /// <summary>
            /// Gets or sets the mass. It can return "unknown" as value.
            /// </summary>
            /// <value>The mass.</value>
            [JsonProperty]
            public string Mass { get; set; }

            /// <summary>
            /// Gets or sets the color of the skin. It can return "unknown" as value.
            /// </summary>
            /// <value>The color of the skin.</value>
            [JsonProperty(PropertyName = "skin_color")]
            public string SkinColor { get; set; }
             /// <summary>
            /// Gets or sets the films URLs.
            /// </summary>
            /// <value>The films.</value>
            [JsonProperty]
            public int filmsCount { get; set; }
                       
            /// <summary>
            /// Gets or sets the star ships URLs.
            /// </summary>
            /// <value>The star ships.</value>
            [JsonProperty]
            public int starshipsCount { get; set; }

            /// <summary>
            /// Gets or sets the vehicles URLs.
            /// </summary>
            /// <value>The vehicles.</value>
            [JsonProperty]
            public int vehiclesCount { get; set; }
            
        }
    }

}
