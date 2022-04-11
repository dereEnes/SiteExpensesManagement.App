

namespace SiteExpensesManagement.App.DataAccess.EntityFramework.Repository.Abstracts
{
    public interface IUnitOfWork
    {
        ApplicationDbContext Context { get; }
        void Commit();
    }
}
