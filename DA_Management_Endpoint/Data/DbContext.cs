using System;
using Microsoft.EntityFrameworkCore;
using DA_Management_Endpoint.Models;

namespace DA_Management_Endpoint.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<RegistrationSection> RegistrationSections { get; set; }

        public DbSet<AcademicYear> AcademicYears { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Block> Blocks { get; set; }
        public DbSet<Catechist> Catechists { get; set; }
        public DbSet<CatechistProfile> CatechistProfiles { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Score> Scores { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentRevision> StudentRevisions { get; set; }
        public DbSet<ClassCatechist> ClassCatechists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // AcademicYears
            modelBuilder.Entity<AcademicYear>(entity =>
            {
                entity.ToTable("AcademicYears");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name)
                      .IsRequired()
                      .HasMaxLength(10);
                entity.Property(e => e.Status)
                      .HasDefaultValue(false);
            });

            // Attendances
            modelBuilder.Entity<Attendance>(entity =>
            {
                entity.ToTable("Attendances");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Date)
                      .IsRequired()
                      .HasMaxLength(5);
                entity.Property(e => e.Status)
                      .IsRequired();
                entity.Property(e => e.CreatedDate)
                      .HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.Property(e => e.UpdatedDate)
                      .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasIndex(e => new { e.ClassId, e.StudentId, e.Date })
                      .IsUnique();

                entity.HasOne<Class>()
                      .WithMany()
                      .HasForeignKey(e => e.ClassId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne<Student>()
                      .WithMany()
                      .HasForeignKey(e => e.StudentId)
                      .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(a => a.Class)
                        .WithMany(c => c.Attendances)
                        .HasForeignKey(a => a.ClassId)
                        .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(a => a.Student)
                        .WithMany(s => s.Attendances)
                        .HasForeignKey(a => a.StudentId)
                        .OnDelete(DeleteBehavior.Cascade);
            });

            // Blocks
            modelBuilder.Entity<Block>(entity =>
            {
                entity.ToTable("Blocks");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name)
                      .IsRequired()
                      .HasMaxLength(10);
            });

            // CatechistProfiles
            modelBuilder.Entity<CatechistProfile>(entity =>
            {
                entity.ToTable("CatechistProfiles");
                entity.HasKey(cp => new { cp.CatechistId, cp.ProfileId });

                entity.HasOne(cp => cp.Catechist)
                        .WithMany(c => c.CatechistProfiles)
                        .HasForeignKey(cp => cp.CatechistId)
                        .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(cp => cp.Profile)
                    .WithMany(p => p.CatechistProfiles)
                    .HasForeignKey(cp => cp.ProfileId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Catechists
            modelBuilder.Entity<Catechist>(entity =>
            {
                entity.ToTable("Catechists");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.HolyName)
                      .IsRequired();
                entity.Property(e => e.FirstName)
                      .IsRequired()
                      .HasMaxLength(50);
                entity.Property(e => e.LastName)
                      .IsRequired();
                entity.Property(e => e.Address)
                      .HasMaxLength(100);
                entity.Property(e => e.Contact)
                      .HasMaxLength(50);
                entity.Property(e => e.Level)
                      .IsRequired()
                      .HasMaxLength(50);
            });

            // ClassCatechists
            modelBuilder.Entity<ClassCatechist>(entity =>
            {
                entity.ToTable("ClassCatechists");
                entity.HasKey(e => e.Id);

                entity.HasOne(d => d.Class)
              .WithMany(p => p.ClassCatechists)
              .HasForeignKey(d => d.ClassId)
              .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.Catechist)
              .WithMany(p => p.ClassCatechists)
              .HasForeignKey(d => d.CatechistId)
              .OnDelete(DeleteBehavior.Cascade);
            });

            // Classes
            modelBuilder.Entity<Class>(entity =>
            {
                entity.ToTable("Classes");
                entity.HasKey(e => e.Id);

                entity.HasOne(d => d.AcademicYear)
                      .WithMany(p => p.Classes)
                      .HasForeignKey(d => d.AcademicYearId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.Block)
                      .WithMany(p => p.Classes)
                      .HasForeignKey(d => d.BlockId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Profiles
            modelBuilder.Entity<Profile>(entity =>
            {
                entity.ToTable("Profiles");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name)
                      .IsRequired()
                      .HasMaxLength(10);

                for (int i = 1; i <= 24; i++)
                {
                    entity.Property<bool>($"P{i}").IsRequired();
                }

                entity.HasOne(d => d.CreatedByCatechist)
                      .WithMany()
                      .HasForeignKey(e => e.CreatedBy)
                      .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(d => d.UpdatedByCatechist)
                      .WithMany()
                      .HasForeignKey(e => e.UpdatedBy)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // RegistrationSections
            modelBuilder.Entity<RegistrationSection>(entity =>
            {
                entity.ToTable("RegistrationSections");
                entity.HasKey(e => e.Guid);
                entity.Property(e => e.InitDate)
                      .IsRequired();
                entity.Property(e => e.Status)
                      .HasDefaultValue(false);
            });

            // Scores
            modelBuilder.Entity<Score>(entity =>
            {
                entity.ToTable("Scores");
                entity.HasKey(e => e.Id);

                entity.HasOne(d => d.Class)
              .WithMany(p => p.Scores)
              .HasForeignKey(d => d.ClassId)
              .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.Student)
              .WithMany(p => p.Scores)
              .HasForeignKey(d => d.StudentId)
              .OnDelete(DeleteBehavior.Cascade);
            });

            // StudentRevisions
            modelBuilder.Entity<StudentRevision>(entity =>
            {
                entity.ToTable("StudentRevisions");
                entity.HasKey(e => e.Id);

                entity.HasOne(d => d.Class)
              .WithMany(p => p.StudentRevisions)  // Thực thể Class có danh sách StudentRevisions
              .HasForeignKey(d => d.ClassId)
              .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.Student)
              .WithMany(p => p.StudentRevisions)  // Thực thể Student có danh sách StudentRevisions
              .HasForeignKey(d => d.StudentId)
              .OnDelete(DeleteBehavior.Cascade);
            });

            // Students
            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Students");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.HolyName)
                      .HasMaxLength(50);
                entity.Property(e => e.FirstName)
                      .IsRequired()
                      .HasMaxLength(100);
                entity.Property(e => e.LastName)
                      .IsRequired()
                      .HasMaxLength(50);
                entity.Property(e => e.Address)
                      .IsRequired();

                entity.HasOne(d => d.Class)
                      .WithMany(p => p.Students)  // Thực thể Class có danh sách Students
                      .HasForeignKey(d => d.ClassId)
                      .OnDelete(DeleteBehavior.SetNull);
                entity.HasOne(d => d.CreatedByCatechist)
                      .WithMany()
                      .HasForeignKey(e => e.CreatedBy)
                      .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(d => d.UpdatedByCatechist)
                      .WithMany()
                      .HasForeignKey(e => e.UpdatedBy)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // Users
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Username)
                      .IsRequired()
                      .HasMaxLength(50);
                entity.HasIndex(e => e.Username)
                      .IsUnique();

                entity.HasOne(u => u.Catechist)
                        .WithOne(c => c.User)
                        .HasForeignKey<User>(u => u.Id);
            });
        }


    }

}

