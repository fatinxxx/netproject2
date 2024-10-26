using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using netproject2.Models;

namespace netproject2.Data
{


    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        //Default parameterless constructor
        public AppDbContext() : base(new DbContextOptions<AppDbContext>())
        {
        }
        public DbSet<User> Users { get; set; } // Represents the Users table
        public DbSet<Subject> Subjects { get; set; }  // This is the property that represents the Subjects table
        public DbSet<Assignment> Assignments { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Use Pomelo MySQL with connection string
            optionsBuilder.UseMySql("server=localhost;database=unimanage;user=root;password=rootpassword1;",
                new MySqlServerVersion(new Version(8, 0, 32)));  // Adjust version as needed
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seeding sample user data
            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, FullName = "John Doe", Email = "john.doe@example.com", Password = "password123" },
                new User { UserId = 2, FullName = "Jane Smith", Email = "jane.smith@example.com", Password = "password456" }
            );

            // Seeding sample subject data associated with users
            modelBuilder.Entity<Subject>().HasData(
                new Subject { SubjectId = 1, UserId = 1, SubjectName = "Mathematics", Description = "Algebra and Geometry" },
                new Subject { SubjectId = 2, UserId = 1, SubjectName = "Physics", Description = "Mechanics and Optics" },
                new Subject { SubjectId = 3, UserId = 2, SubjectName = "Chemistry", Description = "Organic and Inorganic" }
            );
           

            // Seeding sample assignment data
            modelBuilder.Entity<Assignment>().HasData(
                new Assignment
                {
                    AssignmentID = 1,
                    UserId = 1,
                    SubjectId = 1,
                    Title = "Assignment1: report",
                    Description = "indiviudal report",
                    AssignmentType = "Homework",
                    DueDate = DateTime.Now.AddDays(7),
                    AssignmentValue = 10.0m,
                    AssignmentResult = 0.0m
                },
                new Assignment
                {
                    AssignmentID = 2,
                    UserId = 1,
                    SubjectId = 2,
                    Title = "Assignment2: group report",
                    Description = "Write a report on the mechanics lab",
                    AssignmentType = "Lab Report",
                    DueDate = DateTime.Now.AddDays(10),
                    AssignmentValue = 20.0m,
                    AssignmentResult = 0.0m
                },
                new Assignment
                {
                    AssignmentID = 3,
                    UserId = 2,
                    SubjectId = 3,
                    Title = "Organic Chemistry Research",
                    Description = "Research on organic compounds and submit a paper",
                    AssignmentType = "Research Paper",
                    DueDate = DateTime.Now.AddDays(14),
                    AssignmentValue = 30.0m,
                    AssignmentResult = 0.0m
                }
            );
            //check subject has primary key
            modelBuilder.Entity<Subject>()
                    .HasKey(s => s.SubjectId);
            // Configure the relationship between User and Subject
            modelBuilder.Entity<Subject>()
                .HasOne(s => s.User)
                .WithMany(u => u.Subjects)
                .HasForeignKey(s => s.UserId);
            // Define relationship between Subject and Assignment
            modelBuilder.Entity<Assignment>()
                .HasOne(a => a.Subject)
                .WithMany(s => s.Assignments)
                .HasForeignKey(a => a.SubjectId);

            // Define primary key for Assignment
            modelBuilder.Entity<Assignment>()
                .HasKey(a => a.AssignmentID);
            base.OnModelCreating(modelBuilder);
        }

        public void InitializeDatabase()
        {
            // Ensures the database is created if it does not exist
            this.Database.EnsureCreated();
                // Automatically applies any pending migrations and creates the database
          //  this.Database.Migrate();

        }

    }
}
