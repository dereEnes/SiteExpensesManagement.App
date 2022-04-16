using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SiteExpensesManagement.App.Business.Abstracts;
using SiteExpensesManagement.App.Business.Validations.FluentValidation;
using SiteExpensesManagement.App.Contracts.Dtos.Car;
using SiteExpensesManagement.App.Contracts.Dtos.Result;
using SiteExpensesManagement.App.Contracts.ViewModels.Car;
using SiteExpensesManagement.App.DataAccess.EntityFramework.Repository.Abstracts;
using SiteExpensesManagement.App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SiteExpensesManagement.App.Business.Concretes
{
    public class CarService : ICarService
    {
        private readonly IRepository<Car> _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CarService(IRepository<Car> repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IResult Add(CarForAddDto carForAddDto)
        {
            var carToAdd = _mapper.Map<Car>(carForAddDto);
            _repository.Add(carToAdd);
            _unitOfWork.Commit();
            return new SuccessResult("Araç eklendi");
        }

        public IResult Delete(int id)
        {
            var result = _repository.GetById(id);
            if (result is null)
            {
                return new ErrorResult("Araç bulunamadı!");
            }
            _repository.Delete(result);
            _unitOfWork.Commit();
            return new SuccessResult("Silindi.");
        }

        public IDataResult<CarViewModel> GetById(int id)
        {
            var result = _mapper.Map<CarViewModel>(_repository.Get(x => x.Id == id).Include(x => x.User).FirstOrDefault());
            return new SuccessDataResult<CarViewModel>(result);
        }

        public IDataResult<List<CarViewModel>> GetAll()
        {
            var result = _repository.GetAll().Include(x => x.User);
            return new SuccessDataResult<List<CarViewModel>>(_mapper.Map<List<CarViewModel>>(result));
        }

        public IResult Update(CarForUpdateDto carForUpdateDto)
        {
            var result = _mapper.Map<Car>(carForUpdateDto);
            _repository.Update(result);
            _unitOfWork.Commit();
            return new SuccessResult("Araç güncellendi");
        }
    }
}
