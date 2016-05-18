using System;
using Microsoft.AspNetCore.Mvc.Filters;
using DotNetCore.Infra.UnitOfWork;

namespace DotNetCore.Api.Helpers
{
    [AttributeUsage(AttributeTargets.Method)]
    public class Transaction : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var unitOfWork = (IUnitOfWork) context.HttpContext.RequestServices.GetService(typeof (IUnitOfWork));
            if (context.Exception == null)
            {
                unitOfWork.Commit();
            }
            else
            {
                unitOfWork.Rollback();
            }
        }
    }
}