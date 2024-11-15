using Azure.Core;
using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.Models;
using System.Diagnostics.Eventing.Reader;

namespace HRMS_Application.BusinessLogic.Implements
{
    public class ResignationImp : IResignation
    {
        private readonly HRMSContext _context;
        public ResignationImp(HRMSContext context)
        {
            _context = context;
        }
        public List<Resignation> GetData()
        {
            var data = (from row in _context.Resignations
                        where row.IsActive == 1
                        select row).ToList();
            return data;
        }

        public string InsertResignation(Resignation resignation)
        {

            if(resignation.StartDate.HasValue)
            {
                resignation.ExitDate = resignation.StartDate.Value.AddDays(30);
            }

            resignation.CreatedDate = DateTime.Now;

            resignation.IsActive = 1;

            var res = _context.Resignations.Add(resignation);
            if(res!=null)
            {
                _context.SaveChanges();
                return "Resignation applied successfully";
            }
            else
            {
                return "Failed to apply resignation";
            }
        }

        public bool SoftDeleteResignation(int id, short isActive)
        {
            var res  = (from row in _context.Resignations
                        where row.Id == id && row.IsActive == isActive
                        select row).FirstOrDefault();
            if(res!=null)
            {
                 res.IsActive = isActive;
                _context.Resignations.Update(res);
                _context.SaveChanges();
                return true;
            }
            else
            { 
                return false; 
            }
        }

        public string UpdateResignation(Resignation resignation)
        {
            var res = (from row in _context.Resignations
                       where row.Id == resignation.Id
                       select row).FirstOrDefault();

            if (res != null)
            {
                _context.Resignations.Update(resignation);
                _context.SaveChanges();
                return "Resignation updated successfully";
            }
            else
                return "failed to update resignation";

        }
    }
}
