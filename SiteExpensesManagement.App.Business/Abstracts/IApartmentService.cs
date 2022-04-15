using SiteExpensesManagement.App.Contracts.Dtos.Apartment;
using SiteExpensesManagement.App.Contracts.Dtos.Result;
using SiteExpensesManagement.App.Contracts.ViewModels.Apartment;
using System.Collections.Generic;

namespace SiteExpensesManagement.App.Business.Abstracts
{
    public interface IApartmentService
    {
        IResult Add(ApartmentForCreateDto apartmentForCreateDto);
        IResult Update(ApartmentForUpdateDto apartmentForCreateDto);
        IResult Delete(int id);
        IDataResult<ApartmentViewModel> GetById(int id);
        IDataResult<List<ApartmentViewModel>> GetAll();
    }
}
