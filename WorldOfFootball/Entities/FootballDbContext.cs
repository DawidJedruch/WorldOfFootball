using Microsoft.EntityFrameworkCore;

namespace WorldOfFootball.Entities
{
    public class FootballDbContext : DbContext
    {
        private string _connectionString = "Server=localhost\\SQLEXPRESS01;Database=master;Trusted_Connection=True;";
        public DbSet<FootballClub> FootballClubs { get; set; }
        public DbSet<Footballer> Footballers { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FootballClub>()
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(30);

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
