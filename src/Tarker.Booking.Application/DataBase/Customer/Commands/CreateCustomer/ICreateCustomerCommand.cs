namespace Tarker.Booking.Application.DataBase.Customer.Commands.CreateCustomer
{
    public interface ICreateCustomerCommand
    {
        /// <summary>
        /// This method is used to create customer.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        Task<CreateCustomerModel> Execute(CreateCustomerModel model);
    }
}
