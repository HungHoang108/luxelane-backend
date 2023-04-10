
using System.Net;

namespace Luxelane.Helpers
{
    public class ServiceException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }
        public override string Message { get; }

        public ServiceException(HttpStatusCode statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
        }

        public static ServiceException NotFound(string message = "Item is not found")
        {
            return new ServiceException(HttpStatusCode.NotFound, message);
        }

        public static ServiceException Unauthorized(string message = "Unauthorized")
        {
            return new ServiceException(HttpStatusCode.Unauthorized, message);
        }

        public static ServiceException CreationError(string message = "Failed to create entity")
        {
            return new ServiceException(HttpStatusCode.UnprocessableEntity, message);
        }

        public static ServiceException UserSignUpError(string message = "Failed to sign up user")
        {
            return new ServiceException(HttpStatusCode.UnprocessableEntity, message);
        }
    }
}