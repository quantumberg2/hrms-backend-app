﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HRMS_Application.Models
{
    public partial class HRMSContext : DbContext
    {
        public HRMSContext()
        {
        }

        public HRMSContext(DbContextOptions<HRMSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccountDetail> AccountDetails { get; set; }
        public virtual DbSet<AddressInfo> AddressInfos { get; set; }
        public virtual DbSet<Attendance> Attendances { get; set; }
        public virtual DbSet<Audit> Audits { get; set; }
        public virtual async Task<int> SaveChangesAsync(int? userId = null)
        {
            OnBeforeSaveChanges(userId);
            var result = await base.SaveChangesAsync();
            return result;
        }

        private void OnBeforeSaveChanges(int? userId)
        {
            ChangeTracker.DetectChanges();
            var auditEntries = new List<AuditEntry>();
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is Audit || entry.State == EntityState.Detached || entry.State == EntityState.Unchanged)
                    continue;

                var auditEntry = new AuditEntry(entry);
                auditEntry.TableName = entry.Entity.GetType().Name;
                auditEntry.UserId = userId;
                auditEntries.Add(auditEntry);

                foreach (var property in entry.Properties)
                {
                    string propertyName = property.Metadata.Name;
                    if (property.Metadata.IsPrimaryKey())
                    {
                        auditEntry.KeyValues[propertyName] = property.CurrentValue;
                        continue;
                    }

                    switch (entry.State)
                    {
                        case EntityState.Added:
                            auditEntry.AuditType = Enums.AuditType.Create;
                            auditEntry.NewValues[propertyName] = property.CurrentValue;
                            break;
                        case EntityState.Deleted:
                            auditEntry.AuditType = Enums.AuditType.Delete;
                            auditEntry.OldValues[propertyName] = property.OriginalValue;
                            break;
                        case EntityState.Modified:
                            if (property.IsModified)
                            {
                                auditEntry.ChangedColumns.Add(propertyName);
                                auditEntry.AuditType = Enums.AuditType.Update;
                                auditEntry.OldValues[propertyName] = property.OriginalValue;
                                auditEntry.NewValues[propertyName] = property.CurrentValue;
                            }
                            break;
                    }
                }
            }
        }
        public virtual DbSet<CompanyDetail> CompanyDetails { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<DeviceTable> DeviceTables { get; set; }
        public virtual DbSet<EmpPersonalInfo> EmpPersonalInfos { get; set; }
        public virtual DbSet<EmpSalary> EmpSalaries { get; set; }
        public virtual DbSet<EmployeeCredential> EmployeeCredentials { get; set; }
        public virtual DbSet<EmployeeDetail> EmployeeDetails { get; set; }
        public virtual DbSet<EmployeeLeaveAllocation> EmployeeLeaveAllocations { get; set; }
        public virtual DbSet<File> Files { get; set; }
        public virtual DbSet<Holiday> Holidays { get; set; }
        public virtual DbSet<LeaveTracking> LeaveTrackings { get; set; }
        public virtual DbSet<LeaveType> LeaveTypes { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<NewsPreview> NewsPreviews { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<RequestedCompanyForm> RequestedCompanyForms { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<ShiftRoster> ShiftRosters { get; set; }
        public virtual DbSet<ShiftRosterType> ShiftRosterTypes { get; set; }
        public virtual DbSet<UserRolesJ> UserRolesJs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountDetail>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AadharNumber)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.AccountNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AccountType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BankName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.BranchName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.EligibleForPf).HasColumnName("EligibleForPF");

                entity.Property(e => e.EmployeeCredentialId).HasColumnName("Employee_Credential_Id");

                entity.Property(e => e.IfscCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("IFSC_Code");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.PfJoiningDate)
                    .HasColumnType("date")
                    .HasColumnName("PF_joiningDate");

                entity.Property(e => e.PfNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PF_Number");

                entity.Property(e => e.Pin).HasColumnName("PIN");

                entity.Property(e => e.State)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UanNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UAN_Number");

                entity.HasOne(d => d.EmployeeCredential)
                    .WithMany(p => p.AccountDetails)
                    .HasForeignKey(d => d.EmployeeCredentialId)
                    .HasConstraintName("FK__AccountDe__Emplo__6EF57B66");
            });

            modelBuilder.Entity<AddressInfo>(entity =>
            {
                entity.ToTable("AddressInfo");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AddressLine1)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.AddressLine2)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeCredentialId).HasColumnName("Employee_Credential_Id");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.PinCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PIN_Code");

                entity.Property(e => e.State)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.EmployeeCredential)
                    .WithMany(p => p.AddressInfos)
                    .HasForeignKey(d => d.EmployeeCredentialId)
                    .HasConstraintName("FK__AddressIn__Emplo__6FE99F9F");
            });

            modelBuilder.Entity<Attendance>(entity =>
            {
                entity.ToTable("Attendance");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.EmpCredentialId).HasColumnName("Emp_CredentialId");

                entity.Property(e => e.NumberOfHours).HasColumnName("Number_of_hours");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TimeIn).HasColumnType("datetime");

                entity.Property(e => e.Timeout).HasColumnType("datetime");

                entity.HasOne(d => d.EmpCredential)
                    .WithMany(p => p.Attendances)
                    .HasForeignKey(d => d.EmpCredentialId)
                    .HasConstraintName("FK_Attendence_Employee_Credential");
            });

            modelBuilder.Entity<Audit>(entity =>
            {
                entity.ToTable("Audit");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AffectedColumns)
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.DateTime).HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.NewValues)
                    .IsUnicode(false)
                    .HasColumnName("newValues");

                entity.Property(e => e.OldValues)
                    .IsUnicode(false)
                    .HasColumnName("oldValues");

                entity.Property(e => e.PrimaryKey)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TableName)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CompanyDetail>(entity =>
            {
                entity.ToTable("Company_Details");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Currency)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.EsiNo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ESI_No");

                entity.Property(e => e.Facebook)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.GstNo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GST_No");

                entity.Property(e => e.Industry)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.LinkedIn)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PanNo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PAN_No");

                entity.Property(e => e.PfNo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PF_No");

                entity.Property(e => e.RegistrationNo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Registration_No");

                entity.Property(e => e.RequestedCompanyId).HasColumnName("Requested_Company_id");

                entity.Property(e => e.States)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TanNo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TAN_No");

                entity.Property(e => e.TimeZone)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Twitter)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.RequestedCompany)
                    .WithMany(p => p.CompanyDetails)
                    .HasForeignKey(d => d.RequestedCompanyId)
                    .HasConstraintName("FK__Company_D__Reque__71D1E811");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("Department");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.RequestedCompanyId).HasColumnName("Requested_Company_id");

                entity.HasOne(d => d.RequestedCompany)
                    .WithMany(p => p.Departments)
                    .HasForeignKey(d => d.RequestedCompanyId)
                    .HasConstraintName("FK__Departmen__Reque__72C60C4A");
            });

            modelBuilder.Entity<DeviceTable>(entity =>
            {
                entity.ToTable("DeviceTable");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EmpCredentialId).HasColumnName("Emp_CredentialId");

                entity.Property(e => e.ErlOut)
                    .HasColumnType("datetime")
                    .HasColumnName("Erl_out");

                entity.Property(e => e.InsertedDate).HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.LateIn)
                    .HasColumnType("datetime")
                    .HasColumnName("Late_In");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.OverTime).HasColumnType("datetime");

                entity.Property(e => e.Remark)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TimeIn).HasColumnType("datetime");

                entity.Property(e => e.TimeOut).HasColumnType("datetime");

                entity.Property(e => e.WorkTime).HasColumnType("datetime");

                entity.HasOne(d => d.EmpCredential)
                    .WithMany(p => p.DeviceTables)
                    .HasForeignKey(d => d.EmpCredentialId)
                    .HasConstraintName("FK_DeviceTable_Employee_Credential");
            });

            modelBuilder.Entity<EmpPersonalInfo>(entity =>
            {
                entity.ToTable("EmpPersonal_Info");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BloodGroup)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ConfirmDate).HasColumnType("date");

                entity.Property(e => e.DateOfJoining).HasColumnType("date");

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("DOB");

                entity.Property(e => e.EmailId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Email_Id");

                entity.Property(e => e.EmergencyContact)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.EmpStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeCredentialId).HasColumnName("Employee_Credential_Id");

                entity.Property(e => e.Gender)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.MaritalStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Pan)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PAN");

                entity.Property(e => e.PersonalEmail)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SpouseName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.EmployeeCredential)
                    .WithMany(p => p.EmpPersonalInfos)
                    .HasForeignKey(d => d.EmployeeCredentialId)
                    .HasConstraintName("FK__EmpPerson__Emplo__7A672E12");
            });

            modelBuilder.Entity<EmpSalary>(entity =>
            {
                entity.ToTable("EmpSalary");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AnnualIncome)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Annual_Income");

                entity.Property(e => e.EmployeeCredentialId).HasColumnName("Employee_Credential_Id");

                entity.Property(e => e.Insurance).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.Loan).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.SalaryRange)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.EmployeeCredential)
                    .WithMany(p => p.EmpSalaries)
                    .HasForeignKey(d => d.EmployeeCredentialId)
                    .HasConstraintName("FK__EmpSalary__Emplo__7B5B524B");
            });

            modelBuilder.Entity<EmployeeCredential>(entity =>
            {
                entity.ToTable("Employee_Credential");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DefaultPassword).HasColumnName("Default_Password");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeLoginName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Employee_Login_Name");

                entity.Property(e => e.GenerateOtp)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Generate_OTP");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.OtpExpiration)
                    .HasColumnType("datetime")
                    .HasColumnName("Otp_Expiration");

                entity.Property(e => e.Password).HasMaxLength(256);

                entity.Property(e => e.RequestedCompanyId).HasColumnName("Requested_Company_id");

                entity.Property(e => e.ResignedDate).HasColumnType("date");

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.RequestedCompany)
                    .WithMany(p => p.EmployeeCredentials)
                    .HasForeignKey(d => d.RequestedCompanyId)
                    .HasConstraintName("FK__Employee___Reque__74AE54BC");
            });

            modelBuilder.Entity<EmployeeDetail>(entity =>
            {
                entity.ToTable("Employee_Detail");

                entity.HasIndex(e => e.EmployeeNumber, "UQ__Employee__8D6635986A1F7877")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeCredentialId).HasColumnName("Employee_Credential_Id");

                entity.Property(e => e.EmployeeNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Extension)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.LastName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MobileNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NickName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NumberOfYearsExperience)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Number_of_Years_Experience");

                entity.Property(e => e.RequestCompanyId).HasColumnName("Request_Company_Id");

                entity.HasOne(d => d.Dept)
                    .WithMany(p => p.EmployeeDetails)
                    .HasForeignKey(d => d.DeptId)
                    .HasConstraintName("FK__Employee___DeptI__75A278F5");

                entity.HasOne(d => d.EmployeeCredential)
                    .WithMany(p => p.EmployeeDetails)
                    .HasForeignKey(d => d.EmployeeCredentialId)
                    .HasConstraintName("FK__Employee___Emplo__76969D2E");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.EmployeeDetails)
                    .HasForeignKey(d => d.PositionId)
                    .HasConstraintName("FK__Employee___Posit__778AC167");
            });

            modelBuilder.Entity<EmployeeLeaveAllocation>(entity =>
            {
                entity.ToTable("Employee_Leave_Allocation");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EmpCredentialId).HasColumnName("Emp_CredentialId");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.LeaveType).HasColumnName("Leave_Type");

                entity.Property(e => e.NumberOfLeaves).HasColumnName("Number_of_Leaves");

                entity.Property(e => e.RemainingLeave).HasColumnName("Remaining_Leave");

                entity.HasOne(d => d.EmpCredential)
                    .WithMany(p => p.EmployeeLeaveAllocations)
                    .HasForeignKey(d => d.EmpCredentialId)
                    .HasConstraintName("FK_Employee_Leave_Allocation_Emp_credential");

                entity.HasOne(d => d.LeaveTypeNavigation)
                    .WithMany(p => p.EmployeeLeaveAllocations)
                    .HasForeignKey(d => d.LeaveType)
                    .HasConstraintName("FK_Employee_Leave_Allocation_Leave_Type");
            });

            modelBuilder.Entity<File>(entity =>
            {
                entity.Property(e => e.FileUrl).IsUnicode(false);

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.ObjectName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Tags).IsUnicode(false);
            });

            modelBuilder.Entity<Holiday>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CompanyId).HasColumnName("Company_Id");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.Occasion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Holidays)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK_Holiday_Company");
            });

            modelBuilder.Entity<LeaveTracking>(entity =>
            {
                entity.ToTable("LeaveTracking");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AppliedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Applied_Date");

                entity.Property(e => e.Contact)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmpCredentialId).HasColumnName("Emp_CredentialId");

                entity.Property(e => e.Enddate).HasColumnType("datetime");

                entity.Property(e => e.Files)
                    .IsUnicode(false)
                    .HasColumnName("files");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.ReasonForLeave)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Session)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Startdate).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.EmpCredential)
                    .WithMany(p => p.LeaveTrackings)
                    .HasForeignKey(d => d.EmpCredentialId)
                    .HasConstraintName("FK_LeaveTracking_Employee_Credential");

                entity.HasOne(d => d.LeaveType)
                    .WithMany(p => p.LeaveTrackings)
                    .HasForeignKey(d => d.LeaveTypeId)
                    .HasConstraintName("FK_LeaveTracking_LeaveTypes");
            });

            modelBuilder.Entity<LeaveType>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CompanyId).HasColumnName("Company_id");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.Type)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.LeaveTypes)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK_LeaveTypes_Company");
            });

            modelBuilder.Entity<News>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Details).IsUnicode(false);

                entity.Property(e => e.Heading)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.NewsPreview)
                    .WithMany(p => p.News)
                    .HasForeignKey(d => d.NewsPreviewId)
                    .HasConstraintName("FK_News_NewsPreview");
            });

            modelBuilder.Entity<NewsPreview>(entity =>
            {
                entity.ToTable("NewsPreview");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.DisplayDate).HasColumnType("datetime");

                entity.Property(e => e.Heading)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ImgUrl)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.InsertedDate).HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("isActive");
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.ToTable("Position");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.RequestedCompanyId).HasColumnName("Requested_Company_id");

                entity.HasOne(d => d.RequestedCompany)
                    .WithMany(p => p.Positions)
                    .HasForeignKey(d => d.RequestedCompanyId)
                    .HasConstraintName("FK__Position__Reques__00200768");
            });

            modelBuilder.Entity<RequestedCompanyForm>(entity =>
            {
                entity.ToTable("Requested_company_form");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DomainName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Domain_name");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.InsertedDate).HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Phone_number");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ShiftRoster>(entity =>
            {
                entity.ToTable("ShiftRoster");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EmpCredentialId).HasColumnName("Emp_CredentialId");

                entity.Property(e => e.Enddate)
                    .HasColumnType("datetime")
                    .HasColumnName("enddate");

                entity.Property(e => e.Startdate)
                    .HasColumnType("datetime")
                    .HasColumnName("startdate");

                entity.HasOne(d => d.ShiftRosterType)
                    .WithMany(p => p.ShiftRosters)
                    .HasForeignKey(d => d.ShiftRosterTypeId)
                    .HasConstraintName("FK__ShiftRost__Shift__236943A5");
            });

            modelBuilder.Entity<ShiftRosterType>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.TimeRange)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserRolesJ>(entity =>
            {
                entity.ToTable("User_Roles_J");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EmployeeCredentialId).HasColumnName("Employee_Credential_Id");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.RolesId).HasColumnName("Roles_Id");

                entity.HasOne(d => d.EmployeeCredential)
                    .WithMany(p => p.UserRolesJs)
                    .HasForeignKey(d => d.EmployeeCredentialId)
                    .HasConstraintName("FK__User_Role__Emplo__01142BA1");

                entity.HasOne(d => d.Roles)
                    .WithMany(p => p.UserRolesJs)
                    .HasForeignKey(d => d.RolesId)
                    .HasConstraintName("FK_Roles");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}