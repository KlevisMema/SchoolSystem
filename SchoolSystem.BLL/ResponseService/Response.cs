using System.Net;

namespace SchoolSystem.BLL.ResponseService
{
    public class Response<T> where T : class
    {
        public string? Message { get; set; }
        public T? Value { get; set; }
        public bool Success { get; set; }
        public HttpStatusCode StatusCode { get; set; }

        /* Constructor overloading */
        public Response(string? errorMessage)
        {
            Message = errorMessage;
        }

        public Response(string? errorMessage, T? value, bool success, HttpStatusCode statusCode)
        {
            Message = errorMessage;
            Value = value;
            Success = success;
            StatusCode = statusCode;
        }

        public Response(string? errorMessage, HttpStatusCode statusCode, bool success)
        {
            Message = errorMessage;
            Value = default;
            Success = success;
            StatusCode = statusCode;
        }

        /* Static methods to return */
        public static Response<T> Ok(T value)
        {
            return new Response<T>(String.Empty, value, true, HttpStatusCode.OK);
        }

        public static Response<T> NotFound(string errorMessage)
        {
            return new Response<T>(errorMessage, HttpStatusCode.NotFound, false);
        }

        public static Response<T> SuccessMessage(string message)
        {
            return new Response<T>(message, HttpStatusCode.OK, true);
        }

        public static Response<T> ErrorMsg(string ThrowMessage)
        {
            return new Response<T>(ThrowMessage, HttpStatusCode.InternalServerError, false);
        }
    }
}
