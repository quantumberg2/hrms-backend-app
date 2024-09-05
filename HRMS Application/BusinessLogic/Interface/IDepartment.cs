using HRMS_Application.Models;

namespace HRMS_Application.BusinessLogic.Interface
{
    public interface IDepartment
    {
        public List<Department> GetAllDepartment();
        public Department GetDepartmentById(int id);
        public List<Department> GetDepartmentsByName(string name);
        public Task<string> InsertDepartment(Department department);
        public Task<Department> UpdateDepartment(int id, string? name, int? requestedcompanyId);
        public Task<bool> deleteDepartment(int id);
        public bool SoftDelete(int id, short isActive);
    }
}
