namespace Tarker.Booking.Application.DataBase.User.Commands.UpdateUser
{
    public interface IUpdateUserCommand
    {
        /// <summary>
        /// This method is used to update user.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        Task<UpdateUserModel> Execute(UpdateUserModel model);
    }
}
