﻿
using HRMS_Application.Controllers;
using HRMS_Application.DTO;
using HRMS_Application.Models;
using static HRMS_Application.BusinessLogic.Implements.ResignationImp;

namespace HRMS_Application.BusinessLogic.Interface
{
    public interface IResignation
    {
        public List<Resignation> GetData();
        public List<ResignationStatusDTO> GetAllResignationStatus(int empCredId);
        public List<ResignationGridDTO> GetResignationDetailsforGrid();
        public List<ResignationGridDTO> GetResignationInfoByStatus(string status, int empCredId);
        public string InsertResignation(int empCredId, ResignationDTO resignation);
        public string ResignationUpdateByAdmin(int id, AdminResignationApprovalDTO resignation);
        public string UpdateResignation(Resignation resignation);
        public string UpdateResignationStatus(int id, string newStatus);
        public bool SoftDeleteResignation(int id,short isActive );
        public Resignation UpdateResigStatusUserId(int empCredId, int id, string newStatus);
        public string ResignationRejectStatusUpdate(int empCredId, int id, string newStatus);
        public Task<string> UpdateResignationLastDate(int empCredId, int id, ExitDateRequestDTO request);


    }
}

