﻿using Azure.Core;
using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.Controllers;
using HRMS_Application.DTO;
using HRMS_Application.Middleware.Exceptions;
using HRMS_Application.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Ocsp;
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
                                      join resigApproval in _context.ResignationApprovalStatuses on row.Id equals resigApproval.ResignationId
                                      join empCred in _context.EmployeeCredentials on row.EmpCredentialId equals empCred.Id
                                      join empDetail in _context.EmployeeDetails on empCred.Id equals empDetail.EmployeeCredentialId
                                      join mgr in _context.EmployeeDetails on empDetail.ManagerId equals mgr.Id 
                                      select new ResignationStatusDTO
                                      {
                                          id = row.Id,
                                          Status = row.Status,
                                          CreatedDate = row.CreatedDate,
                                          StartDate = row.StartDate,
                                          ExitDate = row.ExitDate,
                                          Reason = row.Reason,
                                          managerName = mgr.FirstName + " " + mgr.LastName,
                                          adminApprovalStatus = resigApproval.AdminApprovalStatus,
                                          managerApprovalStatus = resigApproval.ManagerApprovalStatus
                                      }).ToList();

            return resignationDetails;
        }

        public List<ResignationGridDTO> GetResignationDetailsforGrid()
        {
            var resigInfo = (from row in _context.Resignations
                             where row.IsActive == 1 
                             join resigApprovalStatus in _context.ResignationApprovalStatuses on row.Id equals resigApprovalStatus.ResignationId
                             join empCred in _context.EmployeeCredentials on row.EmpCredentialId equals empCred.Id
                             join empDetail in _context.EmployeeDetails on empCred.Id equals empDetail.EmployeeCredentialId
                             where resigApprovalStatus.ManagerApprovalStatus == "Approved"
                             select new ResignationGridDTO
                             {
                                 id = row.Id,
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

        public string ResignationUpdateByAdmin(int id, AdminResignationApprovalDTO resignation)
        {
            var existingResignation = _context.Resignations.FirstOrDefault(e => e.Id == id);
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

            empCredInfo.ResignedDate = existingResignation.ExitDate;

            resigApprovalInfo.AdminApprovalStatus = "Approved";

            _context.Resignations.Update(existingResignation);
            _context.EmployeeCredentials.Update(empCredInfo);
            _context.ResignationApprovalStatuses.Update(resigApprovalInfo);

            int result = _context.SaveChanges();

            return result > 0 ? "Resignation Approved by the Admin successfully." : "Failed to initiate resignation.";

        }

        public string UpdateResignationStatus(int id, string newStatus)
        {
            var resignation = _context.Resignations.FirstOrDefault(e => e.Id == id);
            var resigApprovalInfo = _context.ResignationApprovalStatuses.FirstOrDefault(e=>e.Id==resignation.Id);
            if (resignation == null)
            {
                return "Employee not found";
            }

            if (string.Equals(newStatus, "Withdraw", StringComparison.OrdinalIgnoreCase) &&
        string.Equals(newStatus, "Rejected", StringComparison.OrdinalIgnoreCase))
            {
                resignation.IsActive = 0;

                if (resigApprovalInfo != null)
                {
                    resigApprovalInfo.IsActive = 0;
                    _context.ResignationApprovalStatuses.Update(resigApprovalInfo);
                    _context.SaveChanges();
                }
            }


            resignation.Status = newStatus;
            _context.Resignations.Update(resignation);
            _context.SaveChanges();

            return "Status updated successfully";
        }


        public List<ResignationGridDTO> GetResignationInfoByStatus(string status, int empCredId)
        {

            var resignations = (from resig in _context.Resignations
                                join resigApproval in _context.ResignationApprovalStatuses on resig.Id equals resigApproval.ResignationId
                                join emp in _context.EmployeeDetails on resig.EmpCredentialId equals emp.EmployeeCredentialId
                                where resig.Status == status
                                      && emp.ManagerId == empCredId
                                      && emp.IsActive == 1
                                      && resig.IsActive == 1
                                select new ResignationGridDTO
                                {
                                    id = resig.Id,
                                    EmployeeName = emp.FirstName + " " + emp.LastName,
                                    EmployeeNumber = emp.EmployeeNumber,
                                    Reason = resig.Reason,
                                    SeparationDate = resig.StartDate,
                                    LastWorkingDay = resig.ExitDate,
                                    Status = status,
                                    managerApprovalStatus = resigApproval.ManagerApprovalStatus,
                                    adminApprovalStatus = resigApproval.AdminApprovalStatus

                                }).ToList();

            return resignations;
        }
        public string ResignationRejectStatusUpdate(int empCredId, int id, string newStatus)
        {
            var resignation = _context.Resignations.FirstOrDefault(r => r.Id == id);
            if (resignation == null)
                return "Resignation Not found";

            var employee = _context.EmployeeDetails.FirstOrDefault(e => e.EmployeeCredentialId == empCredId);
            if (employee == null)
                return "Employee details not found";

            if (resignation != null)
            {
                resignation.Status = newStatus;

                if (string.Equals(newStatus, "Rejected", StringComparison.OrdinalIgnoreCase))
                {
                    resignation.IsActive = 0;

                    _context.Resignations.Update(resignation);
                    _context.SaveChanges();
                }
                _context.Resignations.Update(resignation);
                _context.SaveChanges();

                return "Resignations Rejected";
            }
            return "Failed to reject the resignation";

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

                if(resignation.Status == "Withdraw")
                {
                    resignation.IsActive = 0;
                    _context.SaveChanges();
                }
            }

            return resignation;
        }

        public async Task<string> UpdateResignationLastDate(int empCredId, int id, ExitDateRequestDTO request)
        {
            var employee = await _context.EmployeeDetails
                                         .FirstOrDefaultAsync(e => e.EmployeeCredentialId == empCredId);

            if (employee == null)
            {
                return $"Employee with ID {empCredId} not found.";
            }

            var resignation = await _context.Resignations
                                             .FirstOrDefaultAsync(r => r.Id == id);

            if (resignation == null)
            {
                return $"Resignation with ID {id} not found.";
            }

            if (request == null || !request.ExitDate.HasValue)
            {
                return "ExitDate is required.";
            }

            resignation.ExitDate = request.ExitDate;
            resignation.UpdatedDate = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return "Last date updated successfully.";
        }

    }
}
