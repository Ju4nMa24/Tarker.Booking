namespace Tarker.Booking.Application.DataBase.Customer.Queries.GetCustomerById
{
    public interface IGetCustomerByIdQuery
    {
        /// <summary>
        /// This method is used to get customer by id.
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        Task<GetCustomerByIdModel> Execute(Guid customerId);
    }
}
