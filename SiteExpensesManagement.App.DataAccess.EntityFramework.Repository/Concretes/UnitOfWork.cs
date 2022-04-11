using SiteExpensesManagement.App.DataAccess.EntityFramework.Repository.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SiteExpensesManagement.App.DataAccess.EntityFramework.Repository.Concretes
{
    public class UnitOfWork : IUnitOfWork
    {
        public ApplicationDbContext Context { get; }
        public UnitOfWork(ApplicationDbContext context)
        {
            this.Context = context;
        }
        public Task<int> CommitAsync()
        {
             return this.Context.SaveChangesAsync();
        }
        public void Commit()
        {
            this.Context.SaveChanges();
        }
        public void Dispose()
        {
            Context?.Dispose();
        }
    }
}
