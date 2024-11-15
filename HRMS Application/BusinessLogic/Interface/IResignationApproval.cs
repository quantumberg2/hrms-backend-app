using HRMS_Application.Models;

namespace HRMS_Application.BusinessLogic.Interface
{
    public interface IResignationApproval
    {
        public List<ResignationApprovalStatus> GetData();
        public string InsertResignation(ResignationApprovalStatus resignation);
        public string UpdateResignation(ResignationApprovalStatus resignation);
        public bool SoftDeleteResignation(int id, short isActive);
    }
}
