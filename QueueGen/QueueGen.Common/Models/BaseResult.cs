namespace QueueGen.Common.Models;

public class BaseResult
{
    public bool IsSuccess => ErrorMessage == null;
    public string? ErrorMessage { get; set; }

    public static BaseResult Succeeded()
    {
        return new BaseResult();
    }

    public static BaseResult Failed(string errorMessage)
    {
        return new BaseResult
        {
            ErrorMessage = errorMessage
        };
    }
}

public class BaseResult<T> : BaseResult
{
    public T? Data { get; init; }

    public static BaseResult<T> Succeeded(T data)
    {
        return new BaseResult<T>
        {
            Data = data
        };
    }

    public new static BaseResult<T> Failed(string errorMessage)
    {
        return new BaseResult<T>
        {
            ErrorMessage = errorMessage
        };
    }
}
