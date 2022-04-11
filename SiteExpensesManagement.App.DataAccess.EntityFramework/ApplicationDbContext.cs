using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SiteExpensesManagement.App.Domain;

namespace SiteExpensesManagement.App.DataAccess.EntityFramework
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.HasDefaultSchema("Identity");
            
            builder.Entity<ApplicationUser>(entity =>
            {
                entity.ToTable("Users");
                entity.Property<string>(x => x.FirstName).HasMaxLength(30);
                entity.Property<string>(x => x.LastName).HasMaxLength(30);
                entity.Property<string>(x => x.TcNo).HasMaxLength(11);


            });

            builder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable("Roles");
                
            });

            builder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable("UserRoles");
            });

            builder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable("UserClaims");
            });
            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable("UserLogins");
            });

            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable("UserTokens");
            });
        }
    }
}
