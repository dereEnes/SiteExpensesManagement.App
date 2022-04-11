using Microsoft.EntityFrameworkCore;
using SiteExpensesManagement.App.DataAccess.EntityFramework.Repository.Abstracts;
using SiteExpensesManagement.App.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SiteExpensesManagement.App.DataAccess.EntityFramework.Repository.Concretes
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        public readonly IUnitOfWork unitOfWork;
        public Repository(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public void Add(T entity)
        {
            this.unitOfWork.Context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            if (unitOfWork.Context.Entry(entity).State == EntityState.Detached) //Concurrency için 
            {
                unitOfWork.Context.Attach(entity);
            }
            unitOfWork.Context.Remove(entity);
        }

        public IQueryable<T> Get()
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
