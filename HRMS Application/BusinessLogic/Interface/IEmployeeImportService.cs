using Microsoft.AspNetCore.Mvc;

namespace HRMS_Application.BusinessLogic.Interface
{
    public interface IEmployeeImportService
    {
        public Task<(int Inserted, int Rejected, List<string> Errors)> ImportEmployeesFromExcelAsync(IFormFile excelFile, int companyId);

    }
}
