using Microsoft.EntityFrameworkCore;

namespace TestProject.Data
{
    public class ZipContext : DbContext
    {

        public ZipContext() : base()
        {

        }

        public ZipContext(DbContextOptions<ZipContext> options) : base(options)
        {

        }

        public DbSet<Model.Account> Accounts { get; set; }
        public DbSet<Model.User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Model.User>()
                .HasIndex(p => new { p.EmailAddress })
                .IsUnique(true);

        }
    }
}
