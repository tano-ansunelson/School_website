using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Schoolwebsite.Models;

namespace Schoolwebsite.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // public DbSet<AdminUser> AdminUsers { get; set; } = null!;
        public DbSet<Teacher> Teachers => Set<Teacher>();
        public DbSet<SchoolEvent> Events => Set<SchoolEvent>();
        public DbSet<Course> Courses => Set<Course>();
        public DbSet<BlogPost> BlogPosts => Set<BlogPost>();
        // Define your DbSets for your entities here
        // Example:
         public DbSet<Student> Students=> Set<Student>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configure your entity relationships and constraints here
            // Example:
            // modelBuilder.Entity<YourEntity>()
            //     .HasKey(e => e.Id);
        }
    }
}