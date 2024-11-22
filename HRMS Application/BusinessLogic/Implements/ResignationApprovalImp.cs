using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.Models;
using OfficeOpenXml;

namespace HRMS_Application.BusinessLogic.Implements
{
    public class ResignationApprovalImp :IResignationApproval
    {
        private readonly HRMSContext _context;
        public ResignationApprovalImp(HRMSContext context)
        {
            _context = context;
        }

        public List<ResignationApprovalStatus> GetData()
        {
            var res = (from row in _context.ResignationApprovalStatuses
                       where row.IsActive == 1
                       select row).ToList();
            return res;
        }

        public string InsertResignation(ResignationApprovalStatus resignation)
        {
            var res = _context.ResignationApprovalStatuses.Add(resignation);
            if(res!=null)
            {
                _context.SaveChanges();
                return "Successfully inserted resignation approval data";
            }
            else
            {
                return "failed to insert resignation approval data";
            }
        }

        public bool SoftDeleteResignation(int id, short isActive)
        {
            var res = (from row in _context.ResignationApprovalStatuses
                       where row.Id == id && row.IsActive == isActive
                       select row).FirstOrDefault();
            if (res != null)
            {
                res.IsActive = isActive;
                _context.ResignationApprovalStatuses.Update(res);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        //public string UpdateAdminApprovalStatus(int id, string adminApprovalStatus)
        //{
        //    var res = (from row in _context.Resignations
        //                 where row.Id == id
        //                 select row).FirstOrDefault();
        //    if (res != null)
        //    {
        //        res.Status = adminApprovalStatus;

        //        var ResigApptable = (from row in _context.ResignationApprovalStatuses
        //                             where row.Id == id
        //                             select row).FirstOrDefault();
        //        if (ResigApptable != null)
        //        {
        //            if(ResigApptable.AdminApprovalStatus=="Approved" && ResigApptable.ManagerApprovalStatus=="Approved")
        //            {
        //                res.Status = "Approved";
        //                res.UpdatedDate = DateTime.Now;
        //                _context.Resignations.Update(res);
        //                _context.SaveChanges();
        //            }
        //        }
        //        return "Admin approval status updated";


        //    }
        //    else
        //        return "failed to update admin approval";        
        //}

        public string UpdateManagerApprovalStatus(int empCredId, int id, string managerApprovalStatus)
        {
            var resignation = _context.ResignationApprovalStatuses.FirstOrDefault(r => r.Id == id);
            if (resignation == null)
                return "Failed: Resignation record not found.";

            var employee = _context.EmployeeDetails.FirstOrDefault(e => e.EmployeeCredentialId == empCredId);
            if (employee == null)
                return "Failed: Employee not found.";

           /* var position = employee.PositionId.HasValue
                ? _context.Positions.FirstOrDefault(p => p.Id == employee.PositionId)
                : null;

            if (position == null || position.Name != "Manager")
                return "Unauthorized: Only Managers can approve.";*/

            // Update manager approval status
            resignation.ManagerApprovalStatus = managerApprovalStatus;
            _context.SaveChanges();

            return "Manager approval status updated successfully.";
        }



        public string UpdateResignation(ResignationApprovalStatus resignation)
        {
            var res = (from row in _context.ResignationApprovalStatuses
                       where row.Id == resignation.Id
                       select row).FirstOrDefault();

            if (res != null)
            {
                _context.ResignationApprovalStatuses.Update(resignation);
                _context.SaveChanges();
                return "Resignation approval data updated successfully";
            }
            else
                return "failed to update resignation approval data";
         }
    }
}
