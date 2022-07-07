public class ApiResponse<T> where T: class
{
    private bool Success {get;}
    private T Result {get;} 
    public ApiResponse(bool success, T result)
    {
        Success = success;
        Result = result;
    }
}