using SiteExpensesManagement.App.Contracts.Dtos.Apartments;
using SiteExpensesManagement.App.Contracts.Dtos.Result;
using SiteExpensesManagement.App.Contracts.ViewModels.Apartments;
using SiteExpensesManagement.App.Domain.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SiteExpensesManagement.App.Business.Abstracts
{
    public interface IApartmentService
    {
        IResult Add(ApartmentForCreateDto apartmentForCreateDto);
        IResult Update(ApartmentForUpdateDto apartmentForCreateDto);
        IResult Delete(int id);
        IDataResult<ApartmentViewModel> GetById(int id);
        IDataResult<List<ApartmentViewModel>> GetAll();
        int GetApartmentIdByNo(int apartmentNo);
        List<int> GetApartmentsIdByBlock(Blocks block);
        Task<List<int>> GetAllApartmentsId();
    }
}
