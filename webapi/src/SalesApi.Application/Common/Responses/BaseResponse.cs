namespace SalesApi.Application.Common.Responses;

public abstract class BaseResponse<T>
{
    public bool Success { get; set; }
    public required string Message { get; set; }
    public T? Data { get; set; }
}
