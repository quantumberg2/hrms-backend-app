using Azure.Core;
using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.DTO;
using HRMS_Application.Models;
using System.Diagnostics.Eventing.Reader;

namespace HRMS_Application.BusinessLogic.Implements
{
    public class ResignationImp : IResignation
    {
        private readonly HRMSContext _context;
        public ResignationImp(HRMSContext context)
        {
            _context = context;
        }
        public List<Resignation> GetData()
        {
            var data = (from row in _context.Resignations
                        where row.IsActive == 1
                        select row).ToList();
            return data;
        }

        public string InsertResignation(int empCredId, ResignationDTO resignation)
        {

            var employeeExists = _context.EmployeeCredentials.Any(e => e.Id == empCredId);
            if (!employeeExists)
            {
                return "Employee does not exist.";
            }

           

            var existingResignation = _context.Resignations.FirstOrDefault(r => r.EmpCredentialId == empCredId && r.IsActive == 1);
            if (existingResignation != null)
            {
                return "Resignation already exists for this employee.";
            }

            var newResignation = new Resignation
            {
                EmpCredentialId = empCredId,
                Reason = resignation.Reason,
                StartDate = resignation.StartDate,
                ExitDate = resignation.ExitDate, 
                CreatedDate = DateTime.Now,
                IsActive = 1,
                Status = "Pending",
                FinalSettlementDate = null,
                Comments = resignation.Comments
            };

            _context.Resignations.Add(newResignation);

            int result = _context.SaveChanges();
            return result > 0 ? "Resignation applied successfully." : "Failed to apply resignation.";
        }

        public bool SoftDeleteResignation(int id, short isActive)
        {
            var res  = (from row in _context.Resignations
                        where row.Id == id && row.IsActive == isActive
                        select row).FirstOrDefault();
            if(res!=null)
            {
                 res.IsActive = isActive;
                _context.Resignations.Update(res);
                _context.SaveChanges();
                return true;
            }
            else
            { 
                return false; 
            }
        }

        public string UpdateResignation(Resignation resignation)
        {
            var res = (from row in _context.Resignations
                       where row.Id == resignation.Id
                       select row).FirstOrDefault();

            if (res != null)
            {
                _context.Resignations.Update(resignation);
                _context.SaveChanges();
                return "Resignation updated successfully";
            }
            else
                return "failed to update resignation";

        }
    }
}
