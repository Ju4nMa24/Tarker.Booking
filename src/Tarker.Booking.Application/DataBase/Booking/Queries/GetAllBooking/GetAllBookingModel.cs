namespace Tarker.Booking.Application.DataBase.Booking.Queries.GetAllBooking
{
    public class GetAllBookingModel
    {
        public Guid BookingId { get; set; }
        public DateTime RegisterDate { get; set; }
        public required string Code { get; set; }
        public required string Type { get; set; }
        public required string CustomerFullName { get; set; }
        public required string CustomerDocumentNumber { get; set; }
    }
}
