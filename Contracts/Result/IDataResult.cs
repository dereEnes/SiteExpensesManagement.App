namespace SiteExpensesManagement.App.Contracts.Dtos.Result
{
    public interface IDataResult<T>:IResult
    {
        T Data { get; }
    }
}
