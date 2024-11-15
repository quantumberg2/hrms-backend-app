using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.Models;

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
