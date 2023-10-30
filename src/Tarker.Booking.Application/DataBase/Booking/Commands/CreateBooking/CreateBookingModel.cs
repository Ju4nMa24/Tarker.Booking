namespace Tarker.Booking.Application.DataBase.Booking.Commands.CreateBooking
{
    public class CreateBookingModel
    {
        public DateTime RegisterDate { get; set; }
        public required string Code { get; set; }
        public required string Type { get; set; }
        public Guid CustomerId { get; set; }
        public Guid UserId { get; set; }
    }
}
