using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Cloud.PPATSApp.Models
{
    public partial class CloudPATContext : DbContext
    {
        public CloudPATContext()
        {
        }

        public CloudPATContext(DbContextOptions<CloudPATContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ApplicationLookUp> ApplicationLookUps { get; set; }
        public virtual DbSet<AssemblyLookUp> AssemblyLookUps { get; set; }
        public virtual DbSet<AssemblyPollingStationLookUp> AssemblyPollingStationLookUps { get; set; }
        public virtual DbSet<CommunityLookUp> CommunityLookUps { get; set; }
        public virtual DbSet<EducationLookUp> EducationLookUps { get; set; }
        public virtual DbSet<EmployeeAcSetting> EmployeeAcSettings { get; set; }
        public virtual DbSet<EmployeeAppAccess> EmployeeAppAccesses { get; set; }
        public virtual DbSet<EmployeeInfo> EmployeeInfos { get; set; }
        public virtual DbSet<EmployeeRole> EmployeeRoles { get; set; }
        public virtual DbSet<GenderLookUp> GenderLookUps { get; set; }
        public virtual DbSet<IfpartyLookUp> IfpartyLookUps { get; set; }
        public virtual DbSet<MandalLookUp> MandalLookUps { get; set; }
        public virtual DbSet<MeasuringApplicationLookUp> MeasuringApplicationLookUps { get; set; }
        public virtual DbSet<MeasuringApplicationMapping> MeasuringApplicationMappings { get; set; }
        public virtual DbSet<MuncipalPollingStationLookUp> MuncipalPollingStationLookUps { get; set; }
        public virtual DbSet<MuncipalityLookUp> MuncipalityLookUps { get; set; }
        public virtual DbSet<ParliamentLookUp> ParliamentLookUps { get; set; }
        public virtual DbSet<PpatPiflookUp> PpatPiflookUps { get; set; }
        public virtual DbSet<PpatPrflookUp> PpatPrflookUps { get; set; }
        public virtual DbSet<PpatSflookUp> PpatSflookUps { get; set; }
        public virtual DbSet<PpatVpflookUp> PpatVpflookUps { get; set; }
        public virtual DbSet<RolesLookUp> RolesLookUps { get; set; }
        public virtual DbSet<StateLookUp> StateLookUps { get; set; }
        public virtual DbSet<SubCasteLookUp> SubCasteLookUps { get; set; }
        public virtual DbSet<UserInfo> UserInfos { get; set; }
        public virtual DbSet<VillageLookUp> VillageLookUps { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-9CRJRHJ\\SS17;Database=CloudPAT;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<ApplicationLookUp>(entity =>
            {
                entity.HasKey(e => e.AppCode)
                    .HasName("PK__Applicat__29493F87BF771E09");

                entity.ToTable("ApplicationLookUp");

                entity.Property(e => e.AppCode)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.AppId).ValueGeneratedOnAdd();

                entity.Property(e => e.AppName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.IsActive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<AssemblyLookUp>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("AssemblyLookUp");

                entity.Property(e => e.Accode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ACCode");

                entity.Property(e => e.Acid)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ACId");

                entity.Property(e => e.Acname)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ACName");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.IsActive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Pccode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PCCode");
            });

            modelBuilder.Entity<AssemblyPollingStationLookUp>(entity =>
            {
                entity.HasKey(e => e.Psid)
                    .HasName("PK__Assembly__BC00095605298BAC");

                entity.ToTable("AssemblyPollingStationLookUp");

                entity.Property(e => e.Psid).HasColumnName("PSId");

                entity.Property(e => e.Accode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ACCode");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.IsActive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.MandalCode)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Pccode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PCCode");

                entity.Property(e => e.Pscode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PSCode");

                entity.Property(e => e.Psname)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PSName");

                entity.Property(e => e.StateCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.VillageCode)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CommunityLookUp>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CommunityLookUp");

                entity.Property(e => e.ComId).ValueGeneratedOnAdd();

                entity.Property(e => e.CommunityCode)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.CommunityName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.IsActive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<EducationLookUp>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EducationLookUp");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EduId).ValueGeneratedOnAdd();

                entity.Property(e => e.EducationCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.EducationName)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<EmployeeAcSetting>(entity =>
            {
                entity.HasKey(e => e.AcSettingsId)
                    .HasName("PK__Employee__979FC1B52F9EE2E1");

                entity.ToTable("Employee_AC_Settings");

                entity.Property(e => e.AcSettingsId).HasColumnName("AC_SettingsId");

                entity.Property(e => e.Accode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ACCode");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.IsActive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.MainAppCode)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.MandalCode)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MeasuringAppCode)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Pccode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PCCode");

                entity.Property(e => e.Pscode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PSCode");

                entity.Property(e => e.Psname)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PSName");

                entity.Property(e => e.StateCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.VillageCode)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EmployeeAppAccess>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EmployeeAppAccess");

                entity.Property(e => e.AppCode)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.IsActive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.AppCodeNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.AppCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeA__AppCo__07C12930");

                entity.HasOne(d => d.Emp)
                    .WithMany()
                    .HasForeignKey(d => d.EmpId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeA__EmpId__06CD04F7");
            });

            modelBuilder.Entity<EmployeeInfo>(entity =>
            {
                entity.HasKey(e => e.EmpId)
                    .HasName("PK__Employee__AF2DBB99E9AAF7DF");

                entity.ToTable("EmployeeInfo");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EmpAddress)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.EmpEmail)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EmpFirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmpLastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmpPassword)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmpPhone)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmpUsername)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<EmployeeRole>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.AutoRoleId).ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.IsActive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Emp)
                    .WithMany()
                    .HasForeignKey(d => d.EmpId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeR__EmpId__03F0984C");

                entity.HasOne(d => d.Role)
                    .WithMany()
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeR__RoleI__04E4BC85");
            });

            modelBuilder.Entity<GenderLookUp>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("GenderLookUp");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.GenderCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.GenderId).ValueGeneratedOnAdd();

                entity.Property(e => e.GenderName)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<IfpartyLookUp>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("IFPartyLookUp");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Ifcode)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("IFCode");

                entity.Property(e => e.Ifid)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("IFId");

                entity.Property(e => e.Ifname)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("IFName");

                entity.Property(e => e.IsActive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<MandalLookUp>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("MandalLookUp");

                entity.Property(e => e.Accode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ACCode");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.IsActive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.MandalCode)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MandalName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Mdid)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("MDId");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<MeasuringApplicationLookUp>(entity =>
            {
                entity.HasKey(e => e.MeasureAppCode)
                    .HasName("PK__Measurin__B2CEDF65B677032D");

                entity.ToTable("MeasuringApplicationLookUp");

                entity.Property(e => e.MeasureAppCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.IsActive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.MeasureAppId).ValueGeneratedOnAdd();

                entity.Property(e => e.MeasureAppName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<MeasuringApplicationMapping>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.AppCode)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.IsActive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.MeasureAppCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MeasureAppMapId).ValueGeneratedOnAdd();

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.AppCodeNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.AppCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Measuring__AppCo__7F2BE32F");

                entity.HasOne(d => d.MeasureAppCodeNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.MeasureAppCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Measuring__Measu__00200768");
            });

            modelBuilder.Entity<MuncipalPollingStationLookUp>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("MuncipalPollingStationLookUp");

                entity.Property(e => e.Accode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ACCode");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.IsActive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.MandalCode)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.MunPscode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MunPSCode");

                entity.Property(e => e.MunPsid)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("MunPSId");

                entity.Property(e => e.MunPsname)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MunPSName");

                entity.Property(e => e.Pccode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PCCode");

                entity.Property(e => e.StateCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MuncipalityLookUp>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("MuncipalityLookUp");

                entity.Property(e => e.Accode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ACCode");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.IsActive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.MuncipalCode)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MuncipalId).ValueGeneratedOnAdd();

                entity.Property(e => e.MuncipalName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ParliamentLookUp>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ParliamentLookUp");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.IsActive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Pccode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PCCode");

                entity.Property(e => e.Pcid)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PCId");

                entity.Property(e => e.Pcname)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PCName");

                entity.Property(e => e.StateCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PpatPiflookUp>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("PPAT_PIFLookUp");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.IsActive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.PpatPifcode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PPAT_PIFCode");

                entity.Property(e => e.PpatPifid)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PPAT_PIFId");

                entity.Property(e => e.PpatPifname)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("PPAT_PIFName");
            });

            modelBuilder.Entity<PpatPrflookUp>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("PPAT_PRFLookUp");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.IsActive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.PpatPrfcode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PPAT_PRFCode");

                entity.Property(e => e.PpatPrfid)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PPAT_PRFId");

                entity.Property(e => e.PpatPrfname)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("PPAT_PRFName");
            });

            modelBuilder.Entity<PpatSflookUp>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("PPAT_SFLookUp");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.IsActive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.PpatSfcode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PPAT_SFCode");

                entity.Property(e => e.PpatSfname)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("PPAT_SFName");

                entity.Property(e => e.Ppatsfid)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PPATSFId");
            });

            modelBuilder.Entity<PpatVpflookUp>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("PPAT_VPFLookUp");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.IsActive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.PpatVpfcode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PPAT_VPFCode");

                entity.Property(e => e.PpatVpfid)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PPAT_VPFId");

                entity.Property(e => e.PpatVpfname)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("PPAT_VPFName");
            });

            modelBuilder.Entity<RolesLookUp>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PK__RolesLoo__8AFACE1ABC54AF31");

                entity.ToTable("RolesLookUp");

                entity.Property(e => e.RoleId).ValueGeneratedNever();

                entity.Property(e => e.AutoId).ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.IsActive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StateLookUp>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("StateLookUp");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.IsActive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.StateCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.StateId).ValueGeneratedOnAdd();

                entity.Property(e => e.StateName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SubCasteLookUp>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SubCasteLookUp");

                entity.Property(e => e.CommunityCode)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.IsActive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.SubCasteCode)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.SubCasteId).ValueGeneratedOnAdd();

                entity.Property(e => e.SubCasteName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__UserInfo__1788CC4CA90BAC0C");

                entity.ToTable("UserInfo");

                entity.Property(e => e.Accode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ACCode");

                entity.Property(e => e.AppCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CommunityCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EducationCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Ifcode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("IFCode");

                entity.Property(e => e.IsActive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.MandalCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MeasureAppCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Occupation)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Pccode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PCCode");

                entity.Property(e => e.Pifcode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PIFCode");

                entity.Property(e => e.Prfcode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PRFCode");

                entity.Property(e => e.Pscode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PSCode");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Sfcode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SFCode");

                entity.Property(e => e.StateCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SubCasteCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserDisplayName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserMobile)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.VillageCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Vpfcode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("VPFCode");
            });

            modelBuilder.Entity<VillageLookUp>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("VillageLookUp");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.IsActive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.MandalCode)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Vgid)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("VGId");

                entity.Property(e => e.VillageCode)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.VillageName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
