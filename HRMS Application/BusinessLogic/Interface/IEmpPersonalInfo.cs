﻿using HRMS_Application.DTO;
using HRMS_Application.Models;

namespace HRMS_Application.BusinessLogic.Interface
{
    public interface IEmpPersonalInfo
    {
        public List<EmpPersonalInfo> GetAll();
        public string InsertEmpPersonalInfo(EmpPersonalInfoDTO empPersonalInfo, int empCredentialId);
        public string UpdateEmpPersonalInfo(EmpPersonalInfo empPersonalInfo, EmpPersonalInfoDTO name);
        public string DeleteEmpPersonalInfo(int Id);
        public bool SoftDelete(int id, short isActive);
    }
}
