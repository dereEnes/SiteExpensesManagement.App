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
            builder.HasKey(d => d.Id);

            builder.HasOne<Apartment>(b => b.Apartment)
                .WithMany(a => a.Dues)
                .HasForeignKey(b => b.ApartmentId);

            builder.Property(d => d.IsPayed).HasDefaultValue(false);
            builder.Property(d => d.Amount).HasColumnType("decimal(18,2)");
        }
    }
}
