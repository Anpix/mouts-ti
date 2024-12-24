namespace SalesApi.WebApi.Common.Responses;

public class ApiResponseWithData<T> : ApiResponse
{
    public T? Data { get; set; }
}
