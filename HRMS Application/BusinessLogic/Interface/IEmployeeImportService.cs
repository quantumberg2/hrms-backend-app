namespace HRMS_Application.BusinessLogic.Interface
{
    public interface IEmployeeImportService
    {
        public Task<(int Inserted, int Rejected, List<string> Errors)> ImportEmployeesFromExcelAsync(Stream excelStream, int companyId);

    }
}
