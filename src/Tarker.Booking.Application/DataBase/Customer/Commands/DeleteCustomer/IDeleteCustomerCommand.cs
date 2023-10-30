namespace Tarker.Booking.Application.DataBase.Customer.Commands.DeleteCustomer
{
    public interface IDeleteCustomerCommand
    {
        /// <summary>
        /// This method is used to delete customer.
        /// </summary>
        /// <param name="CustomerId"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        Task<bool> Execute(Guid CustomerId);
    }
}
