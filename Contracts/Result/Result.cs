namespace SiteExpensesManagement.App.Contracts.Dtos.Result
{
    public class Result : IResult
    {
        public bool Success { get; }

        public string Message { get; }

        public Result(bool success,string message):this(success)
        {
            
            this.Message = message;
        }
        public Result(bool success)
        {
            this.Success = success;
        }
        public Result()
        {

        }
    }
}
