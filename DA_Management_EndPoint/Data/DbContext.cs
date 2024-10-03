using System;
using DA_Management_EndPoint.Models;
using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;

namespace DA_Management_EndPoint.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<AcademicYear> AcademicYears { get; set; }
        public DbSet<Block> Blocks { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Catechist> Catechists { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Score> Scores { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure entity relationships and constraints here if needed

            base.OnModelCreating(modelBuilder);
        }
    }
}

