namespace Tarker.Booking.Application.DataBase.User.Commands.DeleteUser
{
    public interface IDeleteUserCommand
    {
        /// <summary>
        /// This method is used to delete user.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<bool> Execute(Guid userId);
    }
}
