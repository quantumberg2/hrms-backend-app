using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HRMS_Application.DTO
{
    public class ResignationDTO
    {
        public string Reason { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ExitDate { get; set; }
        public string? Comments { get; set; }
        public string PersonalEmailAddress { get; set; }
    }
}
