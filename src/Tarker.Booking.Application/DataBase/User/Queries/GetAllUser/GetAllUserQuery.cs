using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Tarker.Booking.Domain.Entities.User;

namespace Tarker.Booking.Application.DataBase.User.Queries.GetAllUser
{
    public class GetAllUserQuery : IGetAllUserQuery
    {
        private readonly IDataBaseService _db;
        private readonly IMapper _mapper;
        /// <summary>
        /// Constructor DI.
        /// </summary>
        /// <param name="db"></param>
        /// <param name="mapper"></param>
        public GetAllUserQuery(IDataBaseService db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        /// <summary>
        /// This method is used to get all users.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task<List<GetAllUserModel>> Execute()
        {
            try
            {
                List<UserEntity> listUser = await _db.User.ToListAsync();
                return _mapper.Map<List<GetAllUserModel>>(listUser);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex?.Message);
            }
        }
    }
}
