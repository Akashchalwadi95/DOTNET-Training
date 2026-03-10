using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PulseDummy.Server.Models;

namespace PulseDummy.Server.Context;

public partial class TrainingEdotContext : DbContext
{
    public TrainingEdotContext()
    {
    }

    public TrainingEdotContext(DbContextOptions<TrainingEdotContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<AdminAddress> AdminAddresses { get; set; }

    public virtual DbSet<ContactMessage> ContactMessages { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomerHist> CustomerHists { get; set; }

    public virtual DbSet<DeliveryAddress> DeliveryAddresses { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Hobby> Hobbies { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<PulseDummyTable> PulseDummyTables { get; set; }

    public virtual DbSet<Report> Reports { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Test> Tests { get; set; }

    public virtual DbSet<TodoDatum> TodoData { get; set; }

    public virtual DbSet<TodoUser> TodoUsers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserFamily> UserFamilies { get; set; }

    public virtual DbSet<UserFile> UserFiles { get; set; }

    public virtual DbSet<UserHobbiesBridge> UserHobbiesBridges { get; set; }

    public virtual DbSet<WarehouseAddress> WarehouseAddresses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=192.168.2.55;Initial Catalog=Training;User ID=training;Password=training1!;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.AdminId).HasName("PK__Admins__719FE488BFEB3B61");

            entity.HasIndex(e => e.Email, "UQ__Admins__A9D105349E9BC29F").IsUnique();

            entity.Property(e => e.AliasName).HasMaxLength(150);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(200);
            entity.Property(e => e.Name).HasMaxLength(150);
            entity.Property(e => e.PasswordHash).HasMaxLength(255);
            entity.Property(e => e.Phone).HasMaxLength(15);
            entity.Property(e => e.Title).HasMaxLength(10);

            entity.HasOne(d => d.Address).WithMany(p => p.Admins)
                .HasForeignKey(d => d.AddressId)
                .HasConstraintName("FK_Admin_Address");
        });

        modelBuilder.Entity<AdminAddress>(entity =>
        {
            entity.HasKey(e => e.AddressId).HasName("PK__AdminAdd__091C2AFBF4AB18C1");

            entity.ToTable("AdminAddress");

            entity.Property(e => e.City).HasMaxLength(100);
            entity.Property(e => e.Country).HasMaxLength(100);
            entity.Property(e => e.HouseName).HasMaxLength(100);
            entity.Property(e => e.HouseNo).HasMaxLength(50);
            entity.Property(e => e.Landmark).HasMaxLength(150);
            entity.Property(e => e.Locality).HasMaxLength(150);
            entity.Property(e => e.Pincode).HasMaxLength(10);
            entity.Property(e => e.State).HasMaxLength(100);
        });

        modelBuilder.Entity<ContactMessage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ContactM__3214EC07C22F8383");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Subject).HasMaxLength(100);
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.CountryId).HasName("PK__Country__10D1609F77D40DBB");

            entity.ToTable("Country");

            entity.Property(e => e.CountryCode).HasMaxLength(5);
            entity.Property(e => e.CountryName).HasMaxLength(50);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64B813A0C74C");

            entity.ToTable(tb => tb.HasTrigger("tr_History_forUpdateDelete"));

            entity.HasIndex(e => e.Email, "UQ__Customer__A9D1053411805E31").IsUnique();

            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.City).HasMaxLength(50);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.PhoneNumber).HasMaxLength(15);
        });

        modelBuilder.Entity<CustomerHist>(entity =>
        {
            entity.HasKey(e => e.HistId).HasName("PK__Customer__E1BE56CD432DE8C8");

            entity.ToTable("Customer_hist");

            entity.Property(e => e.HistId).HasColumnName("HistID");
            entity.Property(e => e.City).HasMaxLength(50);
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.OperationDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.OperationType).HasMaxLength(10);
            entity.Property(e => e.PhoneNumber).HasMaxLength(15);
        });

        modelBuilder.Entity<DeliveryAddress>(entity =>
        {
            entity.HasKey(e => e.DeliveryAddressId).HasName("PK__Delivery__4EBD54DCF2967004");

            entity.Property(e => e.DeliveryAddressId).HasColumnName("DeliveryAddressID");
            entity.Property(e => e.City).HasMaxLength(100);
            entity.Property(e => e.Country).HasMaxLength(100);
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.PostalCode).HasMaxLength(10);
            entity.Property(e => e.State).HasMaxLength(100);
            entity.Property(e => e.Street).HasMaxLength(255);
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Departmentsid).HasName("PK__Departme__B8AD0BC18064876A");

            entity.Property(e => e.Departmentsid).HasColumnName("departmentsid");
            entity.Property(e => e.CreatedBy).HasColumnName("createdBy");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdOn");
            entity.Property(e => e.DepartmentName)
                .HasMaxLength(100)
                .HasColumnName("departmentName");
            entity.Property(e => e.Description).HasMaxLength(250);
            entity.Property(e => e.EditedBy).HasColumnName("editedBy");
            entity.Property(e => e.EditedOn)
                .HasColumnType("datetime")
                .HasColumnName("editedOn");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.DepartmentCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK_Departments_CreatedBy");

            entity.HasOne(d => d.EditedByNavigation).WithMany(p => p.DepartmentEditedByNavigations)
                .HasForeignKey(d => d.EditedBy)
                .HasConstraintName("FK_Departments_EditedBy");
        });

        modelBuilder.Entity<Hobby>(entity =>
        {
            entity.HasKey(e => e.HobbyId).HasName("PK__Hobbies__0ABE0BCFE912248D");

            entity.HasIndex(e => e.HobbyName, "UQ_Hobbies_HobbyName").IsUnique();

            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdOn");
            entity.Property(e => e.HobbyName).HasMaxLength(50);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Orders__C3905BAFEC01566F");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.OrderDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Orders_Customers");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.OrderDetailId).HasName("PK__OrderDet__D3B9D30C955B11AD");

            entity.Property(e => e.OrderDetailId).HasColumnName("OrderDetailID");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK_OrderDetails_Order");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__OrderDeta__Produ__748F2482");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Products__B40CC6CD35330A20");

            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.ProductName)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PulseDummyTable>(entity =>
        {
            entity.HasKey(e => e.Email).HasName("PK__PulseDum__A9D105350170D1C7");

            entity.ToTable("PulseDummyTable");

            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Report>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__reports__3213E83FD9292EA7");

            entity.ToTable("reports");

            entity.HasIndex(e => e.Status, "idx_status");

            entity.HasIndex(e => e.TestId, "idx_test_id");

            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.ReportDate).HasColumnName("report_date");
            entity.Property(e => e.ReportType)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("report_type");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("Pending")
                .HasColumnName("status");
            entity.Property(e => e.TestId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .HasColumnName("test_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Test).WithMany(p => p.Reports)
                .HasForeignKey(d => d.TestId)
                .HasConstraintName("FK_reports_tests");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Rollno).HasName("PK__student__FABA8B5B575A9875");

            entity.ToTable("student");

            entity.Property(e => e.Rollno)
                .ValueGeneratedNever()
                .HasColumnName("rollno");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Test>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tests__3213E83FDB27F3A1");

            entity.ToTable("tests");

            entity.HasIndex(e => e.TestType, "idx_test_type");

            entity.HasIndex(e => e.VesselName, "idx_vessel_name");

            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.OtherValue)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("other_value");
            entity.Property(e => e.TestName)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("test_name");
            entity.Property(e => e.TestType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("test_type");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.VesselName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("vessel_name");
        });

        modelBuilder.Entity<TodoDatum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__todo__3214EC0754B59230");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TodoUser>(entity =>
        {
            entity.HasKey(e => e.Email).HasName("PK__TodoUser__A9D10535418FC30D");

            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("Admin");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Usersid).HasName("PK__Users__788CD93DA307EAC3");

            entity.HasIndex(e => e.UserName, "UQ__Users__66DCF95C6737063D").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Users__AB6E61647F4ABCF6").IsUnique();

            entity.Property(e => e.Usersid).HasColumnName("usersid");
            entity.Property(e => e.Country)
                .HasMaxLength(50)
                .HasColumnName("country");
            entity.Property(e => e.CreatedBy).HasColumnName("createdBy");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdOn");
            entity.Property(e => e.DateOfBirth).HasColumnName("dateOfBirth");
            entity.Property(e => e.Departmentsid).HasColumnName("departmentsid");
            entity.Property(e => e.EditedBy).HasColumnName("editedBy");
            entity.Property(e => e.EditedOn)
                .HasColumnType("datetime")
                .HasColumnName("editedOn");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("firstName");
            entity.Property(e => e.Image).HasColumnName("image");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("lastName");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .HasColumnName("phoneNumber");
            entity.Property(e => e.Salary)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("salary");
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .HasColumnName("userName");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.InverseCreatedByNavigation)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK_User_CreatedBy");

            entity.HasOne(d => d.Departments).WithMany(p => p.Users)
                .HasForeignKey(d => d.Departmentsid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Departments");

            entity.HasOne(d => d.EditedByNavigation).WithMany(p => p.InverseEditedByNavigation)
                .HasForeignKey(d => d.EditedBy)
                .HasConstraintName("FK_User_EditedBy");
        });

        modelBuilder.Entity<UserFamily>(entity =>
        {
            entity.HasKey(e => e.UserfamilyId).HasName("PK__UserFami__4E05936F5F8AE7D9");

            entity.ToTable("UserFamily");

            entity.Property(e => e.Contact)
                .HasMaxLength(20)
                .HasColumnName("contact");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("firstName");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("lastName");
            entity.Property(e => e.Relation)
                .HasMaxLength(50)
                .HasColumnName("relation");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.User).WithMany(p => p.UserFamilies)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_UserFamily_User");
        });

        modelBuilder.Entity<UserFile>(entity =>
        {
            entity.HasKey(e => e.UserFilesId).HasName("PK__UserFile__7585A51B9B012E35");

            entity.Property(e => e.CreatedBy).HasColumnName("createdBy");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdOn");
            entity.Property(e => e.EditedBy).HasColumnName("editedBy");
            entity.Property(e => e.EditedOn)
                .HasColumnType("datetime")
                .HasColumnName("editedOn");
            entity.Property(e => e.FileContent).HasColumnName("fileContent");
            entity.Property(e => e.FileName)
                .HasMaxLength(255)
                .HasColumnName("fileName");
            entity.Property(e => e.FileSize).HasColumnName("fileSize");
            entity.Property(e => e.FileType)
                .HasMaxLength(50)
                .HasColumnName("fileType");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.UserFileCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK_UserFiles_CreatedBy");

            entity.HasOne(d => d.EditedByNavigation).WithMany(p => p.UserFileEditedByNavigations)
                .HasForeignKey(d => d.EditedBy)
                .HasConstraintName("FK_UserFiles_EditedBy");

            entity.HasOne(d => d.User).WithMany(p => p.UserFileUsers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserFiles_User");
        });

        modelBuilder.Entity<UserHobbiesBridge>(entity =>
        {
            entity.HasKey(e => e.UserHobbiesBridge1).HasName("PK__UserHobb__CB3D049CDBE8608E");

            entity.ToTable("UserHobbiesBridge");

            entity.HasIndex(e => new { e.UserId, e.HobbyId }, "UQ_User_Hobby").IsUnique();

            entity.Property(e => e.UserHobbiesBridge1).HasColumnName("UserHobbiesBridge");
            entity.Property(e => e.HobbyId).HasColumnName("hobbyId");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.Hobby).WithMany(p => p.UserHobbiesBridges)
                .HasForeignKey(d => d.HobbyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UHB_Hobby");

            entity.HasOne(d => d.User).WithMany(p => p.UserHobbiesBridges)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_UHB_User");
        });

        modelBuilder.Entity<WarehouseAddress>(entity =>
        {
            entity.HasKey(e => e.WarehouseId).HasName("PK__Warehous__2608AFD95E3C2E42");

            entity.Property(e => e.WarehouseId).HasColumnName("WarehouseID");
            entity.Property(e => e.City).HasMaxLength(100);
            entity.Property(e => e.Country).HasMaxLength(100);
            entity.Property(e => e.PostalCode).HasMaxLength(10);
            entity.Property(e => e.State).HasMaxLength(100);
            entity.Property(e => e.Street).HasMaxLength(255);
            entity.Property(e => e.WarehouseName).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
