using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Tarker.Booking.Application.DataBase.Booking.Queries.GetBookingByType
{
    public class GetBookingByTypeQuery : IGetBookingByTypeQuery
    {
        private readonly IDataBaseService _db;
        private readonly IMapper _mapper;
        /// <summary>
        /// Constructor DI.
        /// </summary>
        /// <param name="db"></param>
        /// <param name="mapper"></param>
        public GetBookingByTypeQuery(IDataBaseService db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        /// <summary>
        /// This method is used to get booking by type.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task<List<GetBookingByTypeModel>> Execute(string type)
        {
            try
            {
                return await (from booking in _db.Booking
                              join customer in _db.Customer
                              on booking.CustomerId equals customer.CustomerId
                              where booking.Type == type
                              select new GetBookingByTypeModel
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
