using HRMS_Application.Models;

namespace HRMS_Application.BusinessLogic.Interface
{
    public interface IRoles
    {
        public List<Role> GetAllRoles();
        public Role GetRolesById(int id);
        public Task<string> InsertRole(Role role);
       // public Role UpdateRole(int id, string? name, int? requestedcompanyId);
        public Task<bool> deleteRole(int id);
    }
}
