using Contracts.Dtos.Apartment;
using Contracts.Result;
using SiteExpensesManagement.App.Domain.Entities;
using System.Collections.Generic;

namespace SiteExpensesManagement.App.Business.Abstracts
{
    public interface IApartmentService
    {
        IResult Add(ApartmentForCreateDto apartmentForCreateDto);
        IResult Update(ApartmentForCreateDto apartmentForCreateDto);
        IResult Delete(int id);
        IDataResult<Apartment> GetById(int id);
        IDataResult<List<Apartment>> GetAll();
    }
}
