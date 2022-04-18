using AutoMapper;
using FluentValidation.Results;
using SiteExpensesManagement.App.Business.Abstracts;
using SiteExpensesManagement.App.Business.Validations.FluentValidation.DuesValidations;
using SiteExpensesManagement.App.Contracts.Dtos.Dues;
using SiteExpensesManagement.App.Contracts.Dtos.Result;
using SiteExpensesManagement.App.Contracts.ViewModels.Dues;
using SiteExpensesManagement.App.DataAccess.EntityFramework.Repository.Abstracts;
using SiteExpensesManagement.App.Domain.Entities;
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

        public DuesService(IRepository<Dues> repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IResult Add(DuesForAddDto duesForAddDto)
        {
            DuesForAddDtoValidator validator = new DuesForAddDtoValidator();
            ValidationResult result = validator.Validate(duesForAddDto);

            if (!result.IsValid || !CheckForAlreadyExist(duesForAddDto))
            {
                return new ErrorResult("Geçersiz Aidat");
            }

            var duesToAdd = _mapper.Map<Dues>(duesForAddDto);
            _repository.Add(duesToAdd);
            _unitOfWork.Commit();
            return new SuccessResult("Aidat Eklendi");
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
            var result = _repository.GetAll();
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
            var result = _repository.Get(x => x.Month == duesForAddDto.Month && x.Year == duesForAddDto.Year).FirstOrDefault();
            if (result is null)
            {
                return false;
            }
            return true;
        }
    }
}
