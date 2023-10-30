using Microsoft.EntityFrameworkCore;
using Tarker.Booking.Domain.Entities.User;

namespace Tarker.Booking.Application.DataBase.User.Commands.DeleteUser
{
    public class DeleteUserCommand : IDeleteUserCommand
    {
        private readonly IDataBaseService _db;
        /// <summary>
        /// Constructor to DI.
        /// </summary>
        /// <param name="db"></param>
        /// <param name="mapper"></param>
        public DeleteUserCommand(IDataBaseService db)
        {
            _db = db;
        }
        /// <summary>
        /// This method is used to delete user.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<bool> Execute(Guid userId)
        {
            try
            {
                UserEntity? user = await _db.User.FirstOrDefaultAsync(u => u.UserId == userId);
                if (user is null)
                    return false;

                _db.User.Remove(user);
                return await _db.SaveAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex?.Message);
            }
        }
    }
}
