using tuto.Models;
using Microsoft.EntityFrameworkCore;

namespace tuto.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Reclamation> Reclamations { get; set; }
}