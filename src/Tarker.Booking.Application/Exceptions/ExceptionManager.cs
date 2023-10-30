using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System.Net;
using Tarker.Booking.Application.External.ApplicationInsights;
using Tarker.Booking.Application.Features;
using Tarker.Booking.Common.Constants;
using Tarker.Booking.Domain.Models;
using Tarker.Booking.Domain.Models.ApplicationInsights;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Tarker.Booking.Application.Exceptions
{
    public class ExceptionManager : IExceptionFilter
    {
        public readonly IInsertApplicationInsightsService _insightsService;
        /// <summary>
        /// Constructor DI.
        /// </summary>
        /// <param name="insightsService"></param>
        public ExceptionManager(IInsertApplicationInsightsService insightsService)
        {
            _insightsService = insightsService;
        }
        /// <summary>
        /// This method is used to exceptions.
        /// </summary>
        /// <param name="context"></param>
        public void OnException(ExceptionContext context)
        {
            BaseResponseModel result = ResponseApiService.Response((int)HttpStatusCode.InternalServerError, context.Exception.Message, null);
            context.HttpContext.Response.StatusCode = result.StatusCode;
            context.Result = new JsonResult(new
            {
                result.Message,
                result.Success,
                result.StatusCode,
                result.Data
            });
            _insightsService.Execute(
                new InsertApplicationInsightsModel(ApplicationInsightsConstants.METRYC_TYPE_ERROR, context.Exception.Message, context.Exception.ToString()));
        }
    }
}
