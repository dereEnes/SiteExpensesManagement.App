namespace Payment.API.Results
{
    public interface IDataResult<T>:IResult
    {
        T Data { get; }
    }
}
