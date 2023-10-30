using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Tarker.Booking.Application.DataBase.Customer.Commands.CreateCustomer;
using Tarker.Booking.Application.DataBase.Customer.Commands.DeleteCustomer;
using Tarker.Booking.Application.DataBase.Customer.Commands.UpdateCustomer;
using Tarker.Booking.Application.DataBase.Customer.Queries.GetAllCustomer;
using Tarker.Booking.Application.DataBase.Customer.Queries.GetCustomerByDocument;
using Tarker.Booking.Application.DataBase.Customer.Queries.GetCustomerById;
using Tarker.Booking.Application.Exceptions;
using Tarker.Booking.Application.Features;

namespace Tarker.Booking.Api.Controllers
{
    /// <summary>
    /// This controller is used to customers.
    /// </summary>
    [Route("api/v1/customer")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class CustomerController : ControllerBase
    {
        /// <summary>
        /// This method is used to customer create.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="command"></param>
        /// <param name="validator"></param>
        /// <returns></returns>
        [HttpPost("create")]
        public async Task<ActionResult> Create([FromBody]CreateCustomerModel model, [FromServices]ICreateCustomerCommand command, [FromServices] IValidator<CreateCustomerModel> validator)
        {
            FluentValidation.Results.ValidationResult validate = await validator.ValidateAsync(model);
            if (!validate.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, string.Empty, validate.Errors));

            CreateCustomerModel data = await command.Execute(model);
            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status201Created, string.Empty, data));
        }
        /// <summary>
        /// This method is used to customer update.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="command"></param>
        /// <param name="validator"></param>
        /// <returns></returns>
        [HttpPut("update")]
        public async Task<ActionResult> Update([FromBody]UpdateCustomerModel model, [FromServices]IUpdateCustomerCommand command, [FromServices] IValidator<UpdateCustomerModel> validator)
        {
            FluentValidation.Results.ValidationResult validate = await validator.ValidateAsync(model);
            if (!validate.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, string.Empty, validate.Errors));

            UpdateCustomerModel data = await command.Execute(model);
            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, string.Empty, data));
        }
        /// <summary>
        /// This method is used to customer delete.
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpDelete("delete/{customerId}")]
        public async Task<ActionResult> Delete([FromBody]string customerId, [FromServices]IDeleteCustomerCommand command)
        {
            if (string.IsNullOrEmpty(customerId))
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, string.Empty, null));

            bool data = await command.Execute(Guid.Parse(customerId));
            if (data)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound, string.Empty, data));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, string.Empty, data));
        }
        /// <summary>
        /// This method is used to get all customer.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("get_all")]
        public async Task<ActionResult> GetAll([FromServices]IGetAllCustomerQuery query)
        {
            List<GetAllCustomerModel> data = await query.Execute();
            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, string.Empty, data));
        }
        /// <summary>
        /// This method is used to get all customer by customer id.
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("get_by_id/{customerId}")]
        public async Task<ActionResult> GetById(string customerId, [FromServices]IGetCustomerByIdQuery query)
        {
            if (string.IsNullOrEmpty(customerId))
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, string.Empty, null));

            GetCustomerByIdModel data = await query.Execute(Guid.Parse(customerId));
            if (data is null)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound, string.Empty, data));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, string.Empty, data));
        }
        /// <summary>
        /// This method is used to get all customer by document.
        /// </summary>
        /// <param name="documentNumber"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("get_by_document/{documentNumber}")]
        public async Task<ActionResult> GetCustomerByDocument(string documentNumber, [FromServices]IGetCustomerByDocumentQuery query)
        {
            if (string.IsNullOrEmpty(documentNumber))
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, string.Empty, null));

            GetCustomerByDocumentModel? data = await query.Execute(documentNumber);
            if (data is null)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound, string.Empty, data));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, string.Empty, data));
        }
    }
}
