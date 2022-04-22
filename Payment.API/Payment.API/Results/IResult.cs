namespace Payment.API.Results
{
    public interface IResult
    {
         bool Success { get; }

         string Message { get; }
    }
}
