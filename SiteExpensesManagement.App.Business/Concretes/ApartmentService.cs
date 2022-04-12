using AutoMapper;
using Contracts.Dtos.Apartment;
using Contracts.Result;
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
        private readonly IMapper _mapper;

        public ApartmentService(IRepository<Apartment> repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IResult Add(ApartmentForCreateDto apartmentForCreateDto)
        {
            var apartmentToAdd = _mapper.Map<Apartment>(apartmentForCreateDto);
            var a = 5;
            return new SuccessResult("Eklendi");
        }

        public IResult Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Apartment>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Apartment> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(ApartmentForCreateDto apartmentForCreateDto)
        {
            throw new NotImplementedException();
        }
    }
}
