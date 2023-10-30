using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Tarker.Booking.Application.DataBase.Booking.Commands.CreateBooking;
using Tarker.Booking.Application.DataBase.Booking.Queries.GetAllBooking;
using Tarker.Booking.Application.DataBase.Booking.Queries.GetBookingByDocument;
using Tarker.Booking.Application.DataBase.Booking.Queries.GetBookingByType;
using Tarker.Booking.Application.Exceptions;
using Tarker.Booking.Application.Features;

namespace Tarker.Booking.Api.Controllers
{
    /// <summary>
    /// This controller is used to booking.
    /// </summary>
    [Route("api/v1/booking")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class BookingController : ControllerBase
    {
        /// <summary>
        /// This method is used to booking create.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="command"></param>
        /// <param name="validator"></param>
        /// <returns></returns>
        [HttpPost("create")]
        public async Task<ActionResult> Create([FromBody]CreateBookingModel model, [FromServices]ICreateBookingCommand command, [FromServices] IValidator<CreateBookingModel> validator)
        {
            FluentValidation.Results.ValidationResult validate = await validator.ValidateAsync(model);
            if (!validate.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, string.Empty, validate.Errors));

            CreateBookingModel data = await command.Execute(model);
            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status201Created, string.Empty, data));
        }
        /// <summary>
        /// This method is used to get all booking.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("get_all")]
        public async Task<ActionResult> GetAll([FromServices]IGetAllBookingQuery query)
        {
            List<GetAllBookingModel> data = await query.Execute();
            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, string.Empty, data));
        }
        /// <summary>
        /// This method is used to get all booking by document number.
        /// </summary>
        /// <param name="documentNumber"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("get_by_document/{documentNumber}")]
        public async Task<ActionResult> GetBookingByDocument(string documentNumber, [FromServices]IGetBookingByDocumentQuery query)
        {
            if (string.IsNullOrEmpty(documentNumber))
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, string.Empty, null));

            List<GetBookingByDocumentModel>? data = await query.Execute(documentNumber);
            if (data is null)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound, string.Empty, data));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, string.Empty, data));
        }
        /// <summary>
        /// This method is used to get all booking by type.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("get_by_type")]
        public async Task<ActionResult> GetBookingByDocument([FromBody]string type, [FromServices]IGetBookingByTypeQuery query)
        {
            if (string.IsNullOrEmpty(type))
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, string.Empty, null));

            List<GetBookingByTypeModel>? data = await query.Execute(type);
            if (data is null)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound, string.Empty, data));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, string.Empty, data));
        }
    }
}
