using System.ComponentModel.DataAnnotations;

namespace HRMS_Application.Enums
{
        public enum ResignationReason
        {
            [Display(Name = "Contract Expiry")]
            ContractExpiry,

            [Display(Name = "Personal Reason")]
            PersonalReason,

            [Display(Name = "Health Issues")]
            HealthIssues
        }

}
