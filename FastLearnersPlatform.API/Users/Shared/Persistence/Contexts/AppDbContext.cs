using FastLearnersPlatform.API.Users.Shared.Extensions;

namespace FastLearnersPlatform.API.Users.Shared.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using FastLearnersPlatform.API.Users.Domain.Model;
public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.UseSnakeCaseNamingConvention();

        // Configuración adicional del modelo si es necesario
        modelBuilder.Entity<User>().ToTable("users");
    }
}