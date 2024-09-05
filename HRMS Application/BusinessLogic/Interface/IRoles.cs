using HRMS_Application.Models;

namespace HRMS_Application.BusinessLogic.Interface
{
    public interface IRoles
    {
        public List<Role> GetAllRoles();
        public Role GetRolesById(int id);
        public Task<string> InsertRole(Role role);
        public Task<bool> deleteRole(int id);
        public bool SoftDelete(int id, short isActive);
    }
}
