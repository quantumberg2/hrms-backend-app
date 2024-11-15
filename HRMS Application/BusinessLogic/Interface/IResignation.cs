
using HRMS_Application.Models;

namespace HRMS_Application.BusinessLogic.Interface
{
    public interface IResignation
    {
        public List<Resignation> GetData();
        public string InsertResignation(Resignation resignation);
        public string UpdateResignation(Resignation resignation);
        public bool SoftDeleteResignation(int id,short isActive );


    }
}

