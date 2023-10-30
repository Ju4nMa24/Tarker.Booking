namespace Tarker.Booking.Application.DataBase.Booking.Queries.GetBookingByDocument
{
    public interface IGetBookingByDocumentQuery
    {
        /// <summary>
        /// This method is used to get booking by document number.
        /// </summary>
        /// <param name="documentNumber"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        Task<List<GetBookingByDocumentModel>> Execute(string documentNumber);
    }
}
