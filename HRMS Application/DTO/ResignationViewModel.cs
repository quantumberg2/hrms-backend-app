using HRMS_Application.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HRMS_Application.DTO
{
    public class ResignationViewModel
    {
        public Resignation Resignation { get; set; }
        public IEnumerable<SelectListItem> Reasons { get; set; }
    }
}
