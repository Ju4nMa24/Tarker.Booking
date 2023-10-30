using Microsoft.AspNetCore.Mvc;
using Tarker.Booking.Application.Exceptions;
using Tarker.Booking.Application.External.SendGridEmail;
using Tarker.Booking.Application.Features;
using Tarker.Booking.Domain.Models.SendGrid;

namespace Tarker.Booking.Api.Controllers
{
    /// <summary>
    /// This controller is used to notification by twilio API.
    /// </summary>
    [Route("api/v1/notification")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class NotificationController : ControllerBase
    {
        /// <summary>
        /// This method is used to email send with Twilio API.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="service"></param>
        /// <returns></returns>
        [HttpPost("create")]
        public async Task<ActionResult> Create([FromBody]SendGridRequestModel model, [FromServices]ISendGridEmailService service)
        {
            bool data = await service.Execute(model);
            if(data)
                return StatusCode(StatusCodes.Status500InternalServerError, ResponseApiService.Response(StatusCodes.Status500InternalServerError, string.Empty, data));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status201Created, string.Empty, data));
        }
    }
}
