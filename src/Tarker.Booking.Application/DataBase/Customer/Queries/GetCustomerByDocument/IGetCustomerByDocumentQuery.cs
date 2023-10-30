namespace Tarker.Booking.Application.DataBase.Customer.Queries.GetCustomerByDocument
{
    public interface IGetCustomerByDocumentQuery
    {
        /// <summary>
        /// This method is used to get customer by document number.
        /// </summary>
        /// <param name="documentNumber"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        Task<GetCustomerByDocumentModel> Execute(string documentNumber);
    }
}
