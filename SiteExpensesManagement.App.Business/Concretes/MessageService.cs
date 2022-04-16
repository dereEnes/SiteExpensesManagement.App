using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SiteExpensesManagement.App.Business.Abstracts;
using SiteExpensesManagement.App.Contracts.Dtos.Message;
using SiteExpensesManagement.App.Contracts.Dtos.Result;
using SiteExpensesManagement.App.Contracts.ViewModels.Message;
using SiteExpensesManagement.App.DataAccess.EntityFramework.Repository.Abstracts;
using SiteExpensesManagement.App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SiteExpensesManagement.App.Business.Concretes
{
    public class MessageService: IMessageService
    {
        private readonly IRepository<Message> _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MessageService(IRepository<Message> repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IResult Add(MessageForAddDto carForAddDto)
        {
            var messageToAdd = _mapper.Map<Message>(carForAddDto);
            messageToAdd.CreatedAt = DateTime.Now;
            messageToAdd.HasRead = false;
            messageToAdd.IsDeleted = false;

            _repository.Add(messageToAdd);
            _unitOfWork.Commit();
            return new SuccessResult("Mesaj Eklendi");
        }

        public IResult Delete(int id)
        {
            var result = _repository.GetById(id);
            if (result is null)
            {
                return new ErrorResult("Mesaj Bulunamadı!");
            }
            _repository.Delete(result);
            _unitOfWork.Commit();
            return new SuccessResult("Silindi.");
        }
        
        public IDataResult<MessageViewModel> GetById(int id)
        {
            var message = _repository.Get(x => x.Id == id).Include(x => x.Sender).FirstOrDefault();
            UpdateMessagesReadProperty(message);
            return new SuccessDataResult<MessageViewModel>(_mapper.Map<MessageViewModel>(message), "Mesaj Listelendi");
        }

        public IDataResult<List<MessageViewModel>> GetAll()
        {
            var result = _mapper.Map<List<MessageViewModel>>(_repository.GetAll().Include(x => x.Sender));
            return new SuccessDataResult<List<MessageViewModel>>(result,"Mesajlar Listelendi.");
        }

        public IResult Update(MessageForUpdateDto carForUpdateDto)
        {
            var result = _mapper.Map<Message>(carForUpdateDto);
            _repository.Update(result);
            _unitOfWork.Commit();
            return new SuccessResult("Mesaj güncellendi");
        }
        public void UpdateMessagesReadProperty(Message message)
        {
            message.HasRead = true;
            _repository.Update(message);
            _unitOfWork.Commit();
        }

        public IDataResult<List<MessageViewModel>> GetUsersMessage(string id)
        {
            var messages = _repository.Get(x => x.SenderId == id).ToList();
            return new SuccessDataResult<List<MessageViewModel>>(_mapper.Map<List<MessageViewModel>>(messages));
        }

        public IDataResult<MessageViewModel> GetByIdForSender(int id)
        {
            var message = _repository.Get(x => x.Id == id).Include(x => x.Sender).FirstOrDefault();
            return new SuccessDataResult<MessageViewModel>(_mapper.Map<MessageViewModel>(message), "Mesaj Listelendi");
        }
    }
}
