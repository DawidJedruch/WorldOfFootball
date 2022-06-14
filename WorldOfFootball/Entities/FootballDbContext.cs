using Microsoft.EntityFrameworkCore;

namespace WorldOfFootball.Entities
{
    public class FootballDbContext : DbContext
    {
        private string _connectionString = "Server=localhost\\SQLEXPRESS01;Database=WorldOfFootball;Trusted_Connection=True;";
        public DbSet<FootballClub> FootballClubs { get; set; }
        public DbSet<Footballer> Footballers { get; set;}
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .IsRequired();

            modelBuilder.Entity<Role>()
                .Property(u => u.Name)
                .IsRequired();

            modelBuilder.Entity<FootballClub>()
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(25);

            modelBuilder.Entity<Footballer>()
                .Property(x => x.LastName)
                .IsRequired();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
