using FastLearners.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using FastLearners.API.Modules.Domain.Models.Modules;
using FastLearners.API.Organizations.Domain.Models;
using FastLearners.API.Users.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FastLearners.API.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Organization> Organizations { get; set; }
    public DbSet<Module> Modules { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        base.OnConfiguring(builder);
        // Enable Audit Fields Interceptors
        builder.AddCreatedUpdatedInterceptor();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Configuración de la relación entre Organization y User
        //builder.Entity<Organization>()
         //    .HasOne(o => o.CreatedBy)
          //  .WithMany()
          //   .HasForeignKey(o => o.CreatedById);
        

        
        // Apply SnakeCase Naming Convention
        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }
}