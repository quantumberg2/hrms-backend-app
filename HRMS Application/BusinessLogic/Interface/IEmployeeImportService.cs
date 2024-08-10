namespace HRMS_Application.BusinessLogic.Interface
{
    public interface IEmployeeImportService
    {
      public Task ImportEmployeesFromExcelAsync(Stream excelStream);

    }
}
