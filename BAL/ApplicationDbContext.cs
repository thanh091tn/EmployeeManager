using Microsoft.EntityFrameworkCore;
using BO.Models;

namespace DAL
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<UserEntity> User { get; set; }
        public DbSet<RoleEntity> Role { get; set; }
        public DbSet<TaskEntity> Task { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    }

}
