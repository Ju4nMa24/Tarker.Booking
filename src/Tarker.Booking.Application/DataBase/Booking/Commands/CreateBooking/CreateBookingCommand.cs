using AutoMapper;
using Tarker.Booking.Domain.Entities.Booking;

namespace Tarker.Booking.Application.DataBase.Booking.Commands.CreateBooking
{
    public class CreateBookingCommand : ICreateBookingCommand
    {
        private readonly IDataBaseService _db;
        private readonly IMapper _mapper;
        /// <summary>
        /// Constructor DI.
        /// </summary>
        /// <param name="db"></param>
        /// <param name="mapper"></param>
        public CreateBookingCommand(IDataBaseService db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        /// <summary>
        /// This method is used to create booking.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task<CreateBookingModel> Execute(CreateBookingModel model)
        {
            try
            {
                await _db.Booking.AddAsync(_mapper.Map<BookingEntity>(model));
                await _db.SaveAsync();
                return model;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex?.Message);
            }
        }
    }
}
