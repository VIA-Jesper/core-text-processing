using DistinctWebAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DistinctWebAPI.Database;

public class TextDbContext : DbContext
{
    private IConfiguration Config { get; set; }
    
    
    public TextDbContext(IConfiguration config)
    {
        Config = config;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(Config.GetConnectionString("DatabaseConnection"));
    }

    public IConfiguration GetConfig() => Config;

    public DbSet<DistinctWord> UniqueWords { get; set; }
    public DbSet<WatchlistWord> Watchlist { get; set; }
}