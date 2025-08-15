namespace UserApiWithSQLite.Helpers
{
    public class ServiceResult<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; } = "";
        public int StatusCode { get; set; }
        public T? Data { get; set; }

        public static ServiceResult<T> SuccessResult(T data) =>
            new() { Success = true, StatusCode = 200, Data = data };

        public static ServiceResult<T> Fail(string message, int statusCode) =>
            new() { Success = false, Message = message, StatusCode = statusCode };
    }
}
