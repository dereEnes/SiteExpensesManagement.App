using SiteExpensesManagement.App.Business.Abstracts;
using SiteExpensesManagement.App.DataAccess.EntityFramework.Repository.Abstracts;
using SiteExpensesManagement.App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteExpensesManagement.App.Business.Concretes
{
    public class ApartmentService : IApartmentService
    {
        private readonly IRepository<Apartment> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public ApartmentService(IRepository<Apartment> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public List<Apartment> GetAll()
        {
            var result = _repository.GetAll().ToList();
            return result;
        }

        public Task<Apartment> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
