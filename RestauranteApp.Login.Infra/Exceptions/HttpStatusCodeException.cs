using System.Net;

namespace RestauranteApp.Login.Infra.Exceptions
{
    public class HttpStatusCodeException : IOException
    {
        public HttpStatusCode StatusCode { get; }

        public HttpStatusCodeException(HttpStatusCode statusCode, string message, Exception innerException = null)
            : base(message, innerException)
        {
            StatusCode = statusCode;
        }
    }
}
