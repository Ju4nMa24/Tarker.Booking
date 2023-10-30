namespace Tarker.Booking.Application.DataBase.Customer.Queries.GetCustomerById
{
    public class GetCustomerByIdModel
    {
        public Guid CustomerId { get; set; }
        public required string FullName { get; set; }
        public required string DocumentNumber { get; set; }
    }
}
