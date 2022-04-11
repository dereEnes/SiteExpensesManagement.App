using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SiteExpensesManagement.App.Domain.Entities;
using System;

namespace SiteExpensesManagement.App.DataAccess.EntityFramework.Configurations
{
    public class DuesConfiguration : IEntityTypeConfiguration<Dues>
    {
        public void Configure(EntityTypeBuilder<Dues> builder)
        {
            builder.ToTable("Dues");
            builder.HasKey(x => x.Id);

            builder.HasOne<Apartment>(b => b.Apartment)
                .WithMany(a => a.Dues)
                .HasForeignKey(b => b.ApartmentId);

            builder.Property(b => b.CreatedAt).HasDefaultValue(DateTime.Now);
            builder.Property(b => b.IsPayed).HasDefaultValue(false);
        }
    }
}
