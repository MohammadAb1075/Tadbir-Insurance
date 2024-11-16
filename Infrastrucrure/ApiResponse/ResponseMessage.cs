namespace Infrastrucrure.ApiResponse;

public static class ResponseMessage
{
    public static ApiResponse<string> Success()
    {
        return new ApiResponse<string>
        {
            IsSuccess = true,
            Data = "Successfull",
            Errors = null,
        };
    }
    
    public static ApiResponse<T> Success<T>(T data)
    {
        return new ApiResponse<T>
        {
            IsSuccess = true,
            Data = data,
            Errors = null,
        };
    }

    public static ApiResponse<string> Failure(params string[] errors)
    {
        return new ApiResponse<string>
        {
            IsSuccess = false,
            Data = "Failed",
            Errors = errors is null ? null : errors,
        };
    }
}
