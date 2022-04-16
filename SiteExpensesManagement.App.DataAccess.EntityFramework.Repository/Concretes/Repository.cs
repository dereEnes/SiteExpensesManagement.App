using Microsoft.EntityFrameworkCore;
using SiteExpensesManagement.App.DataAccess.EntityFramework.Repository.Abstracts;
using SiteExpensesManagement.App.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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
            T exist = unitOfWork.Context.Set<T>().Find(entity.Id);
            if (exist != null)
            {
                exist.IsDeleted = true;
                unitOfWork.Context.Entry(entity).State = EntityState.Modified;
            }
        }

        public IQueryable<T> GetAll()
        {
            //return await unitOfWork.Context.Set<T>().Where(x => !x.IsDeleted).ToListAsync();
            return unitOfWork.Context.Set<T>().Where(x => !x.IsDeleted).AsQueryable().AsNoTracking();
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> filter)
        {
            return unitOfWork.Context.Set<T>().Where(x => !x.IsDeleted).Where(filter).AsQueryable().AsNoTracking();
        }

        public T GetById(int id)
        {
            return unitOfWork.Context.Set<T>().Where(x => !x.IsDeleted && x.Id == id).FirstOrDefault();
        }

        public void Update(T entity)
        {
            unitOfWork.Context.Entry(entity).State = EntityState.Modified;
        }
    }
}
