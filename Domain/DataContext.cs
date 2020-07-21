using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class DataContext : DbContext
    {
        public DbSet<School> School { get; set; }
        public DbSet<Students> Students { get; set; }

        public DbSet<SchoolStudent> SchoolStudents { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        private void SetDefaultValues(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<School>().Property(p => p.dateCreated).
                HasDefaultValue("getDate()").ValueGeneratedOnAdd();

            modelBuilder.Entity<Students>().Property(p => p.dateCreated).
                HasDefaultValue("getDate()").ValueGeneratedOnAdd();

            modelBuilder.Entity<SchoolStudent>().Property(p => p.dateCreated).
                HasDefaultValue("getDate()").ValueGeneratedOnAdd();
        }

        private void SetIndexColumn(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<School>().HasIndex(p => new { p.SchoolId });


            modelBuilder.Entity<Students>().HasIndex(p => new { p.StudentId });

            modelBuilder.Entity<SchoolStudent>().HasIndex(p => new { p.Id });
        }
    }
}
