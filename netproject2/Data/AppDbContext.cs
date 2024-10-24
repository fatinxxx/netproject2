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
        public DbSet<User> Users { get; set; } // Represents the Users table
        public DbSet<Subject> Subjects { get; set; }  // This is the property that represents the Subjects table


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
                new User { UserId = 1, Email = "john.doe@example.com", Password = "password123" },
                new User { UserId = 2, Email = "jane.smith@example.com", Password = "password456" }
            );

            // Seeding sample subject data associated with users
            modelBuilder.Entity<Subject>().HasData(
                new Subject { SubjectId = 1, UserId = 1, SubjectName = "Mathematics", Description = "Algebra and Geometry" },
                new Subject { SubjectId = 2, UserId = 1, SubjectName = "Physics", Description = "Mechanics and Optics" },
                new Subject { SubjectId = 3, UserId = 2, SubjectName = "Chemistry", Description = "Organic and Inorganic" }
            );
            //check subject has primary key
            modelBuilder.Entity<Subject>()
                    .HasKey(s => s.SubjectId);
            // Configure the relationship between User and Subject
            modelBuilder.Entity<Subject>()
                .HasOne(s => s.User)
                .WithMany(u => u.Subjects)
                .HasForeignKey(s => s.UserId);

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
