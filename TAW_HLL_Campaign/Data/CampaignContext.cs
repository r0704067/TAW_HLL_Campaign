using Microsoft.EntityFrameworkCore;
using TAW_HLL_Campaign.Models;

namespace TAW_HLL_Campaign.Data
{
    public class CampaignContext : DbContext
    {
        public CampaignContext(DbContextOptions<CampaignContext> options) : base(options)
        {
        }
        
        public DbSet<Team> Teams { get; set; }
        public DbSet<Sector> Sectors { get; set; }
        public DbSet<Road> Roads { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<BuildingType> BuildingTypes { get; set; }
        public DbSet<Maneuver> Maneuvers { get; set; }
        public DbSet<Stockpile> Stockpiles { get; set; }
        public DbSet<Defence> Defence { get; set; }
        public DbSet<Game> Games { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>().ToTable("Team");
            modelBuilder.Entity<Sector>().ToTable("Sector");
            modelBuilder.Entity<Road>().ToTable("Road");
            modelBuilder.Entity<Building>().ToTable("Building");
            modelBuilder.Entity<BuildingType>().ToTable("BuildingType");
            modelBuilder.Entity<Maneuver>().ToTable("Maneuver");
            modelBuilder.Entity<Stockpile>().ToTable("Stockpile");
            modelBuilder.Entity<Defence>().ToTable("Defence");
            modelBuilder.Entity<Game>().ToTable("Game");
        }


    }
}
