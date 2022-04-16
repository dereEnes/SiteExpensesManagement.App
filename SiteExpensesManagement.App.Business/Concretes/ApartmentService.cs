using AutoMapper;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using SiteExpensesManagement.App.Business.Abstracts;
using SiteExpensesManagement.App.Business.Validations.FluentValidation;
using SiteExpensesManagement.App.Contracts.Dtos.Apartment;
using SiteExpensesManagement.App.Contracts.Dtos.Result;
using SiteExpensesManagement.App.Contracts.ViewModels.Apartment;
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
            apartmentToAdd.CreatedAt = DateTime.Now;
            apartmentToAdd.IsEmpty = false;
            _repository.Add(apartmentToAdd);
            _unitOfWork.Commit();
            return new SuccessResult("Eklendi");
        }

        public IResult Delete(int id)
        {
            var apartmentToDelete = _repository.GetById(id);
            if (apartmentToDelete is null)
            {
                return new ErrorResult("Apartman bulunamadı!");
            }
            _repository.Delete(apartmentToDelete);
            _unitOfWork.Commit();
            return new SuccessResult("Silindi");
        }

        public IDataResult<List<ApartmentViewModel>> GetAll()
        {
            var result = _mapper.Map<List<ApartmentViewModel>>(_repository.GetAll().Include(x => x.User).Include(x => x.RoomType));
            return new SuccessDataResult<List<ApartmentViewModel>>(result);
        }

        public IDataResult<ApartmentViewModel> GetById(int id)
        {
            var result = new ApartmentViewModel();
            try
            {
                 result = _mapper.Map<ApartmentViewModel>(_repository.Get(x => x.Id == id).Include(x => x.User).Include(x => x.RoomType).FirstOrDefault());
            }
            catch (Exception)
            {
                return new ErrorDataResult<ApartmentViewModel>("Hata oluştu");
                throw;
            }
            return new SuccessDataResult<ApartmentViewModel>(result,"Apartman getirildi.");
        }

        public IResult Update(ApartmentForUpdateDto apartmentForCreateDto)
        {
            var result = _mapper.Map<Apartment>(apartmentForCreateDto);
            _repository.Update(result);
            _unitOfWork.Commit();
            return new SuccessResult("Apartman güncellendi");
        }
    }
}
