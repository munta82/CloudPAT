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
        public virtual DbSet<IgDetail> IgDetails { get; set; }
        public virtual DbSet<MandalLookUp> MandalLookUps { get; set; }
        public virtual DbSet<MeasuringApplicationLookUp> MeasuringApplicationLookUps { get; set; }
        public virtual DbSet<MeasuringApplicationMapping> MeasuringApplicationMappings { get; set; }
        public virtual DbSet<MuncipalPollingStationLookUp> MuncipalPollingStationLookUps { get; set; }
        public virtual DbSet<MuncipalityLookUp> MuncipalityLookUps { get; set; }
        public virtual DbSet<ParliamentLookUp> ParliamentLookUps { get; set; }
        public virtual DbSet<PigUserInfo> PigUserInfos { get; set; }
        public virtual DbSet<PpatEbflookUp> PpatEbflookUps { get; set; }
        public virtual DbSet<PpatGradingLookUp> PpatGradingLookUps { get; set; }
        public virtual DbSet<PpatLlrflookUp> PpatLlrflookUps { get; set; }
        public virtual DbSet<PpatPiflookUp> PpatPiflookUps { get; set; }
        public virtual DbSet<PpatPrflookUp> PpatPrflookUps { get; set; }
        public virtual DbSet<PpatSflookUp> PpatSflookUps { get; set; }
        public virtual DbSet<PpatSiflookUp> PpatSiflookUps { get; set; }
        public virtual DbSet<PpatVpflookUp> PpatVpflookUps { get; set; }
        public virtual DbSet<RolesLookUp> RolesLookUps { get; set; }
        public virtual DbSet<SsDetail> SsDetails { get; set; }
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
                    .HasName("PK__Applicat__29493F8712A3724E");

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
                entity.HasKey(e => e.Accode)
                    .HasName("PK__Assembly__5E03D60DEA78681C");

                entity.ToTable("AssemblyLookUp");

                entity.Property(e => e.Accode)
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
                    .HasName("PK__Assembly__BC0009562681B174");

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
                entity.HasKey(e => e.CommunityCode)
                    .HasName("PK__Communit__8A7DF0AE4ED2ACE6");

                entity.ToTable("CommunityLookUp");

                entity.Property(e => e.CommunityCode)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.ComId).ValueGeneratedOnAdd();

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
                entity.HasKey(e => e.EducationCode)
                    .HasName("PK__Educatio__E2D8B715C4E47032");

                entity.ToTable("EducationLookUp");

                entity.Property(e => e.EducationCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EduId).ValueGeneratedOnAdd();

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
                    .HasName("PK__Employee__979FC1B546274703");

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
                entity.ToTable("EmployeeAppAccess");

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

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.AppCodeNavigation)
                    .WithMany(p => p.EmployeeAppAccesses)
                    .HasForeignKey(d => d.AppCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeA__AppCo__6FE99F9F");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.EmployeeAppAccesses)
                    .HasForeignKey(d => d.EmpId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeA__EmpId__6EF57B66");
            });

            modelBuilder.Entity<EmployeeInfo>(entity =>
            {
                entity.HasKey(e => e.EmpId)
                    .HasName("PK__Employee__AF2DBB992AE4331B");

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
                entity.HasKey(e => e.AutoRoleId)
                    .HasName("PK__Employee__08B81E1C8B4A9DEA");

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
                    .WithMany(p => p.EmployeeRoles)
                    .HasForeignKey(d => d.EmpId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeR__EmpId__6B24EA82");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.EmployeeRoles)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeR__RoleI__6C190EBB");
            });

            modelBuilder.Entity<GenderLookUp>(entity =>
            {
                entity.HasKey(e => e.GenderCode)
                    .HasName("PK__GenderLo__3E01F22D4427F3C8");

                entity.ToTable("GenderLookUp");

                entity.Property(e => e.GenderCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

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
                entity.HasKey(e => e.Ifcode)
                    .HasName("PK__IFPartyL__6BF413BAC486587F");

                entity.ToTable("IFPartyLookUp");

                entity.Property(e => e.Ifcode)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("IFCode");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

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

            modelBuilder.Entity<IgDetail>(entity =>
            {
                entity.HasKey(e => e.IgId)
                    .HasName("PK__IG_Detai__8131590A524D5027");

                entity.ToTable("IG_Details");

                entity.Property(e => e.IgId).HasColumnName("IG_Id");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Igcode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("IGCode");

                entity.Property(e => e.Igname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("IGName");

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
                entity.HasKey(e => e.Mdid)
                    .HasName("PK__MandalLo__1AF4D0F3F7E339B8");

                entity.ToTable("MandalLookUp");

                entity.Property(e => e.Mdid).HasColumnName("MDId");

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

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<MeasuringApplicationLookUp>(entity =>
            {
                entity.HasKey(e => e.MeasureAppCode)
                    .HasName("PK__Measurin__B2CEDF65751D8C54");

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
                entity.HasKey(e => e.MeasureAppMapId)
                    .HasName("PK__Measurin__880B1CBD446549EC");

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

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.AppCodeNavigation)
                    .WithMany(p => p.MeasuringApplicationMappings)
                    .HasForeignKey(d => d.AppCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Measuring__AppCo__6383C8BA");

                entity.HasOne(d => d.MeasureAppCodeNavigation)
                    .WithMany(p => p.MeasuringApplicationMappings)
                    .HasForeignKey(d => d.MeasureAppCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Measuring__Measu__6477ECF3");
            });

            modelBuilder.Entity<MuncipalPollingStationLookUp>(entity =>
            {
                entity.HasKey(e => e.MunPscode)
                    .HasName("PK__Muncipal__91632184D587165C");

                entity.ToTable("MuncipalPollingStationLookUp");

                entity.Property(e => e.MunPscode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MunPSCode");

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
                entity.HasKey(e => e.MuncipalId)
                    .HasName("PK__Muncipal__25593E40058313E0");

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

                entity.Property(e => e.MuncipalName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ParliamentLookUp>(entity =>
            {
                entity.HasKey(e => e.Pccode)
                    .HasName("PK__Parliame__A5CE992083CC4FBC");

                entity.ToTable("ParliamentLookUp");

                entity.Property(e => e.Pccode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PCCode");

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

            modelBuilder.Entity<PigUserInfo>(entity =>
            {
                entity.HasKey(e => e.PigUserId)
                    .HasName("PK__PIG_User__BA1FAEC8174A868D");

                entity.ToTable("PIG_UserInfo");

                entity.Property(e => e.PigUserId).HasColumnName("PIG_UserId");

                entity.Property(e => e.Accode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ACCode");

                entity.Property(e => e.AppCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

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

                entity.Property(e => e.Pccode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PCCode");

                entity.Property(e => e.PigCommunityCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PIG_CommunityCode");

                entity.Property(e => e.PigEducationCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PIG_EducationCode");

                entity.Property(e => e.PigGrade)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PIG_Grade");

                entity.Property(e => e.PigIfcode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PIG_IFCode");

                entity.Property(e => e.PigIgcode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PIG_IGCode");

                entity.Property(e => e.PigOccupation)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PIG_Occupation");

                entity.Property(e => e.PigPosition)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PIG_Position");

                entity.Property(e => e.PigRemarks)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("PIG_Remarks");

                entity.Property(e => e.PigScale)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PIG_Scale");

                entity.Property(e => e.PigSubCasteCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PIG_SubCasteCode");

                entity.Property(e => e.PigUserAge).HasColumnName("PIG_UserAge");

                entity.Property(e => e.PigUserDisplayName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PIG_UserDisplayName");

                entity.Property(e => e.PigUserGender)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("PIG_UserGender");

                entity.Property(e => e.PigUserMobile)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("PIG_UserMobile");

                entity.Property(e => e.Pigcode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PIGCode");

                entity.Property(e => e.Pscode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PSCode");

                entity.Property(e => e.StateCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VillageCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PpatEbflookUp>(entity =>
            {
                entity.HasKey(e => e.PpatEbfcode)
                    .HasName("PK__PPAT_EBF__F8C1256C4013491F");

                entity.ToTable("PPAT_EBFLookUp");

                entity.Property(e => e.PpatEbfcode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PPAT_EBFCode");

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

                entity.Property(e => e.PpatEbfid)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PPAT_EBFId");

                entity.Property(e => e.PpatEbfname)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("PPAT_EBFName");
            });

            modelBuilder.Entity<PpatGradingLookUp>(entity =>
            {
                entity.HasKey(e => e.PpatGrdingCode)
                    .HasName("PK__PPAT_Gra__1EA3DA1CAAF771F3");

                entity.ToTable("PPAT_GradingLookUp");

                entity.Property(e => e.PpatGrdingCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PPAT_GrdingCode");

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

                entity.Property(e => e.PpatGradingId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PPAT_GradingId");

                entity.Property(e => e.PpatGradingName)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("PPAT_GradingName");
            });

            modelBuilder.Entity<PpatLlrflookUp>(entity =>
            {
                entity.HasKey(e => e.PpatLlrfcode)
                    .HasName("PK__PPAT_LLR__CA312D37745737F8");

                entity.ToTable("PPAT_LLRFLookUp");

                entity.Property(e => e.PpatLlrfcode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PPAT_LLRFCode");

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

                entity.Property(e => e.PpatLlrfid)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PPAT_LLRFId");

                entity.Property(e => e.PpatLlrfname)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("PPAT_LLRFName");
            });

            modelBuilder.Entity<PpatPiflookUp>(entity =>
            {
                entity.HasKey(e => e.PpatPifcode)
                    .HasName("PK__PPAT_PIF__5092B3AF25B74EA9");

                entity.ToTable("PPAT_PIFLookUp");

                entity.Property(e => e.PpatPifcode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PPAT_PIFCode");

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
                entity.HasKey(e => e.PpatPrfcode)
                    .HasName("PK__PPAT_PRF__81DAD95BD4FA3E47");

                entity.ToTable("PPAT_PRFLookUp");

                entity.Property(e => e.PpatPrfcode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PPAT_PRFCode");

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
                entity.HasKey(e => e.PpatSfcode)
                    .HasName("PK__PPAT_SFL__83A70C3705AA0C1C");

                entity.ToTable("PPAT_SFLookUp");

                entity.Property(e => e.PpatSfcode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PPAT_SFCode");

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

                entity.Property(e => e.PpatSfname)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("PPAT_SFName");

                entity.Property(e => e.Ppatsfid)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PPATSFId");
            });

            modelBuilder.Entity<PpatSiflookUp>(entity =>
            {
                entity.HasKey(e => e.PpatSifcode)
                    .HasName("PK__PPAT_SIF__396B22D0E5AD79D2");

                entity.ToTable("PPAT_SIFLookUp");

                entity.Property(e => e.PpatSifcode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PPAT_SIFCode");

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

                entity.Property(e => e.PpatSifid)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PPAT_SIFId");

                entity.Property(e => e.PpatSifname)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("PPAT_SIFName");
            });

            modelBuilder.Entity<PpatVpflookUp>(entity =>
            {
                entity.HasKey(e => e.PpatVpfcode)
                    .HasName("PK__PPAT_VPF__1C8EB227CBE254B6");

                entity.ToTable("PPAT_VPFLookUp");

                entity.Property(e => e.PpatVpfcode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PPAT_VPFCode");

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
                    .HasName("PK__RolesLoo__8AFACE1AF9670ED3");

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

            modelBuilder.Entity<SsDetail>(entity =>
            {
                entity.HasKey(e => e.SsId)
                    .HasName("PK__SS_Detai__456F94029BEDE467");

                entity.ToTable("SS_Details");

                entity.Property(e => e.SsId).HasColumnName("SS_Id");

                entity.Property(e => e.Accode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ACCode");

                entity.Property(e => e.AppCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

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

                entity.Property(e => e.Pccode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PCCode");

                entity.Property(e => e.Pscode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PSCode");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.SsCommunityCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("SS_CommunityCode");

                entity.Property(e => e.SsSubCasteCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SS_SubCasteCode");

                entity.Property(e => e.StateCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VillageCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StateLookUp>(entity =>
            {
                entity.HasKey(e => e.StateCode)
                    .HasName("PK__StateLoo__D515E98B55319828");

                entity.ToTable("StateLookUp");

                entity.Property(e => e.StateCode)
                    .HasMaxLength(10)
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

                entity.Property(e => e.StateId).ValueGeneratedOnAdd();

                entity.Property(e => e.StateName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SubCasteLookUp>(entity =>
            {
                entity.HasKey(e => e.SubCasteId)
                    .HasName("PK__SubCaste__CAE80B61D0E4BDC3");

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
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SubCasteName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__UserInfo__1788CC4C72002C43");

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

                entity.Property(e => e.Ebfcode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EBFCode");

                entity.Property(e => e.EducationCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.GradingCode)
                    .IsRequired()
                    .HasMaxLength(50)
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

                entity.Property(e => e.Llrfcode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LLRFCode");

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

                entity.Property(e => e.Sifcode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SIFCode");

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
                entity.HasKey(e => e.Vgid)
                    .HasName("PK__VillageL__222288D28918D35D");

                entity.ToTable("VillageLookUp");

                entity.Property(e => e.Vgid).HasColumnName("VGId");

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
