namespace Tarker.Booking.Application.DataBase.User.Queries.GetAllUser
{
    public interface IGetAllUserQuery
    {
        /// <summary>
        /// This method is used to get all users.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        Task<List<GetAllUserModel>> Execute();
    }
}
