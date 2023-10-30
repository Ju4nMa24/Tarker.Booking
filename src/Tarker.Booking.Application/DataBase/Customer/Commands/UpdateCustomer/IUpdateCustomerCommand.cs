namespace Tarker.Booking.Application.DataBase.Customer.Commands.UpdateCustomer
{
    public interface IUpdateCustomerCommand
    {
        /// <summary>
        /// This method is used to update customer.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        Task<UpdateCustomerModel> Execute(UpdateCustomerModel model);
    }
}
