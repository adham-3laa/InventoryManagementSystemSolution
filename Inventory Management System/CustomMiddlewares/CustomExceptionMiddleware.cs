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
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                #region Response Header

                //set the response status code and content type (response headers)
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
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
