using FleetMan.Models;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Vessel> Vessels { get; set; }
    public DbSet<NoonReport> NoonReports { get; set; }
}