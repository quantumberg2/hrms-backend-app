using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.Models;

namespace HRMS_Application.BusinessLogic.Implements
{
    public class LeaveTypesImp : ILeaveTypes
    {
        private HRMSContext _context;
        public LeaveTypesImp(HRMSContext context)
        {
            _context = context;
        }

        public bool deleteLeaveType(int id)
        {
            var result = (from row in _context.LeaveTypes
                          where row.Id == id
                          select row).SingleOrDefault();
            _context.LeaveTypes.Remove(result);
            _context.SaveChanges();
            return true;
        }

        public List<LeaveType> GetAllLeaveType()
        {
            var result = (from row in _context.LeaveTypes
                          select row).ToList();
            return result;
        }

        public LeaveType GetLeaveTypeById(int id)
        {
            var result = (from row in _context.LeaveTypes
                          where row.Id == id
                          select row).FirstOrDefault();
            return result;
        }

        public LeaveType GetLeaveTypeByType(string Type)
        {
            var result = (from row in _context.LeaveTypes
                          where row.Type == Type
                          select row).FirstOrDefault();
            return result;
        }

        public string InsertLeaveType(LeaveType leaveType)
        {
            _context.LeaveTypes.Add(leaveType);
            var result = _context.SaveChanges();
            if (result != 0)
            {
                return "new leavetype inserted successfully";

            }
            else
            {
                return "failed to insert new data";
            }
        }

        public LeaveType UpdateLeaveType(int id, string? name, int? requestedcompanyId)
        {
            throw new NotImplementedException();
        }
    }
}