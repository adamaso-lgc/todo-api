using System.Net;
using System.Text.Json;
using Todo.Application.Exceptions;

namespace Todo.Api.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                //var responseModel = new Response<string>() { Succeeded = false, Message = error?.Message };
                var responseModel = string.Empty; 


                switch (error)
                {
                    case NotFoundException e:
                        // not found error 
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        responseModel = e.Message;
                        break;
                    case ValidationException e:
                        // custom application error
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        responseModel = JsonSerializer.Serialize(e.Errors);
                        break;
                    case ApplicationException e:
                        // custom application error
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        responseModel = e.Message;
                        break;
                    default:
                        // unhandled error
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }
                //var result = JsonSerializer.Serialize(responseModel);
                if (responseModel == string.Empty)
                    responseModel = JsonSerializer.Serialize(new { error = error.Message });

                await response.WriteAsync(responseModel);
            }
        }
    }
}
