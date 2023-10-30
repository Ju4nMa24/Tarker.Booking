namespace Tarker.Booking.Application.DataBase.User.Queries.GetUserById
{
    public interface IGetUserByIdQuery
    {
        /// <summary>
        /// This method is used to get user by id.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        Task<GetUserByIdModel> Execute(Guid userId);
    }
}
