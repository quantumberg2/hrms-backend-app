
using System.Text.Json;

namespace HRMS_Application.Models
{
    public class ErrorResponse
    {
        public int StatusCode { get; set; }
        public String? Message { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }

    }
}
