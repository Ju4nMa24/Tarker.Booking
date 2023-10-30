using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Tarker.Booking.Application.DataBase.Booking.Queries.GetAllBooking
{
    public class GetAllBookingQuery : IGetAllBookingQuery
    {
        private readonly IDataBaseService _db;
        private readonly IMapper _mapper;
        /// <summary>
        /// Constructor DI.
        /// </summary>
        /// <param name="db"></param>
        public GetAllBookingQuery(IDataBaseService db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        /// <summary>
        /// This method is used to get all bookings.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task<List<GetAllBookingModel>> Execute()
        {
            try
            {
                return await (from booking in _db.Booking
                                    join customer in _db.Customer
                                    on booking.CustomerId equals customer.CustomerId
                                    select new GetAllBookingModel
                                    {
                                        BookingId = booking.BookingId,
                                        Code = booking.Code,
                                        RegisterDate = booking.RegisterDate,
                                        Type = booking.Type,
                                        CustomerFullName = customer.FullName,
                                        CustomerDocumentNumber = customer.DocumentNumber
                                    }).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex?.Message);
            }
        }
    }
}
