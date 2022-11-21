using Microsoft.EntityFrameworkCore;
using Task.Application.Common.Interfaces;
using Task.Domain;

namespace Task.Persistence;

public class ApplicationContext : DbContext, IApplicationContext
{
    public DbSet<Country> Countries { get; set; }
    public DbSet<Village> Villages { get; set; }
    
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=villages;Username=postgres;Password=1234");
    }
}