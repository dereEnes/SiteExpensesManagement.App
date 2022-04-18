using AutoMapper;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using SiteExpensesManagement.App.Business.Abstracts;
using SiteExpensesManagement.App.Business.Validations.FluentValidation;
using SiteExpensesManagement.App.Contracts.Dtos.Apartments;
using SiteExpensesManagement.App.Contracts.Dtos.Result;
using SiteExpensesManagement.App.Contracts.ViewModels.Apartments;
using SiteExpensesManagement.App.DataAccess.EntityFramework.Repository.Abstracts;
using SiteExpensesManagement.App.Domain.Entities;
using SiteExpensesManagement.App.Domain.Enums;
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
            if (CheckApartmentNoAlreadyExist(apartmentForCreateDto.ApartmentNo))
            {
                return new ErrorResult("Apartman Numarası Kullanımda");
            }
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
            var result = _mapper.Map<List<ApartmentViewModel>>(_repository.GetAll()
                .Include(x => x.User)
                .Include(x => x.RoomType));
            return new SuccessDataResult<List<ApartmentViewModel>>(result);
        }

        public IDataResult<ApartmentViewModel> GetById(int id)
        {
            var result = new ApartmentViewModel();
            try
            {
                 result = _mapper.Map<ApartmentViewModel>(_repository.Get(x => x.Id == id)
                     .Include(x => x.User)
                     .Include(x => x.RoomType)
                     .FirstOrDefault());
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

        public bool CheckApartmentNoAlreadyExist(int apartmentNo)
        {
            var result = _repository.Get(x => x.ApartmentNo == apartmentNo)
                .FirstOrDefault();
            if (result is null)
            {
                return false;
            }
            return true;
        }
        public int GetApartmentIdByNo(int apartmentNo)
        {
            var result = _repository.Get(x => x.ApartmentNo == apartmentNo)
                .FirstOrDefault();
            if (result is null)
            {
                return 0;
            }
            return result.Id;
        }
        public List<int> GetApartmentsIdByBlock(Blocks block)
        {
            return _repository.Get(x => x.Block == block)
                .Select(x=> x.Id)
                .ToList();
        }
        public List<int> GetAllApartmentsId()
        {
            return  _repository.GetAll()
                .Select(x=>x.Id)
                .ToList();
        }

        public ApartmentBillsDto GetBillsByUserId(string id)
        {
            var result = _repository.Get(x => x.UserId == id)
                .Include(x => x.Bills)
                .Include(x => x.User)
                .FirstOrDefault();
            return _mapper.Map<ApartmentBillsDto>(result);
        }
        public ApartmentDuesDto GetDuesByUserId(string id)
        {
            var result = _repository.Get(x => x.UserId == id)
                .Include(x => x.Dues)
                .Include(x => x.User)
                .FirstOrDefault();
            return _mapper.Map<ApartmentDuesDto>(result);
        }
    }
}
