using DataLogicLayer.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataLogicLayer.Data
{
    public class ApplicationDbContext : IdentityDbContext<UserData>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            //Database.EnsureCreated();
        }

        public DbSet<QueueData> Queue { get; set; }
        public DbSet<UserData> User { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<QueueData>().HasKey(m => m.Id);
            builder.Entity<UserData>().HasKey(m => m.Id);
            base.OnModelCreating(builder);
        }
    }
}
