namespace Tarker.Booking.Application.DataBase.Customer.Commands.CreateCustomer
{
    public class CreateCustomerModel
    {
        public required string FullName { get; set; }
        public required string DocumentNumber { get; set; }
    }
}
