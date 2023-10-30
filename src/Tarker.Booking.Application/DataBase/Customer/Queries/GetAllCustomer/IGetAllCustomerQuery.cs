namespace Tarker.Booking.Application.DataBase.Customer.Queries.GetAllCustomer
{
    public interface IGetAllCustomerQuery
    {
        /// <summary>
        /// This method is used to get all customer.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        Task<List<GetAllCustomerModel>> Execute();
    }
}
