using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tarker.Booking.Domain.Entities.Booking;

namespace Tarker.Booking.Persistence.Configuration
{
    public class BookingConfiguration
    {
        /// <summary>
        /// This method is used to Booking configuration builder.
        /// </summary>
        /// <param name="entityBuilder"></param>
        public BookingConfiguration(EntityTypeBuilder<BookingEntity> entityBuilder)
        {
            entityBuilder.HasKey(x => x.BookingId);
            entityBuilder.Property(x => x.BookingId).HasDefaultValue(Guid.NewGuid());
            entityBuilder.Property(x => x.RegisterDate).IsRequired();
            entityBuilder.Property(x => x.Code).IsRequired();
            entityBuilder.Property(x => x.Type).IsRequired();
            entityBuilder.Property(x => x.UserId).IsRequired();
            entityBuilder.Property(x => x.CustomerId).IsRequired();
            entityBuilder.HasOne(x => x.User).WithMany(x => x.Bookings).HasForeignKey(x => x.UserId);
            entityBuilder.HasOne(x => x.Customer).WithMany(x => x.Bookings).HasForeignKey(x => x.CustomerId);
        }
    }
}
