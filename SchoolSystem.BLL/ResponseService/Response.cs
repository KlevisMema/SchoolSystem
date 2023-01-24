using System.Net;

namespace SchoolSystem.BLL.ResponseService
{
    /// <summary>
    ///     A generic class to retrun custom response with object, HttpStatusCode , success and a custom message
    /// </summary>
    /// <typeparam name="T"> Type of response object </typeparam>
    public class Response<T> where T : class
    {
        #region Parameters 

        /// <summary>
        ///     String message
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        ///     T object 
        /// </summary>
        public T Value { get; set; }
        /// <summary>
        ///     Success 
        /// </summary>
        public bool Success { get; set; }
        /// <summary>
        ///     Status code
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }

        #endregion

        #region Constructor overloading 

        /// <summary>
        ///     Executed when the class is called/instansiated with the same number and type of parameters. 
        /// </summary>
        /// <param name="errorMessage"> Custom string message, depends on the type of the operation outcome </param>
        /// <param name="statusCode"> Http status code </param>
        /// <param name="success"> Success : true or false, depends on the type of the operation outcome </param>
        public Response
        (
            string errorMessage,
            bool success,
            HttpStatusCode statusCode
        )
        {
            Message = errorMessage;
            Success = success;
            StatusCode = statusCode;
        }

        /// <summary>
        ///     Executed when the class is called/instansiated with the same number and type of parameters. 
        /// </summary>
        /// <param name="errorMessage"> Custom string message, depends on the type of the operation outcome </param>
        /// <param name="value"> Object values, depends on the type of the operation outcome </param>
        /// <param name="success"> Success : true or false, depends on the type of the operation outcome </param>
        /// <param name="statusCode"> The status code, depends on the type of the operation outcome </param>
        public Response
        (
            string errorMessage,
            T value,
            bool success,
            HttpStatusCode statusCode
        )
        {
            Message = errorMessage;
            Value = value;
            Success = success;
            StatusCode = statusCode;
        }

        /// <summary>
        ///     Executed when the class is called/instansiated with the same number and type of parameters. 
        /// </summary>
        /// <param name="errorMessage"> Custom string message, depends on the type of the operation outcome </param>
        /// <param name="statusCode"> The status code, depends on the type of the operation outcome </param>
        /// <param name="success"> Success : true or false, depends on the type of the operation outcome </param>
        public Response
        (
            string errorMessage,
            HttpStatusCode statusCode,
            bool success
        )
        {
            Message = errorMessage;
            Value = default;
            Success = success;
            StatusCode = statusCode;
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Should be used when an operation ended succsessfuly 
        /// </summary>
        /// <param name="value"> The object you want to return </param>
        /// <returns> A response object containig the object values, an empty message, success : true, and status code ok </returns>
        public static Response<T> Ok
        (
            T value
        )
        {
            return new Response<T>(String.Empty, value, true, HttpStatusCode.OK);
        }

        /// <summary>
        ///     Should be used when you query something and it has no result
        /// </summary>
        /// <param name="errorMessage"> Custom string message </param>
        /// <returns> A response object containing the message , status code not found  and success : false </returns>
        public static Response<T> NotFound
        (
            string errorMessage
        )
        {
            return new Response<T>(errorMessage, HttpStatusCode.NotFound, false);
        }

        /// <summary>
        ///    Should be used message when an operation ended succsessfuly 
        /// </summary>
        /// <param name="message"> Custom string messgae </param>
        /// <returns> A custom succsess message and status code ok </returns>
        public static Response<T> SuccessMessage
        (
            string message
        )
        {
            return new Response<T>(message, HttpStatusCode.OK, true);
        }

        /// <summary>
        ///     Should be used when an expetion is thrown 
        /// </summary>
        /// <param name="ThrowMessage"> Custom string error message to return to the user </param>
        /// <returns> A response object containing the custom message, status code internal server error, and success : false </returns>
        public static Response<T> ErrorMsg
        (
            string ThrowMessage
        )
        {
            return new Response<T>(ThrowMessage, HttpStatusCode.InternalServerError, false);
        }

        /// <summary>
        ///     Should be used when an operation went unsuccessfuly
        /// </summary>
        /// <param name="message"> Custom string error message to return to the user </param>
        /// <returns> A response object containing the custom message, and success : false, status code fobidden </returns>
        public static Response<T> UnSuccessMessage
        (
            string message
        )
        {
            return new Response<T>(message, false, HttpStatusCode.Forbidden);
        }

        #endregion

    }
}