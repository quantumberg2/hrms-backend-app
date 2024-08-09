using HRMS_Application.Authorization;
using HRMS_Application.BusinessLogic.Implements;
using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.BusinessLogics.Implements;
using HRMS_Application.Helpers;
using HRMS_Application.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<HRMSContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("connectionString")));
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
builder.Services.AddScoped<IEmployeeLeave, EmployeeLeaveImp>();
builder.Services.AddScoped<IHoliday, HolidayImp>();
builder.Services.AddScoped<ILeaveTypes, LeaveTypesImp>();
builder.Services.AddScoped<IEmpDetails, EmpDetailsImp>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICompanyRequestedform, CompanyRequestedformImp>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IEmailPassword, EmailPasswordImp>();

builder.Services.AddControllers();
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
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors("AllowAllOrigins"); // Use the CORS policy

app.MapControllers();

app.Run();
