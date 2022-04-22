namespace Payment.API.Results
{
    public class Result : IResult
    {
        public bool Success { get; set; }

        public string Message { get; set; }

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
