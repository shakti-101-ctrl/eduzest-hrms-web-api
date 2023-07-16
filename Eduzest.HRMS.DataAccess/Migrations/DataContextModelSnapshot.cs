﻿// <auto-generated />
using System;
using Eduzest.HRMS.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Eduzest.HRMS.DataAccess.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Eduzest.HRMS.Entities.Entities.Employee.Branch", b =>
                {
                    b.Property<Guid?>("BranchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("address");

                    b.Property<string>("BranchName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("branchname");

                    b.Property<string>("City")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("city");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("createdby");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2")
                        .HasColumnName("createdon");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("email");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("isactive");

                    b.Property<string>("MobileNumber")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("mobilenumber");

                    b.Property<string>("State")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("state");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("updatedby");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2")
                        .HasColumnName("updatedon");

                    b.HasKey("BranchId");

                    b.ToTable("Branches");
                });

            modelBuilder.Entity("Eduzest.HRMS.Entities.Entities.Employee.Department", b =>
                {
                    b.Property<Guid?>("DeptId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("deptid");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("createdby");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2")
                        .HasColumnName("createdon");

                    b.Property<string>("DepartmentName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("department");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("isactive");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("updatedby");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2")
                        .HasColumnName("updatedon");

                    b.Property<Guid?>("branchid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("DeptId");

                    b.HasIndex("branchid");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("Eduzest.HRMS.Entities.Entities.Employee.Designation", b =>
                {
                    b.Property<Guid?>("DesigId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("desigid");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("createdby");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2")
                        .HasColumnName("createdon");

                    b.Property<string>("DesignationName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("designationname");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("isactive");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("updatedby");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2")
                        .HasColumnName("updatedon");

                    b.Property<Guid?>("branchid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("DesigId");

                    b.HasIndex("branchid");

                    b.ToTable("Designations");
                });

            modelBuilder.Entity("Eduzest.HRMS.Entities.Entities.Employee.EmployeeDetails", b =>
                {
                    b.Property<string>("EmployeeCode")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("employeecode");

                    b.Property<string>("BankAddress")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("bankaddress");

                    b.Property<string>("BankName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("bankname");

                    b.Property<string>("BloodGroup")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("bloodgroup");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("createdby");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2")
                        .HasColumnName("createdon");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2")
                        .HasColumnName("dateofbirth");

                    b.Property<DateTime?>("DateOfJoin")
                        .HasColumnType("datetime2")
                        .HasColumnName("dateofjoin");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("email");

                    b.Property<string>("EmployeeName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("employeename");

                    b.Property<string>("ExpDetails")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("expdetails");

                    b.Property<string>("FaceBook")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("facebook");

                    b.Property<string>("FatherName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("fathername");

                    b.Property<int?>("Gender")
                        .HasMaxLength(50)
                        .HasColumnType("int")
                        .HasColumnName("gender");

                    b.Property<string>("IfscCode")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("ifsccode");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("isactive");

                    b.Property<string>("LinkedIn")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("linkedin");

                    b.Property<string>("Mobile")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("mobile");

                    b.Property<string>("Password")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("password");

                    b.Property<string>("PermanentAddress")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("permanentaddress");

                    b.Property<string>("PresentAddress")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("presentaddress");

                    b.Property<string>("Qualification")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("qualification");

                    b.Property<string>("Religion")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("religion");

                    b.Property<bool?>("SkipBankdetails")
                        .HasColumnType("bit")
                        .HasColumnName("skipbankdetails");

                    b.Property<int?>("TotalExp")
                        .HasColumnType("int")
                        .HasColumnName("totalexp");

                    b.Property<string>("Twitter")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("twitter");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("updatedby");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2")
                        .HasColumnName("updatedon");

                    b.Property<string>("UserName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("username");

                    b.Property<Guid?>("branchid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("deptid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("desigid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("profilepicture")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("profilepicture");

                    b.HasKey("EmployeeCode");

                    b.HasIndex("branchid");

                    b.HasIndex("deptid");

                    b.HasIndex("desigid");

                    b.ToTable("EmployeeDetails");
                });

            modelBuilder.Entity("Eduzest.HRMS.Entities.Entities.Hrms.Allowances", b =>
                {
                    b.Property<Guid?>("AllowanceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("allowanceid");

                    b.Property<string>("AllowanceName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("allowancename");

                    b.Property<float?>("Ammount")
                        .HasColumnType("real")
                        .HasColumnName("ammount");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("createdby");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2")
                        .HasColumnName("createdon");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("isactive");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("updatedby");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2")
                        .HasColumnName("updatedon");

                    b.Property<Guid?>("salarytemplate")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AllowanceId");

                    b.HasIndex("salarytemplate");

                    b.ToTable("Allowances");
                });

            modelBuilder.Entity("Eduzest.HRMS.Entities.Entities.Hrms.Deduction", b =>
                {
                    b.Property<Guid?>("DeductionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("deductionid");

                    b.Property<float?>("Ammount")
                        .HasColumnType("real")
                        .HasColumnName("ammount");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("createdby");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2")
                        .HasColumnName("createdon");

                    b.Property<string>("DeductionName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("deductionname");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("isactive");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("updatedby");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2")
                        .HasColumnName("updatedon");

                    b.Property<Guid?>("salarytemplateid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("DeductionId");

                    b.HasIndex("salarytemplateid");

                    b.ToTable("Deductions");
                });

            modelBuilder.Entity("Eduzest.HRMS.Entities.Entities.Hrms.ExperienceDetails", b =>
                {
                    b.Property<Guid?>("ExperienceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("experienceid");

                    b.Property<DateTime?>("AuthorizedBy")
                        .HasColumnType("datetime2")
                        .HasColumnName("authorizedby");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("createdby");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2")
                        .HasColumnName("createdon");

                    b.Property<string>("EmpCodeEmployeeCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("FromDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("fromdate");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("isactive");

                    b.Property<DateTime?>("ToDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("todate");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("updatedby");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2")
                        .HasColumnName("updatedon");

                    b.HasKey("ExperienceId");

                    b.HasIndex("EmpCodeEmployeeCode");

                    b.ToTable("ExperienceDetails");
                });

            modelBuilder.Entity("Eduzest.HRMS.Entities.Entities.Hrms.RelievingDetails", b =>
                {
                    b.Property<Guid?>("RelievingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("relievingid");

                    b.Property<DateTime?>("AuthorizedBy")
                        .HasColumnType("datetime2")
                        .HasColumnName("authorizedby");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("createdby");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2")
                        .HasColumnName("createdon");

                    b.Property<DateTime?>("DateOfRelease")
                        .HasColumnType("datetime2")
                        .HasColumnName("dateofrelease");

                    b.Property<string>("EmpCodeEmployeeCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("FromDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("fromdate");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("isactive");

                    b.Property<DateTime?>("ToDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("todate");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("updatedby");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2")
                        .HasColumnName("updatedon");

                    b.HasKey("RelievingId");

                    b.HasIndex("EmpCodeEmployeeCode");

                    b.ToTable("RelievingDetails");
                });

            modelBuilder.Entity("Eduzest.HRMS.Entities.Entities.Hrms.SalaryAssignment", b =>
                {
                    b.Property<Guid?>("AssignId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("assignid");

                    b.Property<string>("AccountNumber")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("accountnumber");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("createdby");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2")
                        .HasColumnName("createdon");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("isactive");

                    b.Property<float?>("NetSalary")
                        .HasColumnType("real")
                        .HasColumnName("netsalary");

                    b.Property<float?>("OverTimeAmmount")
                        .HasColumnType("real")
                        .HasColumnName("overtimeamount");

                    b.Property<int?>("OverTimeTotalHour")
                        .HasColumnType("int")
                        .HasColumnName("overtimetotalhour");

                    b.Property<string>("PayVia")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("payvia");

                    b.Property<string>("Remark")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("remark");

                    b.Property<float?>("TotalAllowance")
                        .HasColumnType("real")
                        .HasColumnName("totalallowance");

                    b.Property<float?>("TotalDeduction")
                        .HasColumnType("real")
                        .HasColumnName("totaldeduction");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("updatedby");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2")
                        .HasColumnName("updatedon");

                    b.Property<string>("employeecode")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("AssignId");

                    b.HasIndex("employeecode");

                    b.ToTable("SalaryAssignments");
                });

            modelBuilder.Entity("Eduzest.HRMS.Entities.Entities.Hrms.SalaryTemplate", b =>
                {
                    b.Property<Guid?>("SalaryTemplateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("salarytemplateid");

                    b.Property<float?>("BasicSalary")
                        .HasColumnType("real")
                        .HasColumnName("basicsalary");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("createdby");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2")
                        .HasColumnName("createdon");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("isactive");

                    b.Property<float?>("NetSalary")
                        .HasColumnType("real")
                        .HasColumnName("netsalary");

                    b.Property<float?>("OverTimeRate")
                        .HasColumnType("real")
                        .HasColumnName("overtimerate");

                    b.Property<string>("SalaryGrade")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("salarygrade");

                    b.Property<float?>("TotalAllowances")
                        .HasColumnType("real")
                        .HasColumnName("totalallowances");

                    b.Property<float?>("TotalDeduction")
                        .HasColumnType("real")
                        .HasColumnName("totaldeduction");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("updatedby");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2")
                        .HasColumnName("updatedon");

                    b.HasKey("SalaryTemplateId");

                    b.ToTable("SalaryTemplates");
                });

            modelBuilder.Entity("Eduzest.HRMS.Entities.Entities.Employee.Department", b =>
                {
                    b.HasOne("Eduzest.HRMS.Entities.Entities.Employee.Branch", "Branch")
                        .WithMany()
                        .HasForeignKey("branchid");

                    b.Navigation("Branch");
                });

            modelBuilder.Entity("Eduzest.HRMS.Entities.Entities.Employee.Designation", b =>
                {
                    b.HasOne("Eduzest.HRMS.Entities.Entities.Employee.Branch", "Branch")
                        .WithMany()
                        .HasForeignKey("branchid");

                    b.Navigation("Branch");
                });

            modelBuilder.Entity("Eduzest.HRMS.Entities.Entities.Employee.EmployeeDetails", b =>
                {
                    b.HasOne("Eduzest.HRMS.Entities.Entities.Employee.Branch", "Brach")
                        .WithMany()
                        .HasForeignKey("branchid");

                    b.HasOne("Eduzest.HRMS.Entities.Entities.Employee.Department", "DeptId")
                        .WithMany()
                        .HasForeignKey("deptid");

                    b.HasOne("Eduzest.HRMS.Entities.Entities.Employee.Designation", "DesigId")
                        .WithMany()
                        .HasForeignKey("desigid");

                    b.Navigation("Brach");

                    b.Navigation("DeptId");

                    b.Navigation("DesigId");
                });

            modelBuilder.Entity("Eduzest.HRMS.Entities.Entities.Hrms.Allowances", b =>
                {
                    b.HasOne("Eduzest.HRMS.Entities.Entities.Hrms.SalaryTemplate", "SalaryTemplate")
                        .WithMany()
                        .HasForeignKey("salarytemplate");

                    b.Navigation("SalaryTemplate");
                });

            modelBuilder.Entity("Eduzest.HRMS.Entities.Entities.Hrms.Deduction", b =>
                {
                    b.HasOne("Eduzest.HRMS.Entities.Entities.Hrms.SalaryTemplate", "SalaryTemplate")
                        .WithMany()
                        .HasForeignKey("salarytemplateid");

                    b.Navigation("SalaryTemplate");
                });

            modelBuilder.Entity("Eduzest.HRMS.Entities.Entities.Hrms.ExperienceDetails", b =>
                {
                    b.HasOne("Eduzest.HRMS.Entities.Entities.Employee.EmployeeDetails", "EmpCode")
                        .WithMany()
                        .HasForeignKey("EmpCodeEmployeeCode");

                    b.Navigation("EmpCode");
                });

            modelBuilder.Entity("Eduzest.HRMS.Entities.Entities.Hrms.RelievingDetails", b =>
                {
                    b.HasOne("Eduzest.HRMS.Entities.Entities.Employee.EmployeeDetails", "EmpCode")
                        .WithMany()
                        .HasForeignKey("EmpCodeEmployeeCode");

                    b.Navigation("EmpCode");
                });

            modelBuilder.Entity("Eduzest.HRMS.Entities.Entities.Hrms.SalaryAssignment", b =>
                {
                    b.HasOne("Eduzest.HRMS.Entities.Entities.Employee.EmployeeDetails", "EmployeeCode")
                        .WithMany()
                        .HasForeignKey("employeecode");

                    b.Navigation("EmployeeCode");
                });
#pragma warning restore 612, 618
        }
    }
}
