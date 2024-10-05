using Azure.Storage.Blobs;
using HRMS_Application.Authorization;
using HRMS_Application.BusinessLogic.Implements;
using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.BusinessLogics.Implements;
using HRMS_Application.Helpers;
using HRMS_Application.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Azure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var useLocalDatabase = builder.Configuration.GetValue<bool>("DatabaseSettings:UseLocalDatabase");

// Retrieve the connection string based on the flag
var connectionString = useLocalDatabase
    ? builder.Configuration.GetConnectionString("LocalDatabase")
    : builder.Configuration.GetConnectionString("DeployedDatabase");

// Ensure the connection string is not null or empty
if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("The connection string is missing or empty.");
}

// Add DbContext with the correct connection string
builder.Services.AddDbContext<HRMSContext>(options =>
    options.UseSqlServer(connectionString));


builder.Services.AddScoped<IJwtUtils, JwtUtils>();
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

builder.Services.AddScoped<IDepartment, DepartmentsImp>();
builder.Services.AddScoped<IPosition, PositionImp>();
builder.Services.AddScoped<IEmpCredential, EmpCredentialImp>();
builder.Services.AddScoped<ICompanyDetails, CompanyDetailsImp>();
builder.Services.AddScoped<IUserRoles,UserRoleImp>();
builder.Services.AddScoped<IRoles, RolesImp>();
builder.Services.AddScoped<IEmployeeSalary, EmployeeSalaryImp>();
builder.Services.AddScoped<IAccountDetails, AccountDetailsImp>();
builder.Services.AddScoped<IAddressInfo,AddressImp>();
builder.Services.AddScoped<IEmployeeSalary, EmployeeSalaryImp>();
builder.Services.AddScoped<IEmployeeAttendance, EmployeeAttendanceImp>();
builder.Services.AddScoped<IEmpLeaveAllocation, EmpLeaveAllocationImp>();
builder.Services.AddScoped<IHoliday, HolidayImp>();
builder.Services.AddScoped<ILeaveTypes, LeaveTypesImp>();
builder.Services.AddScoped<IEmpDetails, EmpDetailsImp>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICompanyRequestedform, CompanyRequestedformImp>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IEmailPassword, EmailPasswordImp>();
builder.Services.AddScoped<IEmployeeImportService, EmployeeImportService>();
builder.Services.AddScoped<IFileStorage, FileStorageImp>();
builder.Services.AddScoped<IAzureOperations, AzureOperationsImp>();
builder.Services.AddScoped<ILocalStorageOperations, LocalStorageOperationsImp>();
builder.Services.AddScoped<IDeviceOperations, DeviceOperationsImp>();
builder.Services.AddScoped<IEmpPersonalInfo , EmpPersonalInfoImp>();
builder.Services.AddScoped<ILeaveTracking, LeaveTrackingImp>();
builder.Services.AddScoped<IShiftRoster, ShiftRosterImp>();
builder.Services.AddScoped<IShiftRostertype, ShiftRostertypeImp>();
builder.Services.AddScoped<IOrgChartService, OrgChartServiceImp>();
builder.Services.AddScoped<IAdminDashboard, AdmindashboardImp>();
builder.Services.AddScoped<IUpdateEmployeeDetails, UpdateEmployeeDetailsImp>();
builder.Services.AddScoped<INews, NewsImp>();
builder.Services.AddScoped<INewsPreview, NewPreviewImp>();

builder.Services.AddScoped<IContactUs, ContactUsImp>();
builder.Services.AddScoped<IAlertEmailOperations,AlertEmailOperationsImp>();

builder.Services.AddScoped(_ =>
{
    return new BlobServiceClient(builder.Configuration.GetConnectionString("AsureBlobStorage"));

});

builder.Services.AddControllers()
     .AddJsonOptions(options =>
     {
         options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
         options.JsonSerializerOptions.MaxDepth = 64; // Optional, based on needs

     });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseCors("AllowAllOrigins"); // Use the CORS policy

app.UseAuthorization();

app.MapControllers();

app.Run();
