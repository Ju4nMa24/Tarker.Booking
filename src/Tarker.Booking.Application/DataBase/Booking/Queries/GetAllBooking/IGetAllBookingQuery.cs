namespace Tarker.Booking.Application.DataBase.Booking.Queries.GetAllBooking
{
    public interface IGetAllBookingQuery
    {
        /// <summary>
        /// This method is used to get all bookings.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        Task<List<GetAllBookingModel>> Execute();
    }
}
