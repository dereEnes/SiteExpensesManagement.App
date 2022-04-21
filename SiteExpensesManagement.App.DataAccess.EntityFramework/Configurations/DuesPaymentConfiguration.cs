using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SiteExpensesManagement.App.Domain.Entities;

namespace SiteExpensesManagement.App.DataAccess.EntityFramework.Configurations
{
    public partial class BillConfiguration
    {
        public class DuesPaymentConfiguration : IEntityTypeConfiguration<DuesPayment>
        {
            public void Configure(EntityTypeBuilder<DuesPayment> builder)
            {
                builder.ToTable("BillPayments", "dbo");
                builder.Property(x => x.Id).ValueGeneratedOnAdd();

                builder.HasKey(x => x.Id);

                builder.HasOne<ApplicationUser>(b => b.User)
                    .WithMany(a => a.DuesPayments)
                    .HasForeignKey(b => b.UserId);

                
            }
        }
    }
}
