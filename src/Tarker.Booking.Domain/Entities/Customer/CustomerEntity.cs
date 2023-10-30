using System.ComponentModel.DataAnnotations;
using Tarker.Booking.Domain.Entities.Booking;

namespace Tarker.Booking.Domain.Entities.Customer
{
    public class CustomerEntity
    {
        [Key]
        public Guid CustomerId { get; set; }
        public required string FullName { get; set; }
        public required string DocumentNumber { get; set; }
        public ICollection<BookingEntity>? Bookings { get; set; }

    }
}
