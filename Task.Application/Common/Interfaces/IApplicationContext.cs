using Microsoft.EntityFrameworkCore;
using Task.Domain;

namespace Task.Application.Common.Interfaces;

public interface IApplicationContext
{
    public DbSet<Country> Countries { get; set; }
    public DbSet<Village> Villages { get; set; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}