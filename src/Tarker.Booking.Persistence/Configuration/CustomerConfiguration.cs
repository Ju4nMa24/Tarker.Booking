using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tarker.Booking.Domain.Entities.Customer;

namespace Tarker.Booking.Persistence.Configuration
{
    public class CustomerConfiguration
    {
        /// <summary>
        /// This method is used to customer configuration builder.
        /// </summary>
        /// <param name="entityBuilder"></param>
        public CustomerConfiguration(EntityTypeBuilder<CustomerEntity> entityBuilder)
        {
            entityBuilder.HasKey(x => x.CustomerId);
            entityBuilder.Property(x => x.CustomerId).HasDefaultValue(Guid.NewGuid());
            entityBuilder.Property(x => x.FullName).IsRequired();
            entityBuilder.Property(x => x.DocumentNumber).IsRequired();
            entityBuilder.HasMany(x => x.Bookings).WithOne(x => x.Customer).HasForeignKey(x => x.CustomerId);
        }
    }
}
