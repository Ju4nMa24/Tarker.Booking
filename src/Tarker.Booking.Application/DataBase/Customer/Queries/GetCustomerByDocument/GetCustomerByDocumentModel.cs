namespace Tarker.Booking.Application.DataBase.Customer.Queries.GetCustomerByDocument
{
    public class GetCustomerByDocumentModel
    {
        public Guid CustomerId { get; set; }
        public required string FullName { get; set; }
        public required string DocumentNumber { get; set; }
    }
}
