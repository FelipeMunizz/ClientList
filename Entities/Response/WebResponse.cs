namespace Entities.Response;

public class WebResponse<T>
{
    public bool Success { get; set; }
    public string? Message { get; set; }
    public T? Data { get; set; }
    public List<ErrorDetail> Errors { get; set; } = new List<ErrorDetail>();

    public WebResponse() { }

    public WebResponse(bool success, string message, T data)
    {
        Success = success;
        Message = message;
        Data = data;
    }
    public class ErrorDetail
    {
        public string Code { get; set; }
        public string Message { get; set; }

        public ErrorDetail(string code, string message)
        {
            Code = code;
            Message = message;
        }
    }

    public static WebResponse<T> SuccessResponse(T data, string message = "Operação realizada com sucesso.")
    {
        return new WebResponse<T>
        {
            Success = true,
            Message = message,
            Data = data
        };
    }

    public static WebResponse<T> ErrorResponse(string message, List<ErrorDetail>? errors = null)
    {
        return new WebResponse<T>
        {
            Success = false,
            Message = message,
            Errors = errors ?? new List<ErrorDetail>()
        };
    }

    public void AddError(string code, string message)
    {
        Errors.Add(new ErrorDetail(code, message));
    }
}
