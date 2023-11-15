using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentsMangement.Models;

namespace StudentsMangement.Data
{
    public class StudentsMangementContext : DbContext
    {
        public StudentsMangementContext (DbContextOptions<StudentsMangementContext> options)
            : base(options)
        {
        }

        public DbSet<StudentsMangement.Models.Student> Student { get; set; } = default!;

        public DbSet<StudentsMangement.Models.Staff>? Staff { get; set; }

        public DbSet<StudentsMangement.Models.Courze>? Courze { get; set; }

        public DbSet<StudentsMangement.Models.Clazz>? Clazz { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasOne(e => e.Clazzes).WithMany(e => e.Students);
            modelBuilder.Entity<Student>()
                .HasOne(e => e.Courzes).WithMany(e => e.Students);
            modelBuilder.Entity<Staff>()
                .HasMany(e => e.Department).WithMany(e => e.Staffs);
            modelBuilder.Entity<Clazz>()
               .HasMany(e => e.Staffs).WithMany(e => e.Clazzes);

            base.OnModelCreating(modelBuilder);
        }
    }
}
