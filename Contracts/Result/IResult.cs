namespace SiteExpensesManagement.App.Contracts.Dtos.Result
{
    public interface IResult
    {
         bool Success { get; }

         string Message { get; }
    }
}
