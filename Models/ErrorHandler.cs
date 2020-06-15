using System;
using System.Net;
using Newtonsoft.Json;

namespace moneda
{
    public class ErrorHandler : Exception
    {
        public HttpStatusCode StatusCode { get; set; }
        // public string Message { get; set; }
        public ErrorHandler(HttpStatusCode statusCode, string Message) : base (Message)
        
        {
            this.StatusCode = statusCode;
        }
        public ErrorHandler(Exception e): base(e.Message)
        {
            this.StatusCode = HttpStatusCode.InternalServerError;
        }
    }

}
