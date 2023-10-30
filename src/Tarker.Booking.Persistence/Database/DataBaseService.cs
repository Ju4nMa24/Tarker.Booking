using Microsoft.EntityFrameworkCore;
using Tarker.Booking.Application.DataBase;
using Tarker.Booking.Domain.Entities.Booking;
using Tarker.Booking.Domain.Entities.Customer;
using Tarker.Booking.Domain.Entities.User;
using Tarker.Booking.Persistence.Configuration;

namespace Tarker.Booking.Persistence.Database
{
    public class DataBaseService : DbContext, IDataBaseService
    {
        public DataBaseService(DbContextOptions options): base(options)
        {

        }
        public DbSet<UserEntity> User { get; set; }
        public DbSet<CustomerEntity> Customer { get; set; }
        public DbSet<BookingEntity> Booking { get; set; }
        /// <summary>
        /// This method is used to save in the database.
        /// </summary>
        /// <returns></returns>
        public async Task<bool> SaveAsync() => await SaveChangesAsync() > 0;
        /// <summary>
        /// On Model Creatin from Database.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            EntityConfiguration(modelBuilder);
        }
        /// <summary>
        /// This method is used to entities configuration.
        /// </summary>
        /// <param name="modelBuilder"></param>
        private static void EntityConfiguration(ModelBuilder modelBuilder)
        {
            _ = new UserConfiguration(modelBuilder.Entity<UserEntity>());
            _ = new CustomerConfiguration(modelBuilder.Entity<CustomerEntity>());
            _ = new BookingConfiguration(modelBuilder.Entity<BookingEntity>());
        }

    }
}
