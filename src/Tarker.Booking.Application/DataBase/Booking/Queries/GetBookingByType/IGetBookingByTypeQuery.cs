namespace Tarker.Booking.Application.DataBase.Booking.Queries.GetBookingByType
{
    public interface IGetBookingByTypeQuery
    {
        /// <summary>
        /// This method is used to get booking by type.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        Task<List<GetBookingByTypeModel>> Execute(string type);
    }
}
