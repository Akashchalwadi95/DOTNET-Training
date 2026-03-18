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

    public virtual DbSet<AdminUser> AdminUsers { get; set; }

    public virtual DbSet<AppUser> AppUsers { get; set; }

    public virtual DbSet<CartItem> CartItems { get; set; }

    public virtual DbSet<CompanyDepartment> CompanyDepartments { get; set; }

    public virtual DbSet<ContactMessage> ContactMessages { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<CountryDatum> CountryData { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomerHist> CustomerHists { get; set; }

    public virtual DbSet<DeliveryAddress> DeliveryAddresses { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Department1> Departments1 { get; set; }

    public virtual DbSet<DepartmentsDetail> DepartmentsDetails { get; set; }

    public virtual DbSet<DeptDatum> DeptData { get; set; }

    public virtual DbSet<EmployeeProjectsDetail> EmployeeProjectsDetails { get; set; }

    public virtual DbSet<EmployeesDetail> EmployeesDetails { get; set; }

    public virtual DbSet<FileUpload> FileUploads { get; set; }

    public virtual DbSet<HobbiesBridgeDatum> HobbiesBridgeData { get; set; }

    public virtual DbSet<Hobby> Hobbies { get; set; }

    public virtual DbSet<HobbyDatum> HobbyData { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductAppUser> ProductAppUsers { get; set; }

    public virtual DbSet<ProductsAppOrder> ProductsAppOrders { get; set; }

    public virtual DbSet<ProductsAppOrderDetail> ProductsAppOrderDetails { get; set; }

    public virtual DbSet<ProductsDatum> ProductsData { get; set; }

    public virtual DbSet<ProjectDetail> ProjectDetails { get; set; }

    public virtual DbSet<PulseDummyTable> PulseDummyTables { get; set; }

    public virtual DbSet<Report> Reports { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Test> Tests { get; set; }

    public virtual DbSet<TodoDatum> TodoData { get; set; }

    public virtual DbSet<TodoUser> TodoUsers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserDatum> UserData { get; set; }

    public virtual DbSet<UserDetail> UserDetails { get; set; }

    public virtual DbSet<UserDetailsBackup> UserDetailsBackups { get; set; }

    public virtual DbSet<UserFamily> UserFamilies { get; set; }

    public virtual DbSet<UserFamilyDatum> UserFamilyData { get; set; }

    public virtual DbSet<UserFile> UserFiles { get; set; }

    public virtual DbSet<UserHist> UserHists { get; set; }

    public virtual DbSet<UserHobbiesBridge> UserHobbiesBridges { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

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
            entity.Property(e => e.ProfileImage).HasMaxLength(255);
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

        modelBuilder.Entity<AdminUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AdminUse__3214EC0780E2C796");

            entity.HasIndex(e => e.Username, "UQ__AdminUse__536C85E42F725138").IsUnique();

            entity.Property(e => e.Password).HasMaxLength(100);
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        modelBuilder.Entity<AppUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AppUsers__3214EC079B8712A1");

            entity.HasIndex(e => e.Username, "UQ__AppUsers__536C85E4F1ACFCB3").IsUnique();

            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        modelBuilder.Entity<CartItem>(entity =>
        {
            entity.HasKey(e => e.CartId).HasName("PK__CartItem__51BCD7B7A1577202");

            entity.Property(e => e.AddedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ImageUrl).HasMaxLength(500);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ProductTitle).HasMaxLength(255);
            entity.Property(e => e.UserName).HasMaxLength(100);
        });

        modelBuilder.Entity<CompanyDepartment>(entity =>
        {
            entity.HasKey(e => e.CompanyDepartmentId).HasName("PK__CompanyD__89F2354D3D1BF9AF");

            entity.ToTable("CompanyDepartment");

            entity.Property(e => e.CompanyDepartmentId).HasColumnName("CompanyDepartmentID");
            entity.Property(e => e.DepartmentName)
                .HasMaxLength(30)
                .IsUnicode(false);
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

        modelBuilder.Entity<CountryDatum>(entity =>
        {
            entity.HasKey(e => e.CountryId).HasName("PK__CountryD__10D1609F5999BF2F");

            entity.Property(e => e.CountryName)
                .HasMaxLength(100)
                .IsUnicode(false);
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
            entity.HasKey(e => e.CompanyDepartmentId).HasName("PK__Departme__89F2354D4CBE8DF1");

            entity.ToTable("Department");

            entity.Property(e => e.CompanyDepartmentId).HasColumnName("CompanyDepartmentID");
            entity.Property(e => e.DepartmentName)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Department1>(entity =>
        {
            entity.HasKey(e => e.Departmentsid).HasName("PK__Departme__B8AD0BC18064876A");

            entity.ToTable("Departments");

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

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.Department1CreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK_Departments_CreatedBy");

            entity.HasOne(d => d.EditedByNavigation).WithMany(p => p.Department1EditedByNavigations)
                .HasForeignKey(d => d.EditedBy)
                .HasConstraintName("FK_Departments_EditedBy");
        });

        modelBuilder.Entity<DepartmentsDetail>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PK__Departme__B2079BCD7DA0EB15");

            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.DepartmentName).HasMaxLength(50);
            entity.Property(e => e.ManagerId).HasColumnName("ManagerID");

            entity.HasOne(d => d.Manager).WithMany(p => p.DepartmentsDetails)
                .HasForeignKey(d => d.ManagerId)
                .HasConstraintName("fk_EmployeesDetails");
        });

        modelBuilder.Entity<DeptDatum>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PK__DeptData__B2079BED233C7FC8");

            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DepartmentName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<EmployeeProjectsDetail>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

            entity.HasOne(d => d.Employee).WithMany()
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__EmployeeP__Emplo__036753BE");

            entity.HasOne(d => d.Project).WithMany()
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__EmployeeP__Proje__045B77F7");
        });

        modelBuilder.Entity<EmployeesDetail>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__7AD04FF14D569B99");

            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Salary).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Department).WithMany(p => p.EmployeesDetails)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_department");
        });

        modelBuilder.Entity<FileUpload>(entity =>
        {
            entity.HasKey(e => e.FileId).HasName("PK__FileUplo__6F0F98BF8D6B1E5E");

            entity.ToTable("FileUpload");

            entity.Property(e => e.FileName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.FilePath)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.FileType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UploadDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.User).WithMany(p => p.FileUploads)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__FileUploa__UserI__26B08FFB");
        });

        modelBuilder.Entity<HobbiesBridgeDatum>(entity =>
        {
            entity.HasKey(e => e.UserHobbyId).HasName("PK__HobbiesB__8201888876C8FCA6");

            entity.HasOne(d => d.Hobby).WithMany(p => p.HobbiesBridgeData)
                .HasForeignKey(d => d.HobbyId)
                .HasConstraintName("FK__HobbiesBr__Hobby__1D2725C1");

            entity.HasOne(d => d.User).WithMany(p => p.HobbiesBridgeData)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__HobbiesBr__UserI__1C330188");
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

        modelBuilder.Entity<HobbyDatum>(entity =>
        {
            entity.HasKey(e => e.HobbyId).HasName("PK__HobbyDat__0ABE0BCFEEE55AC8");

            entity.Property(e => e.HobbyName)
                .HasMaxLength(100)
                .IsUnicode(false);
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

        modelBuilder.Entity<ProductAppUser>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__ProductA__1788CC4C790C4ED3");

            entity.HasIndex(e => e.Email, "UQ__ProductA__A9D10534B4CE1867").IsUnique();

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FullName).HasMaxLength(255);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastLoginAt).HasColumnType("datetime");
            entity.Property(e => e.PasswordHash).HasMaxLength(512);
            entity.Property(e => e.PasswordSalt).HasMaxLength(256);
            entity.Property(e => e.Phone).HasMaxLength(50);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<ProductsAppOrder>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__products__C3905BCF4B9EA4DB");

            entity.ToTable("productsAppOrders");

            entity.Property(e => e.OrderDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("Placed");
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<ProductsAppOrderDetail>(entity =>
        {
            entity.HasKey(e => e.OrderDetailId).HasName("PK__products__D3B9D36C40D9CA6F");

            entity.ToTable("productsAppOrderDetails");

            entity.Property(e => e.ImageUrl)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Order).WithMany(p => p.ProductsAppOrderDetails)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_productsAppOrderDetails_productsAppOrders");
        });

        modelBuilder.Entity<ProductsDatum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Products__3213E83F25A21F95");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Category)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("category");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Image)
                .HasColumnType("text")
                .HasColumnName("image");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.RatingCount).HasColumnName("rating_count");
            entity.Property(e => e.RatingRate)
                .HasColumnType("decimal(3, 1)")
                .HasColumnName("rating_rate");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("title");
        });

        modelBuilder.Entity<ProjectDetail>(entity =>
        {
            entity.HasKey(e => e.ProjectId).HasName("PK__ProjectD__761ABED0F11B9C17");

            entity.HasIndex(e => e.ProjectName, "UQ__ProjectD__BCBE781C88A0530B").IsUnique();

            entity.Property(e => e.ProjectId).HasColumnName("ProjectID");
            entity.Property(e => e.ProjectName).HasMaxLength(50);
        });

        modelBuilder.Entity<PulseDummyTable>(entity =>
        {
            entity.HasKey(e => e.UserDetailsId).HasName("PK__PulseDum__053A938242D9B7A5");

            entity.ToTable("PulseDummyTable");

            entity.HasIndex(e => e.PhoneNumber, "UQ__PulseDum__85FB4E3815F02308").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__PulseDum__A9D10534327F734F").IsUnique();

            entity.Property(e => e.UserDetailsId).HasColumnName("UserDetailsID");
            entity.Property(e => e.CompanyDepartmentId).HasColumnName("CompanyDepartmentID");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.HasOne(d => d.CompanyDepartment).WithMany(p => p.PulseDummyTables)
                .HasForeignKey(d => d.CompanyDepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PulseDumm__Compa__687E5358");
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

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__8AFACE1AE007FCE0");

            entity.HasIndex(e => e.Name, "UQ__Roles__737584F630AE3063").IsUnique();

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Name).HasMaxLength(100);
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

        modelBuilder.Entity<UserDatum>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__UserData__1788CC4CB8248A8C");

            entity.ToTable(tb => tb.HasTrigger("trgUser_Hist"));

            entity.HasIndex(e => e.Email, "UQ__UserData__A9D105342931F562").IsUnique();

            entity.Property(e => e.ContactNumber)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Salary).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Country).WithMany(p => p.UserData)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK__UserData__Countr__139DBB87");

            entity.HasOne(d => d.Department).WithMany(p => p.UserData)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK__UserData__Depart__12A9974E");
        });

        modelBuilder.Entity<UserDetail>(entity =>
        {
            entity.HasKey(e => e.UserDetailsId).HasName("PK__UserDeta__053A938297542CE7");

            entity.ToTable("UserDetail");

            entity.HasIndex(e => e.PhoneNumber, "UQ__UserDeta__85FB4E38E41178EC").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__UserDeta__A9D10534DF75D934").IsUnique();

            entity.Property(e => e.UserDetailsId).HasColumnName("UserDetailsID");
            entity.Property(e => e.CompanyDepartmentId).HasColumnName("CompanyDepartmentID");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.HasOne(d => d.CompanyDepartment).WithMany(p => p.UserDetails)
                .HasForeignKey(d => d.CompanyDepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UserDetai__Compa__5FE90D57");
        });

        modelBuilder.Entity<UserDetailsBackup>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("UserDetails_Backup");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
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
            entity.Property(e => e.UserDetailsId)
                .ValueGeneratedOnAdd()
                .HasColumnName("userDetailsID");
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

        modelBuilder.Entity<UserFamilyDatum>(entity =>
        {
            entity.HasKey(e => e.FamilyId).HasName("PK__UserFami__41D82F6B53A1EE96");

            entity.Property(e => e.MemberName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Relation)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.User).WithMany(p => p.UserFamilyData)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__UserFamil__UserI__22DFFF17");
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

        modelBuilder.Entity<UserHist>(entity =>
        {
            entity.HasKey(e => e.UserHistId).HasName("PK__User_His__92DD901A53E1F4EF");

            entity.ToTable("User_Hist");

            entity.Property(e => e.UserHistId).HasColumnName("User_HistId");
            entity.Property(e => e.Action)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ACTION");
            entity.Property(e => e.LogDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
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

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.RoleId });

            entity.Property(e => e.AssignedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.AssignedByUser).WithMany(p => p.UserRoleAssignedByUsers)
                .HasForeignKey(d => d.AssignedByUserId)
                .HasConstraintName("FK_UserRoles_AssignedBy");

            entity.HasOne(d => d.Role).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK_UserRoles_Role");

            entity.HasOne(d => d.User).WithMany(p => p.UserRoleUsers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_UserRoles_User");
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
