using HRMS_Application.Models;

namespace HRMS_Application.BusinessLogic.Interface
{
    public interface IUserRoles
    {
        public List<UserRolesJ> GetAlluserRole();
        public UserRolesJ GetuserRoleById(int id);
        public Task<string> InsertuserRoles(UserRolesJ userRolesJ);
       // public Department UpdateDepartment(int id, string? name, int? requestedcompanyId);
        public Task<bool> deleteUserRole(int id);
    }
}
