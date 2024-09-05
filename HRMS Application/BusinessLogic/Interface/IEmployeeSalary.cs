using HRMS_Application.Models;

namespace HRMS_Application.BusinessLogic.Interface
{
    public interface IEmployeeSalary
    {
        public List<EmpSalary> GetAllEmpSalary();
        public EmpSalary GetEmpSalaryById(int id);
        public Task<string> InsertEmpSalary(EmpSalary empSalary);
       // public EmpSalary UpdateempSalary(int id, string? name, int? requestedcompanyId);
        public Task<bool> deleteEmpsalary(int id);
        public bool SoftDelete(int id, short isActive);
    }
}
