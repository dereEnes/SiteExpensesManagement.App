using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SiteExpensesManagement.App.DataAccess.EntityFramework.Repository.Abstracts
{
    public interface IRepository<T>
    {
        T GetById(int id);
        IQueryable<T> Get(Expression<Func<T,bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
