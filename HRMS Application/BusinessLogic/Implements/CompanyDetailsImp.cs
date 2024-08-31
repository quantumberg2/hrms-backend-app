using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.Middleware.Exceptions;
using HRMS_Application.Models;

namespace HRMS_Application.BusinessLogic.Implements
{
    public class CompanyDetailsImp : ICompanyDetails
    {
        private readonly HRMSContext _context;
        public CompanyDetailsImp(HRMSContext context)
        {
            _context = context;
        }
        public bool deleteCompanyDetails(int id)
        {
            var result = (from row in _context.CompanyDetails
                          where row.Id == id
                          select row).SingleOrDefault();
            if (result != null)
            {
                _context.CompanyDetails.Remove(result);
                _context.SaveChanges();
                return true;
            }
            else
            {
                throw new NotFoundException($"Could not delete CompanyDetails of {id}");
            }
        }

        public List<CompanyDetail> GetAllCompanyDetails()
        {
            var result = (from row in _context.CompanyDetails
                          select row).ToList();
            return result;
        }

        public List<CompanyDetail> GetCompanyDetailstById(int id)
        {
            var result = (from row in _context.CompanyDetails
                          where row.Id == id
                          select row).ToList();
            return result;
        }

        public List<CompanyDetail> GetCompanyDetailstByName(string companyName)
        {
            var info = (from row in _context.CompanyDetails
                        where row.Name == companyName
                        select row).ToList();
            return info;
        }
        public int InsertCompanyDetails(CompanyDetail companyDetail)
        {
            try
            {
                _context.CompanyDetails.Add(companyDetail);
                var result = _context.SaveChanges();
                if (result != 0)
                {
                    return result;
                }
                else
                {
                    throw new DatabaseOperationException("Failed to insert CompanyDetails data");
                }
            }
            catch (Exception)
            {
                throw new DatabaseOperationException("Failed to insert CompanyDetails data");
            }
        }
    }
}
