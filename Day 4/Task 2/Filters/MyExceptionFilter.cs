using Microsoft.AspNetCore.Mvc.Filters;
using log4net;
using Microsoft.AspNetCore.Mvc;
namespace WebApplication5.Filters
{
    public class MyExceptionFilter : IExceptionFilter
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(MyExceptionFilter));
        public void OnException(ExceptionContext context)
        {
            _logger.Error(context.Exception.Message);
            context.ExceptionHandled = true;

            context.Result = new ViewResult() { ViewName = "CustomError" };
        }
    }
}
