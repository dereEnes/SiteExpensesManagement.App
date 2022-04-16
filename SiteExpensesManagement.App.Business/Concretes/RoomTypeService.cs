using AutoMapper;
using SiteExpensesManagement.App.Business.Abstracts;
using SiteExpensesManagement.App.Contracts.Dtos;
using SiteExpensesManagement.App.Contracts.Dtos.Result;
using SiteExpensesManagement.App.Contracts.ViewModels;
using SiteExpensesManagement.App.DataAccess.EntityFramework.Repository.Abstracts;
using SiteExpensesManagement.App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SiteExpensesManagement.App.Business.Concretes
{
    public class RoomTypeService : IRoomTypeService
    {
        private readonly IRepository<RoomType> _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RoomTypeService(IUnitOfWork unitOfWork, IRepository<RoomType> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public IResult Add(RoomTypeForAddDto roomTypeForAddDto)
        {
            if (IsRoomAlreadyExist(roomTypeForAddDto.CountOfRooms))
            {
                return new ErrorResult("Böyle bir oda tipi zaten var");
            }
            var roomTypeToAdd = _mapper.Map<RoomType>(roomTypeForAddDto);
            roomTypeToAdd.CreatedAt = DateTime.Now;
            _repository.Add(roomTypeToAdd);
            _unitOfWork.Commit();
            return new SuccessResult("Eklendi");
        }

        public IResult Delete(int id)
        {
            var result = _repository.GetById(id);
            if (result is null)
            {
                return new ErrorResult("Böyle bir id bulunamadı!");
            }
            _repository.Delete(result);
            _unitOfWork.Commit();
            return new SuccessResult("Silindi");
        }

        public IDataResult<List<RoomTypeViewModel>> GetAll()
        {
            var result = _mapper.Map<List<RoomTypeViewModel>>(_repository.GetAll());
            return new SuccessDataResult<List<RoomTypeViewModel>>(result);
        }

        public IDataResult<RoomTypeViewModel> GetById(int id)
        {
            var result = _mapper.Map<RoomTypeViewModel>(_repository.GetById(id));
            if (result is null)
            {
                return new ErrorDataResult<RoomTypeViewModel>("Böyle bir id bulunamadı!");
            }
            return new SuccessDataResult<RoomTypeViewModel>(result);
        }

        public IResult Update(RoomTypeForUpdateDto roomTypeForUpdateDto)
        {
            var result = _repository.GetById(roomTypeForUpdateDto.Id);
            result.CountOfRooms = roomTypeForUpdateDto.CountOfRooms;
            _repository.Update(result);
            _unitOfWork.Commit();
            return new SuccessResult("Güncellendi!");
        }
        public bool IsRoomAlreadyExist(string room)
        {
            var result = _repository.Get(x => x.CountOfRooms == room).SingleOrDefault();
            if (result is null)
            {
                return false;
            }
            return true;
        }
    }
}
