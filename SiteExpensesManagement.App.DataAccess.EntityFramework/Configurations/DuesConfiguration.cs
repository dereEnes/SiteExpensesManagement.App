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
            builder.ToTable("Dues", "dbo");
            builder.HasKey(d => d.Id);

            builder.HasOne<Apartment>(b => b.Apartment)
                .WithMany(a => a.Dues)
                .HasForeignKey(b => b.ApartmentId);

            builder.HasOne<DuesPayment>(a => a.DuesPayment)
                .WithOne(r => r.Dues)
                .HasForeignKey<DuesPayment>(r => r.DuesId);

            builder.Property(d => d.IsPayed).HasDefaultValue(false);
            builder.Property(d => d.Price).HasColumnType("decimal(18,2)");
        }
    }
}
