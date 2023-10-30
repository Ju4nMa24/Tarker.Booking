namespace Tarker.Booking.Application.DataBase.Booking.Commands.CreateBooking
{
    public interface ICreateBookingCommand
    {
        /// <summary>
        /// This method is used to create booking.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        Task<CreateBookingModel> Execute(CreateBookingModel model);
    }
}
