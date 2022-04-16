using SiteExpensesManagement.App.Contracts.Dtos.Apartment;
using SiteExpensesManagement.App.Contracts.Dtos.Message;
using SiteExpensesManagement.App.Contracts.Dtos.Result;
using SiteExpensesManagement.App.Contracts.ViewModels.Apartment;
using SiteExpensesManagement.App.Contracts.ViewModels.Message;
using System.Collections.Generic;


namespace SiteExpensesManagement.App.Business.Abstracts
{
    public interface IMessageService
    {
        IResult Add(MessageForAddDto apartmentForCreateDto);
        IResult Update(MessageForUpdateDto apartmentForCreateDto);
        IResult Delete(int id);
        IDataResult<MessageViewModel> GetById(int id);
        IDataResult<MessageViewModel> GetByIdForSender(int id);
        IDataResult<List<MessageViewModel>> GetAll();
        IDataResult<List<MessageViewModel>> GetUsersMessage(string id);
    }
}
