using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace OAinternship.Models;

public partial class MytestserverContext : DbContext
{
    public MytestserverContext()
    {
    }

    public MytestserverContext(DbContextOptions<MytestserverContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<BuildVersion> BuildVersions { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomerAddress> CustomerAddresses { get; set; }

    public virtual DbSet<ErrorLog> ErrorLogs { get; set; }

    public virtual DbSet<Hospital> Hospitals { get; set; }

    public virtual DbSet<HospitalType> HospitalTypes { get; set; }

    public virtual DbSet<MedicalCaregiver> MedicalCaregivers { get; set; }

    public virtual DbSet<MedicalCaregiverType> MedicalCaregiverTypes { get; set; }

    public virtual DbSet<MedicalRecord> MedicalRecords { get; set; }

    public virtual DbSet<MedicalTransaction> MedicalTransactions { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<PatientEvent> PatientEvents { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductCategory> ProductCategories { get; set; }

    public virtual DbSet<ProductDescription> ProductDescriptions { get; set; }

    public virtual DbSet<ProductModel> ProductModels { get; set; }

    public virtual DbSet<ProductModelProductDescription> ProductModelProductDescriptions { get; set; }

    public virtual DbSet<SalesOrderDetail> SalesOrderDetails { get; set; }

    public virtual DbSet<SalesOrderHeader> SalesOrderHeaders { get; set; }

    public virtual DbSet<VGetAllCategory> VGetAllCategories { get; set; }

    public virtual DbSet<VHospital> VHospitals { get; set; }

    public virtual DbSet<VMedicalTransaction> VMedicalTransactions { get; set; }

    public virtual DbSet<VPatient> VPatients { get; set; }

    public virtual DbSet<VProductAndDescription> VProductAndDescriptions { get; set; }

    public virtual DbSet<VProductModelCatalogDescription> VProductModelCatalogDescriptions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=tcp:oatestserver.database.windows.net,1433;Initial Catalog=mytestserver;Persist Security Info=False;User ID=azureuser;Password=Databasepass1!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.AddressId).HasName("PK_Address_AddressID");

            entity.ToTable("Address", "SalesLT");

            entity.HasIndex(e => e.Rowguid, "AK_Address_rowguid").IsUnique();

            entity.HasIndex(e => new { e.AddressLine1, e.AddressLine2, e.City, e.StateProvince, e.PostalCode, e.CountryRegion }, "IX_Address_AddressLine1_AddressLine2_City_StateProvince_PostalCode_CountryRegion");

            entity.HasIndex(e => e.StateProvince, "IX_Address_StateProvince");

            entity.Property(e => e.AddressId).HasColumnName("AddressID");
            entity.Property(e => e.AddressLine1).HasMaxLength(60);
            entity.Property(e => e.AddressLine2).HasMaxLength(60);
            entity.Property(e => e.City).HasMaxLength(30);
            entity.Property(e => e.CountryRegion).HasMaxLength(50);
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.PostalCode).HasMaxLength(15);
            entity.Property(e => e.Rowguid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("rowguid");
            entity.Property(e => e.StateProvince).HasMaxLength(50);
        });

        modelBuilder.Entity<BuildVersion>(entity =>
        {
            entity.HasKey(e => e.SystemInformationId).HasName("PK__BuildVer__35E58ECA8653F2DE");

            entity.ToTable("BuildVersion");

            entity.Property(e => e.SystemInformationId)
                .ValueGeneratedOnAdd()
                .HasColumnName("SystemInformationID");
            entity.Property(e => e.DatabaseVersion)
                .HasMaxLength(25)
                .HasColumnName("Database Version");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.VersionDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK_Customer_CustomerID");

            entity.ToTable("Customer", "SalesLT");

            entity.HasIndex(e => e.Rowguid, "AK_Customer_rowguid").IsUnique();

            entity.HasIndex(e => e.EmailAddress, "IX_Customer_EmailAddress");

            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.CompanyName).HasMaxLength(128);
            entity.Property(e => e.EmailAddress).HasMaxLength(50);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.MiddleName).HasMaxLength(50);
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.PasswordSalt)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Phone).HasMaxLength(25);
            entity.Property(e => e.Rowguid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("rowguid");
            entity.Property(e => e.SalesPerson).HasMaxLength(256);
            entity.Property(e => e.Suffix).HasMaxLength(10);
            entity.Property(e => e.Title).HasMaxLength(8);
        });

        modelBuilder.Entity<CustomerAddress>(entity =>
        {
            entity.HasKey(e => new { e.CustomerId, e.AddressId }).HasName("PK_CustomerAddress_CustomerID_AddressID");

            entity.ToTable("CustomerAddress", "SalesLT");

            entity.HasIndex(e => e.Rowguid, "AK_CustomerAddress_rowguid").IsUnique();

            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.AddressId).HasColumnName("AddressID");
            entity.Property(e => e.AddressType).HasMaxLength(50);
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Rowguid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("rowguid");

            entity.HasOne(d => d.Address).WithMany(p => p.CustomerAddresses)
                .HasForeignKey(d => d.AddressId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Customer).WithMany(p => p.CustomerAddresses)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<ErrorLog>(entity =>
        {
            entity.HasKey(e => e.ErrorLogId).HasName("PK_ErrorLog_ErrorLogID");

            entity.ToTable("ErrorLog");

            entity.Property(e => e.ErrorLogId).HasColumnName("ErrorLogID");
            entity.Property(e => e.ErrorMessage).HasMaxLength(4000);
            entity.Property(e => e.ErrorProcedure).HasMaxLength(126);
            entity.Property(e => e.ErrorTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UserName).HasMaxLength(128);
        });

        modelBuilder.Entity<Hospital>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Hospital__3214EC27873C34D4");

            entity.ToTable("Hospital");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.HospitalAddress)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.HospitalName)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Type).WithMany(p => p.Hospitals)
                .HasForeignKey(d => d.TypeId)
                .HasConstraintName("FK_Hospital_HospitalType");
        });

        modelBuilder.Entity<HospitalType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Hospital__3214EC270FA8A2B0");

            entity.ToTable("HospitalType");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.HospitalType1)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("HospitalType");
        });

        modelBuilder.Entity<MedicalCaregiver>(entity =>
        {
            entity.HasKey(e => e.CaregiverId).HasName("PK__Medical___8EC5448B549AECBF");

            entity.ToTable("Medical_Caregiver");

            entity.Property(e => e.CaregiverId)
                .ValueGeneratedNever()
                .HasColumnName("Caregiver_Id");
            entity.Property(e => e.CaregiverAddress)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Caregiver_Address");
            entity.Property(e => e.CaregiverType).HasColumnName("Caregiver_Type");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("First_Name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Last_Name");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.CaregiverTypeNavigation).WithMany(p => p.MedicalCaregivers)
                .HasForeignKey(d => d.CaregiverType)
                .HasConstraintName("FK__Medical_C__Careg__55009F39");
        });

        modelBuilder.Entity<MedicalCaregiverType>(entity =>
        {
            entity.HasKey(e => e.CaregiverTypeId).HasName("PK__Medical___188C2CC9675756B0");

            entity.ToTable("Medical_Caregiver_Type");

            entity.Property(e => e.CaregiverTypeId)
                .ValueGeneratedNever()
                .HasColumnName("Caregiver_Type_Id");
            entity.Property(e => e.CaregiverTypeName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Caregiver_Type_Name");
        });

        modelBuilder.Entity<MedicalRecord>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MedicalR__3214EC27EFC15F99");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Info)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MedicalTransaction>(entity =>
        {
            entity.HasKey(e => e.RxNumber).HasName("PK__Medical___03B2AF23D2548754");

            entity.ToTable("Medical_Transactions");

            entity.Property(e => e.RxNumber).ValueGeneratedNever();
            entity.Property(e => e.CopayAmount)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("Copay_Amount");
            entity.Property(e => e.DateFilled).HasColumnName("Date_Filled");
            entity.Property(e => e.DaysSupply).HasColumnName("Days_Supply");
            entity.Property(e => e.DoctorId).HasColumnName("Doctor_Id");
            entity.Property(e => e.Ndc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NDC");
            entity.Property(e => e.NurseId).HasColumnName("Nurse_Id");
            entity.Property(e => e.PatientId).HasColumnName("Patient_id");
            entity.Property(e => e.PayerName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Payer_Name");
            entity.Property(e => e.TotalCost)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Total_Cost");
            entity.Property(e => e.TransactionFee)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("Transaction_Fee");

            entity.HasOne(d => d.Doctor).WithMany(p => p.MedicalTransactionDoctors)
                .HasForeignKey(d => d.DoctorId)
                .HasConstraintName("FK_Medical_Transaction_Doctor_Id");

            entity.HasOne(d => d.Nurse).WithMany(p => p.MedicalTransactionNurses)
                .HasForeignKey(d => d.NurseId)
                .HasConstraintName("FK_Medical_Transaction_Nurse_Id");

            entity.HasOne(d => d.Patient).WithMany(p => p.MedicalTransactions)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK_APPLICATION_ATTACHMENT");
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Patients__3214EC2783AAEC01");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Insurance)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.MedicalRecordId).HasColumnName("MedicalRecordID");
            entity.Property(e => e.PatientAddress)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.MedicalRecord).WithMany(p => p.Patients)
                .HasForeignKey(d => d.MedicalRecordId)
                .HasConstraintName("FK__Patients__Medica__42E1EEFE");
        });

        modelBuilder.Entity<PatientEvent>(entity =>
        {
            entity.HasKey(e => e.EventId).HasName("PK__Patient___FD6BEF841E42BCCA");

            entity.ToTable("Patient_Event");

            entity.Property(e => e.EventId)
                .ValueGeneratedNever()
                .HasColumnName("Event_Id");
            entity.Property(e => e.DateTime)
                .HasColumnType("datetime")
                .HasColumnName("Date_Time");
            entity.Property(e => e.EventDescription)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Event_Description");
            entity.Property(e => e.NurseId).HasColumnName("Nurse_Id");
            entity.Property(e => e.PatientId).HasColumnName("Patient_Id");

            entity.HasOne(d => d.Nurse).WithMany(p => p.PatientEvents)
                .HasForeignKey(d => d.NurseId)
                .HasConstraintName("FK__Patient_E__Nurse__58D1301D");

            entity.HasOne(d => d.Patient).WithMany(p => p.PatientEvents)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK__Patient_E__Patie__57DD0BE4");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK_Product_ProductID");

            entity.ToTable("Product", "SalesLT");

            entity.HasIndex(e => e.Name, "AK_Product_Name").IsUnique();

            entity.HasIndex(e => e.ProductNumber, "AK_Product_ProductNumber").IsUnique();

            entity.HasIndex(e => e.Rowguid, "AK_Product_rowguid").IsUnique();

            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.Color).HasMaxLength(15);
            entity.Property(e => e.DiscontinuedDate).HasColumnType("datetime");
            entity.Property(e => e.ListPrice).HasColumnType("money");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.ProductCategoryId).HasColumnName("ProductCategoryID");
            entity.Property(e => e.ProductModelId).HasColumnName("ProductModelID");
            entity.Property(e => e.ProductNumber).HasMaxLength(25);
            entity.Property(e => e.Rowguid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("rowguid");
            entity.Property(e => e.SellEndDate).HasColumnType("datetime");
            entity.Property(e => e.SellStartDate).HasColumnType("datetime");
            entity.Property(e => e.Size).HasMaxLength(5);
            entity.Property(e => e.StandardCost).HasColumnType("money");
            entity.Property(e => e.ThumbnailPhotoFileName).HasMaxLength(50);
            entity.Property(e => e.Weight).HasColumnType("decimal(8, 2)");

            entity.HasOne(d => d.ProductCategory).WithMany(p => p.Products).HasForeignKey(d => d.ProductCategoryId);

            entity.HasOne(d => d.ProductModel).WithMany(p => p.Products).HasForeignKey(d => d.ProductModelId);
        });

        modelBuilder.Entity<ProductCategory>(entity =>
        {
            entity.HasKey(e => e.ProductCategoryId).HasName("PK_ProductCategory_ProductCategoryID");

            entity.ToTable("ProductCategory", "SalesLT");

            entity.HasIndex(e => e.Name, "AK_ProductCategory_Name").IsUnique();

            entity.HasIndex(e => e.Rowguid, "AK_ProductCategory_rowguid").IsUnique();

            entity.Property(e => e.ProductCategoryId).HasColumnName("ProductCategoryID");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.ParentProductCategoryId).HasColumnName("ParentProductCategoryID");
            entity.Property(e => e.Rowguid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("rowguid");

            entity.HasOne(d => d.ParentProductCategory).WithMany(p => p.InverseParentProductCategory)
                .HasForeignKey(d => d.ParentProductCategoryId)
                .HasConstraintName("FK_ProductCategory_ProductCategory_ParentProductCategoryID_ProductCategoryID");
        });

        modelBuilder.Entity<ProductDescription>(entity =>
        {
            entity.HasKey(e => e.ProductDescriptionId).HasName("PK_ProductDescription_ProductDescriptionID");

            entity.ToTable("ProductDescription", "SalesLT");

            entity.HasIndex(e => e.Rowguid, "AK_ProductDescription_rowguid").IsUnique();

            entity.Property(e => e.ProductDescriptionId).HasColumnName("ProductDescriptionID");
            entity.Property(e => e.Description).HasMaxLength(400);
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Rowguid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("rowguid");
        });

        modelBuilder.Entity<ProductModel>(entity =>
        {
            entity.HasKey(e => e.ProductModelId).HasName("PK_ProductModel_ProductModelID");

            entity.ToTable("ProductModel", "SalesLT");

            entity.HasIndex(e => e.Name, "AK_ProductModel_Name").IsUnique();

            entity.HasIndex(e => e.Rowguid, "AK_ProductModel_rowguid").IsUnique();

            entity.Property(e => e.ProductModelId).HasColumnName("ProductModelID");
            entity.Property(e => e.CatalogDescription).HasColumnType("xml");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Rowguid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("rowguid");
        });

        modelBuilder.Entity<ProductModelProductDescription>(entity =>
        {
            entity.HasKey(e => new { e.ProductModelId, e.ProductDescriptionId, e.Culture }).HasName("PK_ProductModelProductDescription_ProductModelID_ProductDescriptionID_Culture");

            entity.ToTable("ProductModelProductDescription", "SalesLT");

            entity.HasIndex(e => e.Rowguid, "AK_ProductModelProductDescription_rowguid").IsUnique();

            entity.Property(e => e.ProductModelId).HasColumnName("ProductModelID");
            entity.Property(e => e.ProductDescriptionId).HasColumnName("ProductDescriptionID");
            entity.Property(e => e.Culture)
                .HasMaxLength(6)
                .IsFixedLength();
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Rowguid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("rowguid");

            entity.HasOne(d => d.ProductDescription).WithMany(p => p.ProductModelProductDescriptions)
                .HasForeignKey(d => d.ProductDescriptionId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.ProductModel).WithMany(p => p.ProductModelProductDescriptions)
                .HasForeignKey(d => d.ProductModelId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<SalesOrderDetail>(entity =>
        {
            entity.HasKey(e => new { e.SalesOrderId, e.SalesOrderDetailId }).HasName("PK_SalesOrderDetail_SalesOrderID_SalesOrderDetailID");

            entity.ToTable("SalesOrderDetail", "SalesLT");

            entity.HasIndex(e => e.Rowguid, "AK_SalesOrderDetail_rowguid").IsUnique();

            entity.HasIndex(e => e.ProductId, "IX_SalesOrderDetail_ProductID");

            entity.Property(e => e.SalesOrderId).HasColumnName("SalesOrderID");
            entity.Property(e => e.SalesOrderDetailId)
                .ValueGeneratedOnAdd()
                .HasColumnName("SalesOrderDetailID");
            entity.Property(e => e.LineTotal)
                .HasComputedColumnSql("(isnull(([UnitPrice]*((1.0)-[UnitPriceDiscount]))*[OrderQty],(0.0)))", false)
                .HasColumnType("numeric(38, 6)");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.Rowguid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("rowguid");
            entity.Property(e => e.UnitPrice).HasColumnType("money");
            entity.Property(e => e.UnitPriceDiscount).HasColumnType("money");

            entity.HasOne(d => d.Product).WithMany(p => p.SalesOrderDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.SalesOrder).WithMany(p => p.SalesOrderDetails).HasForeignKey(d => d.SalesOrderId);
        });

        modelBuilder.Entity<SalesOrderHeader>(entity =>
        {
            entity.HasKey(e => e.SalesOrderId).HasName("PK_SalesOrderHeader_SalesOrderID");

            entity.ToTable("SalesOrderHeader", "SalesLT");

            entity.HasIndex(e => e.SalesOrderNumber, "AK_SalesOrderHeader_SalesOrderNumber").IsUnique();

            entity.HasIndex(e => e.Rowguid, "AK_SalesOrderHeader_rowguid").IsUnique();

            entity.HasIndex(e => e.CustomerId, "IX_SalesOrderHeader_CustomerID");

            entity.Property(e => e.SalesOrderId)
                .HasDefaultValueSql("(NEXT VALUE FOR [SalesLT].[SalesOrderNumber])")
                .HasColumnName("SalesOrderID");
            entity.Property(e => e.AccountNumber).HasMaxLength(15);
            entity.Property(e => e.BillToAddressId).HasColumnName("BillToAddressID");
            entity.Property(e => e.CreditCardApprovalCode)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.DueDate).HasColumnType("datetime");
            entity.Property(e => e.Freight).HasColumnType("money");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.OnlineOrderFlag).HasDefaultValue(true);
            entity.Property(e => e.OrderDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.PurchaseOrderNumber).HasMaxLength(25);
            entity.Property(e => e.Rowguid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("rowguid");
            entity.Property(e => e.SalesOrderNumber)
                .HasMaxLength(25)
                .HasComputedColumnSql("(isnull(N'SO'+CONVERT([nvarchar](23),[SalesOrderID],(0)),N'*** ERROR ***'))", false);
            entity.Property(e => e.ShipDate).HasColumnType("datetime");
            entity.Property(e => e.ShipMethod).HasMaxLength(50);
            entity.Property(e => e.ShipToAddressId).HasColumnName("ShipToAddressID");
            entity.Property(e => e.Status).HasDefaultValue((byte)1);
            entity.Property(e => e.SubTotal).HasColumnType("money");
            entity.Property(e => e.TaxAmt).HasColumnType("money");
            entity.Property(e => e.TotalDue)
                .HasComputedColumnSql("(isnull(([SubTotal]+[TaxAmt])+[Freight],(0)))", false)
                .HasColumnType("money");

            entity.HasOne(d => d.BillToAddress).WithMany(p => p.SalesOrderHeaderBillToAddresses)
                .HasForeignKey(d => d.BillToAddressId)
                .HasConstraintName("FK_SalesOrderHeader_Address_BillTo_AddressID");

            entity.HasOne(d => d.Customer).WithMany(p => p.SalesOrderHeaders)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.ShipToAddress).WithMany(p => p.SalesOrderHeaderShipToAddresses)
                .HasForeignKey(d => d.ShipToAddressId)
                .HasConstraintName("FK_SalesOrderHeader_Address_ShipTo_AddressID");
        });

        modelBuilder.Entity<VGetAllCategory>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vGetAllCategories", "SalesLT");

            entity.Property(e => e.ParentProductCategoryName).HasMaxLength(50);
            entity.Property(e => e.ProductCategoryId).HasColumnName("ProductCategoryID");
            entity.Property(e => e.ProductCategoryName).HasMaxLength(50);
        });

        modelBuilder.Entity<VHospital>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_Hospital");

            entity.Property(e => e.HospitalName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VMedicalTransaction>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_Medical_Transactions");

            entity.Property(e => e.DoctorFirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Doctor_FirstName");
            entity.Property(e => e.DoctorLastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Doctor_LastName");
            entity.Property(e => e.NurseFirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Nurse_FirstName");
            entity.Property(e => e.NurseLastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Nurse_LastName");
            entity.Property(e => e.PatientFirstName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Patient_FirstName");
            entity.Property(e => e.PatientId).HasColumnName("Patient_Id");
            entity.Property(e => e.PatientLastName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Patient_LastName");
            entity.Property(e => e.TotalCost)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Total_Cost");
            entity.Property(e => e.TransactionDate).HasColumnName("Transaction_Date");
        });

        modelBuilder.Entity<VPatient>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_Patients");

            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.HospitalName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Info)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PatientAddress)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TransactionCount).HasColumnName("Transaction_Count");
        });

        modelBuilder.Entity<VProductAndDescription>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vProductAndDescription", "SalesLT");

            entity.Property(e => e.Culture)
                .HasMaxLength(6)
                .IsFixedLength();
            entity.Property(e => e.Description).HasMaxLength(400);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.ProductModel).HasMaxLength(50);
        });

        modelBuilder.Entity<VProductModelCatalogDescription>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vProductModelCatalogDescription", "SalesLT");

            entity.Property(e => e.Color).HasMaxLength(256);
            entity.Property(e => e.Copyright).HasMaxLength(30);
            entity.Property(e => e.Crankset).HasMaxLength(256);
            entity.Property(e => e.MaintenanceDescription).HasMaxLength(256);
            entity.Property(e => e.Material).HasMaxLength(256);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.NoOfYears).HasMaxLength(256);
            entity.Property(e => e.Pedal).HasMaxLength(256);
            entity.Property(e => e.PictureAngle).HasMaxLength(256);
            entity.Property(e => e.PictureSize).HasMaxLength(256);
            entity.Property(e => e.ProductLine).HasMaxLength(256);
            entity.Property(e => e.ProductModelId)
                .ValueGeneratedOnAdd()
                .HasColumnName("ProductModelID");
            entity.Property(e => e.ProductPhotoId)
                .HasMaxLength(256)
                .HasColumnName("ProductPhotoID");
            entity.Property(e => e.ProductUrl)
                .HasMaxLength(256)
                .HasColumnName("ProductURL");
            entity.Property(e => e.RiderExperience).HasMaxLength(1024);
            entity.Property(e => e.Rowguid).HasColumnName("rowguid");
            entity.Property(e => e.Saddle).HasMaxLength(256);
            entity.Property(e => e.Style).HasMaxLength(256);
            entity.Property(e => e.WarrantyDescription).HasMaxLength(256);
            entity.Property(e => e.WarrantyPeriod).HasMaxLength(256);
            entity.Property(e => e.Wheel).HasMaxLength(256);
        });
        modelBuilder.HasSequence<int>("SalesOrderNumber", "SalesLT");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
