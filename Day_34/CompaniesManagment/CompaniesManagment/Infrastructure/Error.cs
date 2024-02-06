using CompaniesManagmentApplication.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CompaniesManagment.Infrastructure
{
    public class Error : ProblemDetails
    {
        private const string UnhandlerErrorCode = "UnhandledError";
        private HttpContext HttpContext { get; set; }
        private Exception Ex { get; set; }
        private string Code { get; set; }

        private string? TraceId
        {
            get => Extensions.TryGetValue("TraceId", out var traceId) ? (string?)traceId : null;
            set => Extensions["TraceId"] = value;
        }

        public Error(HttpContext httpContext, Exception ex)
        {
            HttpContext = httpContext;
            Ex = ex;
            Extensions["TraceId"] = httpContext.TraceIdentifier;
            Code = UnhandlerErrorCode;
            Status = (int)HttpStatusCode.InternalServerError;
            Title = "გაუთვალისწინებელი შეცდომა";
            Instance = httpContext.Request.Path;

            HandleException((dynamic)ex);
        }

        private void HandleException(CompanyNotFoundException exception)
        {
            Code = exception.Code;
            Status = (int)HttpStatusCode.BadRequest;
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4";
            Title = exception.Message;
        }

        private void HandleException(MethodIsNotAllowedException exception)
        {
            Code = exception.Code;
            Status = (int)HttpStatusCode.Unauthorized;
            Type = "https://datatracker.ietf.org/doc/html/rfc7235#section-3.1";
            Title = exception.Message;
        }

        public override string ToString()
        {
            return $"Time: {DateTime.Now} \nTrace ID: {HttpContext.TraceIdentifier} \nCode: {Code} \nStatus: {Status} \nException message: {Ex.Message} \nInstance: {Instance} \nStack trace: {Ex.StackTrace} \n";
        }
    }
}
