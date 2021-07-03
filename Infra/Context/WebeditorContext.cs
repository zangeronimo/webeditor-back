using Domain.Models.Webeditor;
using Microsoft.EntityFrameworkCore;

namespace Infra.Context
{
    public class WebeditorContext : DbContext
    {
        public WebeditorContext(DbContextOptions options) :
            base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Company> Companies { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Module> Modules { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<User>()
                .HasMany(u => u.Roles)
                .WithMany(r => r.Users)
                .UsingEntity<UserHasRole>(ur =>
                    ur
                        .HasOne(prop => prop.Role)
                        .WithMany()
                        .HasForeignKey(prop => prop.RoleId),
                ur =>
                    ur
                        .HasOne(prop => prop.User)
                        .WithMany()
                        .HasForeignKey(prop => prop.UserId),
                ur =>
                {
                    ur.HasKey(prop => new { prop.RoleId, prop.UserId });
                });
            modelBuilder
                .Entity<Company>()
                .HasMany(c => c.Modules)
                .WithMany(m => m.Companies)
                .UsingEntity<CompanyHasModule>(cm =>
                    cm
                        .HasOne(prop => prop.Module)
                        .WithMany()
                        .HasForeignKey(prop => prop.ModuleId),
                cm =>
                    cm
                        .HasOne(prop => prop.Company)
                        .WithMany()
                        .HasForeignKey(prop => prop.CompanyId),
                cm =>
                {
                    cm.HasKey(prop => new { prop.ModuleId, prop.CompanyId });
                });
            base.OnModelCreating(modelBuilder);
        }
    }
}
