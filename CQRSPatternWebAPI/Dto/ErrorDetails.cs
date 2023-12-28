using System.Text.Json;

namespace CQRSPatternWebAPI.Dto
{
    public class ErrorDetails
    {
        public int statusCode { get; set; }
        public string message { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
