namespace Tarker.Booking.Application.DataBase.User.Commands.UpdateUserPassword
{
    public interface IUpdateUserPasswordCommand
    {
        /// <summary>
        /// This method is used to update user password.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        Task<bool> Execute(UpdateUserPasswordModel model);
    }
}
