using AutoMapper;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using SiteExpensesManagement.App.Business.Abstracts;
using SiteExpensesManagement.App.Business.Validations.FluentValidation.DuesValidations;
using SiteExpensesManagement.App.Contracts.Dtos.Dues;
using SiteExpensesManagement.App.Contracts.Dtos.Result;
using SiteExpensesManagement.App.Contracts.ViewModels.Dues;
using SiteExpensesManagement.App.DataAccess.EntityFramework.Repository.Abstracts;
using SiteExpensesManagement.App.Domain.Entities;
using SiteExpensesManagement.App.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SiteExpensesManagement.App.Business.Concretes
{
    public class DuesService : IDuesService
    {
        private readonly IRepository<Dues> _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IApartmentService _apartmentService;

        public DuesService(IRepository<Dues> repository, IUnitOfWork unitOfWork, IMapper mapper, IApartmentService apartmentService)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _apartmentService = apartmentService;
        }

        public IResult Add(DuesForAddDto duesForAddDto)
        {
            duesForAddDto.Year = (short)DateTime.Now.Year;
            if (CheckForAlreadyExist(duesForAddDto))
            {
                return new ErrorResult("Fatura Zaten Eklenmiş");
            }

            var billToAdd = _mapper.Map<Dues>(duesForAddDto);
            billToAdd.CreatedAt = DateTime.Now;

            if (duesForAddDto.Target == Targets.Daire)
            {
                AddDuesToApartment(billToAdd, duesForAddDto.ApartmentNo);

            }
            else if (duesForAddDto.Target == Targets.Blok)
            {
                AddDuesToAllBloks(billToAdd, duesForAddDto.Block);
            }
            else if (duesForAddDto.Target == Targets.Hepsi)
            {
                AddDuesToAllApartments(billToAdd);
            }
            else
            {
                return new ErrorResult("Hatalı Deneme");
            }
            _unitOfWork.Commit();
            return new SuccessResult("Fatura Eklendi");
        }
        private void AddDuesToApartment(Dues dues, int apartmentNo)
        {
            dues.ApartmentId = _apartmentService.GetApartmentIdByNo(apartmentNo);
            _repository.Add(dues);
        }
        private void AddDuesToAllBloks(Dues dues, Blocks block)
        {
            var apartmentsIdList = _apartmentService.GetApartmentsIdByBlock(block);
            foreach (int id in apartmentsIdList)
            {
                dues.ApartmentId = id;
                _repository.Add(dues);
            }
        }
        private void AddDuesToAllApartments(Dues dues)
        {
            var apartmentsIdList = _apartmentService.GetAllApartmentsId();
            foreach (int id in apartmentsIdList)
            {
                _repository.Add(new Dues
                {
                    ApartmentId = id,
                    CreatedAt = dues.CreatedAt,
                    Month = dues.Month,
                    Price = dues.Price,
                    Year = dues.Year,
                });
            }
            _unitOfWork.Commit();

        }
        public IResult Delete(int id)
        {
            var result = _repository.GetById(id);
            if (result is null)
            {
                _repository.Delete(result);
                _unitOfWork.Commit();
                return new SuccessResult("Aidat Silindi");
            }
            return new ErrorResult("Hatalı Deneme");
        }

        public IDataResult<List<DuesViewModel>> GetAll()
        {
            var result = _repository.GetAll().Include(x => x.Apartment).ToList();
            return new SuccessDataResult<List<DuesViewModel>>(_mapper.Map<List<DuesViewModel>>(result));
        }

        public IDataResult<DuesViewModel> GetById(int id)
        {
            return new SuccessDataResult<DuesViewModel>(_mapper.Map<DuesViewModel>(_repository.GetById(id)));
        }

        public IResult Update(DuesForUpdateDto duesForUpdateDto)
        {
            DuesForUpdateDtoValidator validator = new DuesForUpdateDtoValidator();
            ValidationResult result = validator.Validate(duesForUpdateDto);

            if (!result.IsValid)
            {
                return new ErrorResult("Geçersiz Aidat Bilgisi");
            }

            var duesToUpdate = _mapper.Map<Dues>(duesForUpdateDto);
            _repository.Update(duesToUpdate);
            _unitOfWork.Commit();
            return new SuccessResult("Aidat Güncellendi");
        }
        private bool CheckForAlreadyExist(DuesForAddDto duesForAddDto)
        {
            var result = _repository.Get(
                x => x.Month == duesForAddDto.Month && 
                x.Year == duesForAddDto.Year && 
                x.ApartmentId == duesForAddDto.ApartmentNo)
                .FirstOrDefault();

            if (result is null)
            {
                return false;
            }
            return true;
        }
    }
}
