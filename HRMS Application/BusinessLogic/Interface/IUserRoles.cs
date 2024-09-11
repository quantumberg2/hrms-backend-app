using HRMS_Application.Models;

namespace HRMS_Application.BusinessLogic.Interface
{
    public interface IUserRoles
    {
        public List<UserRolesJ> GetAlluserRole();
        public UserRolesJ GetuserRoleById(int id);
        public Task<string> InsertuserRoles(UserRolesJ userRolesJ);
        public Task<bool> deleteUserRole(int id);
        public bool SoftDelete(int id, short isActive);
    }
}
