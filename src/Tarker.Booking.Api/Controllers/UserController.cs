using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tarker.Booking.Application.DataBase.User.Commands.CreateUser;
using Tarker.Booking.Application.DataBase.User.Commands.DeleteUser;
using Tarker.Booking.Application.DataBase.User.Commands.UpdateUser;
using Tarker.Booking.Application.DataBase.User.Commands.UpdateUserPassword;
using Tarker.Booking.Application.DataBase.User.Queries.GetAllUser;
using Tarker.Booking.Application.DataBase.User.Queries.GetUserById;
using Tarker.Booking.Application.DataBase.User.Queries.GetUserByUserNameAndPassword;
using Tarker.Booking.Application.Exceptions;
using Tarker.Booking.Application.External.ApplicationInsights;
using Tarker.Booking.Application.External.Jwt;
using Tarker.Booking.Application.Features;
using Tarker.Booking.Common.Constants;
using Tarker.Booking.Domain.Models.ApplicationInsights;

namespace Tarker.Booking.Api.Controllers
{
    /// <summary>
    /// This controller is used to users.
    /// </summary>
    [Authorize]
    [Route("api/v1/user")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class UserController : ControllerBase
    {
        /// <summary>
        /// Service by Application Insights.
        /// </summary>
        public readonly IInsertApplicationInsightsService _insightsService;
        /// <summary>
        /// Constructor DI.
        /// </summary>
        public UserController(IInsertApplicationInsightsService insightsService)
        {
            _insightsService = insightsService;
        }

        /// <summary>
        /// This method is used to user create.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="command"></param>
        /// <param name="validator"></param>
        /// <returns></returns>
        [HttpPost("create")]
        public async Task<ActionResult> Create([FromBody]CreateUserModel model, [FromServices]ICreateUserCommand command, [FromServices]IValidator<CreateUserModel> validator)
        {
            FluentValidation.Results.ValidationResult validate = await validator.ValidateAsync(model);
            if (!validate.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, string.Empty, validate.Errors));

            CreateUserModel data = await command.Execute(model);
            return StatusCode(StatusCodes.Status201Created, ResponseApiService.Response(StatusCodes.Status201Created, string.Empty, data));
        }
        /// <summary>
        /// This method is used to user update.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="command"></param>
        /// <param name="validator"></param>
        /// <returns></returns>
        [HttpPut("update")]
        public async Task<ActionResult> Update([FromBody]UpdateUserModel model, [FromServices]IUpdateUserCommand command, [FromServices] IValidator<UpdateUserModel> validator)
        {
            FluentValidation.Results.ValidationResult validate = await validator.ValidateAsync(model);
            if (!validate.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, string.Empty, validate.Errors));

            UpdateUserModel data = await command.Execute(model);
            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, string.Empty, data));
        }
        /// <summary>
        /// This method is used to user update.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="command"></param>
        /// <param name="validator"></param>
        /// <returns></returns>
        [HttpPut("update_password")]
        public async Task<ActionResult> UpdatePassword([FromBody]UpdateUserPasswordModel model, [FromServices]IUpdateUserPasswordCommand command
            , [FromServices] IValidator<UpdateUserPasswordModel> validator)
        {
            FluentValidation.Results.ValidationResult validate = await validator.ValidateAsync(model);
            if (!validate.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, string.Empty, validate.Errors));

            bool data = await command.Execute(model);
            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, string.Empty, data));
        }
        /// <summary>
        /// This method is used to user delete.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpDelete("delete/{userId}")]
        public async Task<ActionResult> Delete([FromBody]string userId, [FromServices]IDeleteUserCommand command)
        {
            if(string.IsNullOrEmpty(userId))
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, string.Empty, null));

            bool data = await command.Execute(Guid.Parse(userId));
            if(data)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound, string.Empty, data));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, string.Empty, data));
        }
        /// <summary>
        /// This method is used to get all user.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("get_all")]
        public async Task<ActionResult> GetAll([FromServices]IGetAllUserQuery query)
        {
            _insightsService.Execute(new InsertApplicationInsightsModel(ApplicationInsightsConstants.METRYC_TYPE_API_CALL, EntitiesConstants.USER, "get_all"));
            List<GetAllUserModel> data = await query.Execute();
            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, string.Empty, data));
        }
        /// <summary>
        /// This method is used to get all user by user id.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("get_by_id/{userId}")]
        public async Task<ActionResult> GetById(string userId, [FromServices]IGetUserByIdQuery query)
        {
            _insightsService.Execute(new InsertApplicationInsightsModel(ApplicationInsightsConstants.METRYC_TYPE_API_CALL, EntitiesConstants.USER, "get_by_id"));
            if (string.IsNullOrEmpty(userId))
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, string.Empty, null));

            GetUserByIdModel data = await query.Execute(Guid.Parse(userId));
            if (data is null)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound, string.Empty, data));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, string.Empty, data));
        }
        /// <summary>
        /// This method is used to get all user by username and password.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="query"></param>
        /// <param name="validator"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("get_by_username_password/{userName}/{password}")]
        public async Task<ActionResult> GetByUserNamePassword(string userName, string password, [FromServices] IGetUserByUserNameAndPasswordQuery query
            , [FromServices] IValidator<(string, string)> validator, [FromServices] IGetTokenJwtService token)
        {
            int.Parse("asdasdas");
            _insightsService.Execute(new InsertApplicationInsightsModel(ApplicationInsightsConstants.METRYC_TYPE_API_CALL,EntitiesConstants.USER,"get_by_username_password"));
            FluentValidation.Results.ValidationResult validate = await validator.ValidateAsync((userName, password));
            if (!validate.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, string.Empty, validate.Errors));
            if (string.IsNullOrEmpty(userName))
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, string.Empty, null));

            GetUserByUserNameAndPasswordModel? data = await query.Execute(userName, password);
            if (data is null)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound, string.Empty, data));

            data.Token = token.Execute(data.UserId.ToString());

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, string.Empty, data));
        }
    }
}
