namespace Tarker.Booking.Application.DataBase.User.Commands.CreateUser
{
    public interface ICreateUserCommand
    {
        /// <summary>
        /// This method is used to create user.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        Task<CreateUserModel> Execute(CreateUserModel model);
    }
}
