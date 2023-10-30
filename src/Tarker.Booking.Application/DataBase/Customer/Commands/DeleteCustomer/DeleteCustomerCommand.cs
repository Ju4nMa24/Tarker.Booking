using Microsoft.EntityFrameworkCore;
using Tarker.Booking.Domain.Entities.Customer;

namespace Tarker.Booking.Application.DataBase.Customer.Commands.DeleteCustomer
{
    public class DeleteCustomerCommand : IDeleteCustomerCommand
    {
        private readonly IDataBaseService _db;
        /// <summary>
        /// Constructor to DI.
        /// </summary>
        /// <param name="db"></param>
        public DeleteCustomerCommand(IDataBaseService db)
        {
            _db = db;
        }
        /// <summary>
        /// This method is used to delete customer.
        /// </summary>
        /// <param name="CustomerId"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task<bool> Execute(Guid CustomerId)
        {
            try
            {
                CustomerEntity? customer = await _db.Customer.FirstOrDefaultAsync(u => u.CustomerId == CustomerId);
                if (customer is null)
                    return false;

                _db.Customer.Remove(customer);
                return await _db.SaveAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex?.Message);
            }
        }
    }
}
