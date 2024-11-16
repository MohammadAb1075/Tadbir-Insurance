namespace Infrastrucrure.ApiResponse;

public class ApiResponse<T>
{
    public bool IsSuccess { get; set; }
    public T Data { get; set; }
    public ICollection<string> Errors { get; set; }
}
