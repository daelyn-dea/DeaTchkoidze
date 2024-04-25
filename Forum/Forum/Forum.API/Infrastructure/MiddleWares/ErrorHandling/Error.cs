// Copyright (C) TBC Bank. All Rights Reserved.

using System.Net;
using Forum.Application.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Forum.API.Infrastructure.MiddleWares.ErrorHandling
{
    /// <summary>
    /// Represents an error response to be returned to the client.
    /// </summary>
    public class Error : ProblemDetails
    {
        /// <summary>
        /// Unhandled eror code
        /// </summary>
        public const string UnhandledErrorCode = "UnhandledError";
        private readonly HttpContext _httpContext;
        private readonly Exception _exception;
        /// <summary>
        /// The log level associated with the error.
        /// </summary>
        public LogLevel LogLevel { get; set; }
        /// <summary>
        /// The code associated with the error.
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Gets or sets the unique identifier for the error.
        /// </summary>
        public string? TraceId
        {
            get
            {
                if (Extensions.TryGetValue("TraceId", out var traceId))
                    return (string?)traceId;

                return null;
            }

            set => Extensions["TraceId"] = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Error"/> class.
        /// </summary>
        /// <param name="httpContext">The HTTP context associated with the error.</param>
        /// <param name="exception">The exception that caused the error.</param>
        public Error(HttpContext httpContext, Exception exception)
        {
            _httpContext = httpContext;
            _exception = exception;

            TraceId = httpContext.TraceIdentifier;

            Code = UnhandledErrorCode;
            Status = (int)HttpStatusCode.InternalServerError;
            Title = "მოხდა შეცდომა სერვერზე";
            LogLevel = LogLevel.Error;
            Instance = httpContext.Request.Path;

            HandleException((dynamic)exception);
        }

        private void HandleException(InvalidCredentialsException exception)
        {
            Code = exception.Code;
            Status = (int)HttpStatusCode.BadRequest;
            Type = "https://datatracker.ietf.org/doc/html/rfc7235#section-3.1";
            Title = exception.Message;
            LogLevel = LogLevel.Information;
        }
        private void HandleException(LoginFailedException exception)
        {
            Code = exception.Code;
            Status = (int)HttpStatusCode.BadRequest;
            Type = "https://datatracker.ietf.org/doc/html/rfc7235#section-3.1";
            Title = exception.Message;
            LogLevel = LogLevel.Information;
        }
        private void HandleException(RegistrationFailedException exception)
        {
            Code = exception.Code;
            Status = (int)HttpStatusCode.BadRequest;
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1";
            Title = exception.Message;
            LogLevel = LogLevel.Information;
        }
        private void HandleException(UserNotFoundException exception)
        {
            Code = exception.Code;
            Status = (int)HttpStatusCode.BadRequest;
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4";
            Title = exception.Message;
            LogLevel = LogLevel.Information;
        }     
        private void HandleException(PageNotFoundException exception)
        {
            Code = exception.Code;
            Status = (int)HttpStatusCode.BadRequest;
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4";
            Title = exception.Message;
            LogLevel = LogLevel.Information;
        }

        private void HandleException(InvalidFormatException exception)
        {
            Code = exception.Code;
            Status = (int)HttpStatusCode.BadRequest;
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4";
            Title = exception.Message;
            LogLevel = LogLevel.Information;
        }
        private void HandleException(FailedUpdateException exception)
        {
            Code = exception.Code;
            Status = (int)HttpStatusCode.BadRequest;
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1";
            Title = exception.Message;
            LogLevel = LogLevel.Information;
        }      
        private void HandleException(FailedUserBlockedException exception)
        {
            Code = exception.Code;
            Status = (int)HttpStatusCode.BadRequest;
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1";
            Title = exception.Message;
            LogLevel = LogLevel.Information;
        }
        
        private void HandleException(EmailAlreadyExistsException exception)
        {
            Code = exception.Code;
            Status = (int)HttpStatusCode.BadRequest;
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1";
            Title = exception.Message;
            LogLevel = LogLevel.Information;
        }
        private void HandleException(UserNameAlreadyExistsException exception)
        {
            Code = exception.Code;
            Status = (int)HttpStatusCode.BadRequest;
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1";
            Title = exception.Message;
            LogLevel = LogLevel.Information;
        }
        private void HandleException(NotAllowedWriteTopicException exception)
        {
            Code = exception.Code;
            Status = (int)HttpStatusCode.BadRequest;
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.3";
            Title = exception.Message;
            LogLevel = LogLevel.Information;
        }
        private void HandleException(TopicNotFoundException exception)
        {
            Code = exception.Code;
            Status = (int)HttpStatusCode.BadRequest;
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4";
            Title = exception.Message;
            LogLevel = LogLevel.Information;
        }
        private void HandleException(UserIsBlockedException exception)
        {
            Code = exception.Code;
            Status = (int)HttpStatusCode.BadRequest;
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1";
            Title = exception.Message;
            LogLevel = LogLevel.Information;
        }
        private void HandleException(CommentNotFoundException exception)
        {
            Code = exception.Message;
            Status = (int)HttpStatusCode.BadRequest;
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4";
            Title = exception.Message;
            LogLevel = LogLevel.Information;
        }
        private void HandleException(AccessToDeleteCommentException exception)
        {
            Code = exception.Message;
            Status = (int)HttpStatusCode.BadRequest;
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.3";
            Title = exception.Message;
            LogLevel = LogLevel.Information;
        }
        private void HandleException(PhotoNotFoundException exception)
        {
            Code = exception.Message;
            Status = (int)HttpStatusCode.BadRequest;
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4";
            Title = exception.Message;
            LogLevel = LogLevel.Information;
        }
        private void HandleException(UserAlreadyIsBlockedException exception)
        {
            Code = exception.Message;
            Status = (int)HttpStatusCode.BadRequest;
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1";
            Title = exception.Message;
            LogLevel = LogLevel.Information;
        }
        private void HandleException(Exception exception)
        {
            Code = exception.Message;
            Status = (int)HttpStatusCode.BadRequest;
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4";
            Title = exception.Message;
            LogLevel = LogLevel.Information;
        }
    }
}
