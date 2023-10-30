using Microsoft.EntityFrameworkCore;
using Tarker.Booking.Domain.Entities.User;

namespace Tarker.Booking.Application.DataBase.User.Commands.UpdateUserPassword
{
    public class UpdateUserPasswordCommand : IUpdateUserPasswordCommand
    {
        private readonly IDataBaseService _db;
        /// <summary>
        /// Constructor to DI.
        /// </summary>
        /// <param name="db"></param>
        public UpdateUserPasswordCommand(IDataBaseService db)
        {
            _db = db;
        }
        /// <summary>
        /// This method is used to update user password.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task<bool> Execute(UpdateUserPasswordModel model)
        {
            try
            {
                UserEntity? user = await _db.User.FirstOrDefaultAsync(u => u.UserId == model.UserId);
                if (user is null)
                    return false;

                user.Password = (string.IsNullOrEmpty(model.Password)) ? user.Password : model.Password;
                return await _db.SaveAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex?.Message);
            }
        }
    }
}
