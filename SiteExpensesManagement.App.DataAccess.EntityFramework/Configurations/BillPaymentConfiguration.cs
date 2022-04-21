using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SiteExpensesManagement.App.Domain.Entities;

namespace SiteExpensesManagement.App.DataAccess.EntityFramework.Configurations
{
        public class BillPaymentConfiguration : IEntityTypeConfiguration<BillPayment>
        {
            public void Configure(EntityTypeBuilder<BillPayment> builder)
            {
                builder.ToTable("BillPayments", "dbo");
                builder.Property(x => x.Id).ValueGeneratedOnAdd();

                builder.HasKey(x => x.Id);

                builder.HasOne<ApplicationUser>(b => b.User)
                    .WithMany(a => a.BillPayments)
                    .HasForeignKey(b => b.UserId);
            }
        }
}
