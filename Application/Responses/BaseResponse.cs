namespace Application.Responses;

public class BaseResponse
{
    public BaseResponse()
    {
        Success = true;
    }

    public BaseResponse(string message = null)
    {
        Success = true;
        Message = message;
    }

    public BaseResponse(string message, bool success)
    {
        Message = message;
        Success = success;
    }

    public bool Success { get; set; }
    public string Message { get; set; }
    public List<string> ValidationErrors { get; set; }
}