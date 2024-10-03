//using System;
//using System.Collections.Generic;
//using Microsoft.EntityFrameworkCore;

//namespace DA_Management_Endpoint.Models;

//public partial class DaManagementContext : DbContext
//{
//    public DaManagementContext()
//    {
//    }

//    public DaManagementContext(DbContextOptions<DaManagementContext> options)
//        : base(options)
//    {
//    }

//    public virtual DbSet<AcademicYear> AcademicYears { get; set; }

//    public virtual DbSet<Attendance> Attendances { get; set; }

//    public virtual DbSet<Block> Blocks { get; set; }

//    public virtual DbSet<Catechist> Catechists { get; set; }

//    public virtual DbSet<CatechistProfile> CatechistProfiles { get; set; }

//    public virtual DbSet<Class> Classes { get; set; }

//    public virtual DbSet<ClassCatechist> ClassCatechists { get; set; }

//    public virtual DbSet<EfmigrationsHistory> EfmigrationsHistories { get; set; }

//    public virtual DbSet<Profile> Profiles { get; set; }

//    public virtual DbSet<RegistrationSection> RegistrationSections { get; set; }

//    public virtual DbSet<Score> Scores { get; set; }

//    public virtual DbSet<Student> Students { get; set; }

//    public virtual DbSet<StudentRevision> StudentRevisions { get; set; }

//    public virtual DbSet<User> Users { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseMySql("server=localhost;database=da_management;user=root;password=zxcv1234", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.3.0-mysql"));

//    protected override void OnModelCreating(ModelBuilder modelBuilder)
//    {
//        modelBuilder
//            .UseCollation("utf8mb4_0900_ai_ci")
//            .HasCharSet("utf8mb4");

//        modelBuilder.Entity<AcademicYear>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("PRIMARY");

//            entity.Property(e => e.Name).HasMaxLength(10);
//            entity.Property(e => e.Status).HasDefaultValueSql("'0'");
//        });

//        modelBuilder.Entity<Attendance>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("PRIMARY");

//            entity.HasIndex(e => e.StudentId, "FK_Attendances_Students");

//            entity.HasIndex(e => new { e.ClassId, e.StudentId, e.Date }, "unique_attendance").IsUnique();

//            entity.Property(e => e.CreatedDate)
//                .HasDefaultValueSql("CURRENT_TIMESTAMP")
//                .HasColumnType("datetime");
//            entity.Property(e => e.Date).HasMaxLength(5);
//            entity.Property(e => e.UpdatedDate)
//                .HasDefaultValueSql("CURRENT_TIMESTAMP")
//                .HasColumnType("datetime");

//            entity.HasOne(d => d.Class).WithMany(p => p.Attendances)
//                .HasForeignKey(d => d.ClassId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_Attendances_Classes");

//            entity.HasOne(d => d.Student).WithMany(p => p.Attendances)
//                .HasForeignKey(d => d.StudentId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_Attendances_Students");
//        });

//        modelBuilder.Entity<Block>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("PRIMARY");

//            entity.Property(e => e.Name).HasMaxLength(10);
//        });

//        modelBuilder.Entity<Catechist>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("PRIMARY");

//            entity.Property(e => e.Address).HasMaxLength(100);
//            entity.Property(e => e.BirthDate).HasColumnType("datetime");
//            entity.Property(e => e.Contact).HasMaxLength(50);
//            entity.Property(e => e.CreatedDate)
//                .HasDefaultValueSql("CURRENT_TIMESTAMP")
//                .HasColumnType("datetime");
//            entity.Property(e => e.FirstName).HasMaxLength(50);
//            entity.Property(e => e.JoinedDate).HasColumnType("datetime");
//            entity.Property(e => e.Level).HasMaxLength(50);
//            entity.Property(e => e.UpdatedDate)
//                .HasDefaultValueSql("CURRENT_TIMESTAMP")
//                .HasColumnType("datetime");
//        });

//        modelBuilder.Entity<CatechistProfile>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("PRIMARY");

//            entity.HasIndex(e => e.CatechistId, "FK_CatechistProfiles_Catechists");

//            entity.HasIndex(e => e.ProfileId, "FK_CatechistProfiles_Profiles");

//            entity.Property(e => e.CreatedDate)
//                .HasDefaultValueSql("CURRENT_TIMESTAMP")
//                .HasColumnType("datetime");
//            entity.Property(e => e.UpdatedDate)
//                .HasDefaultValueSql("CURRENT_TIMESTAMP")
//                .HasColumnType("datetime");

//            entity.HasOne(d => d.Catechist).WithMany(p => p.CatechistProfiles)
//                .HasForeignKey(d => d.CatechistId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_CatechistProfiles_Catechists");

//            entity.HasOne(d => d.Profile).WithMany(p => p.CatechistProfiles)
//                .HasForeignKey(d => d.ProfileId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_CatechistProfiles_Profiles");
//        });

//        modelBuilder.Entity<Class>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("PRIMARY");

//            entity.HasIndex(e => e.AcademicYearId, "FK_Classes_AcademicYears");

//            entity.HasIndex(e => e.BlockId, "FK_Classes_Blocks");

//            entity.Property(e => e.Name).HasMaxLength(10);

//            entity.HasOne(d => d.AcademicYear).WithMany(p => p.Classes)
//                .HasForeignKey(d => d.AcademicYearId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_Classes_AcademicYears");

//            entity.HasOne(d => d.Block).WithMany(p => p.Classes)
//                .HasForeignKey(d => d.BlockId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_Classes_Blocks");
//        });

//        modelBuilder.Entity<ClassCatechist>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("PRIMARY");

//            entity.HasIndex(e => new { e.ClassId, e.CatechistId }, "ClassId").IsUnique();

//            entity.HasIndex(e => e.CatechistId, "FK_ClassCatechists_Catechists");

//            entity.HasOne(d => d.Catechist).WithMany(p => p.ClassCatechists)
//                .HasForeignKey(d => d.CatechistId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_ClassCatechists_Catechists");

//            entity.HasOne(d => d.Class).WithMany(p => p.ClassCatechists)
//                .HasForeignKey(d => d.ClassId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_ClassCatechists_Classes");
//        });

//        modelBuilder.Entity<EfmigrationsHistory>(entity =>
//        {
//            entity.HasKey(e => e.MigrationId).HasName("PRIMARY");

//            entity.ToTable("__EFMigrationsHistory");

//            entity.Property(e => e.MigrationId).HasMaxLength(150);
//            entity.Property(e => e.ProductVersion).HasMaxLength(32);
//        });

//        modelBuilder.Entity<Profile>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("PRIMARY");

//            entity.Property(e => e.CreatedDate)
//                .HasDefaultValueSql("CURRENT_TIMESTAMP")
//                .HasColumnType("datetime");
//            entity.Property(e => e.Name).HasMaxLength(10);
//            entity.Property(e => e.UpdatedDate)
//                .HasDefaultValueSql("CURRENT_TIMESTAMP")
//                .HasColumnType("datetime");
//        });

//        modelBuilder.Entity<RegistrationSection>(entity =>
//        {
//            entity.HasKey(e => e.Guid).HasName("PRIMARY");

//            entity.Property(e => e.Guid).HasMaxLength(50);
//            entity.Property(e => e.InitDate).HasColumnType("datetime");
//            entity.Property(e => e.Status).HasDefaultValueSql("'0'");
//        });

//        modelBuilder.Entity<Score>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("PRIMARY");

//            entity.HasIndex(e => e.ClassId, "FK_Scores_Classes");

//            entity.HasIndex(e => e.StudentId, "FK_Scores_Students");

//            entity.Property(e => e.CreatedDate)
//                .HasDefaultValueSql("CURRENT_TIMESTAMP")
//                .HasColumnType("datetime");
//            entity.Property(e => e.Term).HasMaxLength(36);
//            entity.Property(e => e.UpdatedDate)
//                .HasDefaultValueSql("CURRENT_TIMESTAMP")
//                .HasColumnType("datetime");

//            entity.HasOne(d => d.Class).WithMany(p => p.Scores)
//                .HasForeignKey(d => d.ClassId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_Scores_Classes");

//            entity.HasOne(d => d.Student).WithMany(p => p.Scores)
//                .HasForeignKey(d => d.StudentId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_Scores_Students");
//        });

//        modelBuilder.Entity<Student>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("PRIMARY");

//            entity.Property(e => e.AddedDate)
//                .HasDefaultValueSql("CURRENT_TIMESTAMP")
//                .HasColumnType("datetime");
//            entity.Property(e => e.BirthDate).HasColumnType("datetime");
//            entity.Property(e => e.Contact).HasMaxLength(50);
//            entity.Property(e => e.Dad).HasMaxLength(100);
//            entity.Property(e => e.FirstName).HasMaxLength(100);
//            entity.Property(e => e.HolyName).HasMaxLength(50);
//            entity.Property(e => e.LastName).HasMaxLength(50);
//            entity.Property(e => e.Mom).HasMaxLength(100);
//            entity.Property(e => e.SacramentBaptism).HasMaxLength(50);
//            entity.Property(e => e.SacramentConfirmation).HasMaxLength(50);
//            entity.Property(e => e.SacramentFirstConfession).HasMaxLength(50);
//            entity.Property(e => e.Status).HasDefaultValueSql("'-1'");
//            entity.Property(e => e.UpdatedDate)
//                .HasDefaultValueSql("CURRENT_TIMESTAMP")
//                .HasColumnType("datetime");
//        });

//        modelBuilder.Entity<StudentRevision>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("PRIMARY");

//            entity.HasIndex(e => e.ClassId, "ClassId");

//            entity.HasIndex(e => e.StudentId, "StudentId");

//            entity.Property(e => e.CreatedDate).HasColumnType("datetime");

//            entity.HasOne(d => d.Class).WithMany(p => p.StudentRevisions)
//                .HasForeignKey(d => d.ClassId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_StudentRevisions_Classes");

//            entity.HasOne(d => d.Student).WithMany(p => p.StudentRevisions)
//                .HasForeignKey(d => d.StudentId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_StudentRevisions_Students");
//        });

//        modelBuilder.Entity<User>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("PRIMARY");

//            entity.Property(e => e.CreatedDate)
//                .HasDefaultValueSql("CURRENT_TIMESTAMP")
//                .HasColumnType("datetime");
//            entity.Property(e => e.Password).HasMaxLength(100);
//            entity.Property(e => e.Role).HasMaxLength(10);
//            entity.Property(e => e.Status).HasDefaultValueSql("'0'");
//            entity.Property(e => e.Username).HasMaxLength(100);
//        });

//        OnModelCreatingPartial(modelBuilder);
//    }

//    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
//}
