using InventoryManagementSystem.Shared.ErrorModels;

namespace Inventory_Management_System.CustomMiddlewares
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CustomExceptionMiddleware> _logger;

        public CustomExceptionMiddleware(RequestDelegate next, ILogger<CustomExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeHttpAsync(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);

                if(context.Response.StatusCode == StatusCodes.Status404NotFound)
                {
                    var response = new ErrorToReturn()
                    {
                        StatusCode = context.Response.StatusCode,
                        Message = $"The Endpoint {context.Request.Path} you are looking for was not found."
                    };
                    await context.Response.WriteAsJsonAsync(response);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                #region Response Header

                //set the response status code and content type (response headers)
                context.Response.StatusCode = ex switch
                {
                    KeyNotFoundException => StatusCodes.Status404NotFound,
                    _ => StatusCodes.Status500InternalServerError
                };
                context.Response.ContentType = "application/json";
                #endregion
                #region Response Body
                var response = new ErrorToReturn()
                {
                    StatusCode = context.Response.StatusCode,
                    Message = ex.Message
                } ;
                await context.Response.WriteAsJsonAsync(response);
                #endregion

            }
        }
    }
}
