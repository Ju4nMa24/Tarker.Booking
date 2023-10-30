using System.ComponentModel.DataAnnotations;
using Tarker.Booking.Domain.Entities.Customer;
using Tarker.Booking.Domain.Entities.User;

namespace Tarker.Booking.Domain.Entities.Booking
{
    public class BookingEntity
    {
        [Key]
        public Guid BookingId { get; set; }
        public DateTime RegisterDate { get; set; }
        public required string Code { get; set; }
        public required string Type { get; set; }
        public Guid CustomerId { get; set; }
        public Guid UserId { get; set; }
        public UserEntity? User { get; set; }
        public CustomerEntity? Customer { get; set; }
    }
}
