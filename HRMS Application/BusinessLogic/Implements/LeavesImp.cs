/*using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.Models;

namespace HRMS_Application.BusinessLogic.Implements
{
    public class LeavesImp : ILeaves
    {
        private readonly HRMSContext _hrmsContext;
        public LeavesImp(HRMSContext hrmsContext)
        {
            _hrmsContext = hrmsContext;
        }

        public bool deleteLeave(int id)
        {
            var result = (from row in _hrmsContext.Leaves
                          where row.Id == id
                          select row).SingleOrDefault();
            _hrmsContext.Leaves.Remove(result);
            _hrmsContext.SaveChanges();
            return true;
        }

        public List<Leaf> GetallLeaves()
        {
            var result = (from row in _hrmsContext.Leaves
                          select row).ToList();
            return result;
        }

        public Leaf GetLeaveById(int id)
        {
            throw new NotImplementedException();
        }

        public string InsertLeave(Leaf leave)
        {
            _hrmsContext.Leaves.Add(leave);
            var result = _hrmsContext.SaveChanges();
            if (result != 0)
            {
                return "new Position inserted successfully";

            }
            else
            {
                return "failed to insert new data";
            }
        }

        public Leaf updateLeave(int id, string? leavetype, int? days)
        {
            var result = _hrmsContext.Leaves.SingleOrDefault(p => p.Id == id);
            if (result == null)
            {
                // Handle the case where the user with the specified id doesn't exist
                return null;
            }
            result.LeaveType = leavetype;
            result.Days = days;
            _hrmsContext.Leaves.Update(result);
            _hrmsContext.SaveChanges();
            return result;
        }
    }
}
*/