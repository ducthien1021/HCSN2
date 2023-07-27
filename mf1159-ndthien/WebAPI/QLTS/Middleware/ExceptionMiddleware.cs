using QLTS.Domain;
using QLTS.Domain.Resource;

namespace QLTS.API.Middleware
{
    public class ExceptionMiddleware
    {
        #region Fields
        private readonly RequestDelegate _next; 
        #endregion

        #region Contructor
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        #endregion


        #region Methods
        /// <summary>
        /// Bắt exception tại middleware
        /// </summary>
        /// <param name="context">HttpContext đi qua middleware</param>
        /// <returns></returns>
        /// Author: NDThien 19/07/2023
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(context, exception);
            }
        }

        /// <summary>
        /// Bắt các exception khi chạy qua middleware
        /// </summary>
        /// <param name="context">HttpContext đang được chạy qua middleware</param>
        /// <param name="exception">Exception trong khi chạy qua middleware</param>
        /// <returns></returns>
        /// Author: NDThien 19/07/2023
        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            Console.WriteLine(exception);
            context.Response.ContentType = "application/json";
            if (exception is NotFoundException)
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                await context.Response.WriteAsync(text: new BaseException()
                {
                    ErrorCode = ((NotFoundException)exception).ErrorCode,
                    UserMessage = ResourceVN.MISAError,
                    DevMessage = exception.Message,
                    TraceId = context.TraceIdentifier,
                    MoreInfo = exception.HelpLink
                }.ToString() ?? "");
            }
            else if (exception is ConflictException)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsync(text: new BaseException()
                {
                    ErrorCode = ((ConflictException)exception).ErrorCode,
                    UserMessage = exception.Message,
                    DevMessage = exception.Message,
                    TraceId = context.TraceIdentifier,
                    MoreInfo = exception.HelpLink
                }.ToString() ?? "");
            }
            else
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsync(text: new BaseException()
                {
                    ErrorCode = context.Response.StatusCode,
                    UserMessage = ResourceVN.MISAError,
                    DevMessage = exception.Message,
                    TraceId = context.TraceIdentifier,
                    MoreInfo = exception.HelpLink
                }.ToString() ?? "");
            }
        } 
        #endregion
    }
}
