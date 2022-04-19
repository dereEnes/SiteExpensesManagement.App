using AutoMapper;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using SiteExpensesManagement.App.Business.Abstracts;
using SiteExpensesManagement.App.Business.Validations.FluentValidation.BillValidations;
using SiteExpensesManagement.App.Contracts.Dtos.Bills;
using SiteExpensesManagement.App.Contracts.Dtos.Result;
using SiteExpensesManagement.App.Contracts.ViewModels.Bills;
using SiteExpensesManagement.App.DataAccess.EntityFramework.Repository.Abstracts;
using SiteExpensesManagement.App.Domain.Entities;
using SiteExpensesManagement.App.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteExpensesManagement.App.Business.Concretes
{
    public class BillService : IBillService
    {
        private readonly IRepository<Bill> _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IApartmentService _apartmentService;
        public BillService(
            IRepository<Bill> repository,
            IUnitOfWork unitOfWork, IMapper mapper,
            IApartmentService apartmentService)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _apartmentService = apartmentService;
        }

        public IResult Add(BillForAddDto billForAddDto)
        {

            billForAddDto.Year = (short)DateTime.Now.Year;
            if (CheckForAlreadyExist(billForAddDto))
            {
                return new ErrorResult("Fatura Zaten Eklenmiş");
            }


            var billToAdd = _mapper.Map<Bill>(billForAddDto);
            billToAdd.CreatedAt = DateTime.Now;

            if (billForAddDto.Target == Targets.Daire)
            {
                AddBillToApartment(billToAdd, billForAddDto.ApartmentNo);

            }else if (billForAddDto.Target == Targets.Blok)
            {
                AddBillToAllBloks(billToAdd, billForAddDto.Block);
            }
            else if (billForAddDto.Target == Targets.Hepsi)
            {
                AddBillToAllApartments(billToAdd);
            }
            else
            {
                return new ErrorResult("Hatalı Deneme");
            }
            _unitOfWork.Commit();
            return new SuccessResult("Fatura Eklendi");
        }
        private void AddBillToApartment(Bill bill, int apartmentNo)
        {
            bill.ApartmentId = _apartmentService.GetApartmentIdByNo(apartmentNo);
            _repository.Add(bill);
        }
        private void AddBillToAllBloks(Bill bill, Blocks block)
        {
            var apartmentsIdList = _apartmentService.GetApartmentsIdByBlock(block);
            foreach (int id in apartmentsIdList)
            {
                bill.ApartmentId = id;
                _repository.Add(bill);
            }
        }
        private void AddBillToAllApartments(Bill bill)
        {
            var apartmentsIdList = _apartmentService.GetAllApartmentsId();
            foreach (int id in apartmentsIdList)
            {
                _repository.Add(new Bill
                {
                    ExpiryDate = bill.ExpiryDate,
                    ApartmentId = id,
                    Category = bill.Category,
                    CreatedAt = bill.CreatedAt,
                    Month = bill.Month,
                    Price = bill.Price,
                    Year = bill.Year
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
                return new SuccessResult("Fatura Silindi");
            }
            return new ErrorResult("Hatalı Deneme");
        }

        public List<BillViewModel> GetAll()
        {
            var result = _repository.GetAll()
                .Include(x => x.Apartment)
                .ToList();
            return _mapper.Map<List<BillViewModel>>(result);
        }

        public BillViewModel GetById(int id)
        {
            var result = _repository.GetById(id);
            return _mapper.Map<BillViewModel>(result);
        }

        public IResult Update(BillForUpdateDto billForUpdateDto)
        {
            var billToUpdate = _mapper.Map<Bill>(billForUpdateDto);
            _repository.Update(billToUpdate);
            _unitOfWork.Commit();
            return new SuccessResult("Fatura Güncellendi");
        }
        public bool CheckForAlreadyExist(BillForAddDto billForAddDto)
        {
            var result = _repository.Get(x => x.Month == billForAddDto.Month &&
                x.Year == billForAddDto.Year)
                .FirstOrDefault();

            if (result is null)
            {
                return false;
            }
            return true;
        }
    }
}
