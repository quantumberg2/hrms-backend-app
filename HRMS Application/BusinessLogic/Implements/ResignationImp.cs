using Azure.Core;
using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.DTO;
using HRMS_Application.Middleware.Exceptions;
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
        public List<ResignationStatusDTO> GetAllResignationStatus(int empCredId)
        {
            var resignationDetails = (from row in _context.Resignations
                                      where row.EmpCredentialId == empCredId && row.IsActive == 1
                                      join empCred in _context.EmployeeCredentials on row.EmpCredentialId equals empCred.Id
                                      join empDetail in _context.EmployeeDetails on empCred.Id equals empDetail.EmployeeCredentialId
                                      join mgr in _context.EmployeeDetails on empDetail.ManagerId equals mgr.Id 
                                      select new ResignationStatusDTO
                                      {
                                          Status = row.Status,
                                          CreatedDate = row.CreatedDate,
                                          ExitDate = row.ExitDate,
                                          Reason = row.Reason,
                                          managerName = mgr.FirstName + " " + mgr.LastName
                                      }).ToList();

            return resignationDetails;
        }

        public List<ResignationGridDTO> GetResignationDetailsforGrid()
        {
            var resigInfo = (from row in _context.Resignations
                             where row.IsActive == 1
                             join empCred in _context.EmployeeCredentials on row.EmpCredentialId equals empCred.Id
                             join empDetail in _context.EmployeeDetails on empCred.Id equals empDetail.EmployeeCredentialId
                             select new ResignationGridDTO
                             {
                                 EmployeeName = empDetail.FirstName +"" + empDetail.LastName,
                                 EmployeeNumber = empDetail.EmployeeNumber,
                                 Reason = row.Reason,
                                 LastWorkingDay = row.ExitDate,
                                 SeparationDate = row.StartDate,

                             }).ToList();
            return resigInfo;
            
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
                Comments = resignation.Comments,
                PersonalEmailAddress = resignation?.PersonalEmailAddress
            };

            _context.Resignations.Add(newResignation);
            _context.SaveChanges();


            var existingApprovalStatus = _context.ResignationApprovalStatuses
          .FirstOrDefault(r => r.ResignationId == newResignation.Id);

            if (existingApprovalStatus != null)
            {
                existingApprovalStatus.ManagerApprovalStatus = "Pending";
                existingApprovalStatus.AdminApprovalStatus = "Pending";
                existingApprovalStatus.IsActive = 1;
            }
            else
            {
                var newApprovalStatus = new ResignationApprovalStatus
                {
                    ResignationId = newResignation.Id,
                    ManagerApprovalStatus = "Pending",
                    AdminApprovalStatus = "Pending",
                    IsActive = 1,
                };
                _context.ResignationApprovalStatuses.Add(newApprovalStatus);
            }

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

        public string ResignationUpdateByAdmin(int empCredId,int id, AdminResignationApprovalDTO resignation)
        {
            var existingResignation = _context.Resignations.FirstOrDefault(e => e.Id == id && e.EmpCredentialId==empCredId);
            if (existingResignation == null)
            {
                return "Resignation record not found.";
            }
           
            var empCredInfo = _context.EmployeeCredentials.FirstOrDefault(e => e.Id == existingResignation.EmpCredentialId);
            if (empCredInfo == null)
            {
                return "Employee credentials not found.";
            }

            var resigApprovalInfo = _context.ResignationApprovalStatuses.FirstOrDefault(res => res.ResignationId == id);
            if (resigApprovalInfo == null)
            {
                return "Resignation approval info not found.";
            }

            if (!string.Equals(resigApprovalInfo.ManagerApprovalStatus, "Approved", StringComparison.OrdinalIgnoreCase))
            {
                return "Resignation not approved by the manager. Please get manager's approval first.";
            }

            existingResignation.Status = "Approved";
            existingResignation.FinalSettelmentType = resignation.FinalSettelmentType;
            existingResignation.FinalSettlementDate = DateTime.Now;
            existingResignation.PersonalEmailAddress = resignation?.PersonalEmailAddress;
            existingResignation.UpdatedDate = DateTime.Now; 

            empCredInfo.ResignedDate = DateTime.Now;

            resigApprovalInfo.AdminApprovalStatus = "Approved";

            _context.Resignations.Update(existingResignation);
            _context.EmployeeCredentials.Update(empCredInfo);
            _context.ResignationApprovalStatuses.Update(resigApprovalInfo);

            int result = _context.SaveChanges();

            return result > 0 ? "Resignation updated and approved successfully." : "Failed to update resignation.";

        }

        public string UpdateResignationStatus(int id, string newStatus)
        {
            var resignation = _context.Resignations.FirstOrDefault(e => e.Id == id);
            var resigApprovalInfo = _context.ResignationApprovalStatuses.FirstOrDefault(e=>e.Id==resignation.Id);
            if (resignation == null)
            {
                return "Employee not found";
            }

            if (string.Equals(newStatus, "Withdraw", StringComparison.OrdinalIgnoreCase))
            {
                resignation.IsActive = 0;
                resigApprovalInfo.IsActive = 0;
            }

            resignation.Status = newStatus;
            _context.Resignations.Update(resignation);
            _context.SaveChanges();

            return "Status updated successfully";
        }


        public List<ResignationGridDTO> GetResignationInfoByStatus(string status, int empCredId)
        {

            var resignations = (from resig in _context.Resignations
                               join emp in _context.EmployeeDetails on resig.EmpCredentialId equals emp.EmployeeCredentialId
                               where resig.Status == status
                                     && emp.ManagerId == empCredId
                                     && emp.IsActive == 1
                                     && resig.IsActive == 1
                               select new ResignationGridDTO
                               {
                                        EmployeeName = emp.FirstName + " " + emp.LastName,
                                        EmployeeNumber = emp.EmployeeNumber,
                                        Reason = resig.Reason,
                                        SeparationDate = resig.StartDate,
                                        LastWorkingDay = resig.ExitDate,
                                        Status = status
                                    }).ToList();

                return resignations;
        }
        public Resignation UpdateResigStatusUserId(int empCredId, int id, string newStatus)
        {
            var resignation = (from row in _context.Resignations
                               where row.EmpCredentialId == empCredId && row.Id == id
                               select row).FirstOrDefault();
            if(resignation!= null)
            {
                resignation.Status = newStatus;
                _context.SaveChanges();
            }

            return resignation;
        }

       
    }
}
