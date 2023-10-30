namespace Tarker.Booking.Application.DataBase.Customer.Commands.UpdateCustomer
{
    public class UpdateCustomerModel
    {
        public Guid CustomerId { get; set; }
        public required string FullName { get; set; }
        public required string DocumentNumber { get; set; }
    }
}
