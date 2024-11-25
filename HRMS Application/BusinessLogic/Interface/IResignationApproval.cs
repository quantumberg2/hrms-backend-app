using HRMS_Application.Models;

namespace HRMS_Application.BusinessLogic.Interface
{
    public interface IResignationApproval
    {
        public List<ResignationApprovalStatus> GetData();
        public string InsertResignation(ResignationApprovalStatus resignation);
        public string UpdateResignation(ResignationApprovalStatus resignation);
        public string UpdateManagerApprovalStatus(int empCredId, int id, string managerApprovalstatus);
        //public string UpdateAdminApprovalStatus(int empCredId,int id, string adminApprovalStatus);
        public bool SoftDeleteResignation(int id, short isActive);
    }
}
