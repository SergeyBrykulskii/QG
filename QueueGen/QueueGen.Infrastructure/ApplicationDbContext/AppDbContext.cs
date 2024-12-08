using System.Reflection;
using Microsoft.EntityFrameworkCore;
using QueueGen.Infrastructure.Entities;

namespace QueueGen.Infrastructure.ApplicationDbContext;

public sealed class AppDbContext : DbContext
{
    public DbSet<Discipline> Disciplines { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Coefficient> Coefficients { get; set; }
    public DbSet<Queue> Queues { get; set; }
    public DbSet<QueueUser> QueueUsers { get; set; }
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        //Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}