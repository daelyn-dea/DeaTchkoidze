//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Http;
//using System.Threading.Tasks;

//namespace PizzaProject.API.Middlewares
//{
//    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
//    public class RequestResponseLogginMiddleware
//    {
//        private readonly RequestDelegate _next;

//        public RequestResponseLogginMiddleware(RequestDelegate next)
//        {
//            _next = next;
//        }

//        public async Task Invoke(HttpContext context)
//        {
//            await LogRequest(context.Request);

//            await context.Response.WriteAsync("\n app RequestResponseLoggin middleware  invoke");

//            await _next(context);
//        }

//        private async Task LogRequest(HttpRequest request)
//        {
//            var toLog = $"{Environment.NewLine}Logged from MIddleware {Environment.NewLine}" +
//            $"IP = {request.HttpContext.Connection.RemoteIpAddress}{Environment.NewLine}" +
//            $"Address = {request.Scheme}{Environment.NewLine}" +
//            $"Method = {request.Method}{Environment.NewLine}" +
//            $"Path = {request.Path}{Environment.NewLine}" +
//            $"IsSescured = {request.IsHttps}{Environment.NewLine}" +
//            $"QueryString = {request.QueryString}{Environment.NewLine}" +
//            $"Time = {DateTime.Now}{Environment.NewLine}";

//            await File.AppendAllTextAsync("Request.txt", toLog);
//        }
//    }
//}
