using Tarker.Booking.Domain.Enums.Jwt;

namespace Tarker.Booking.Application.External.Jwt
{
    public interface IGetTokenJwtService
    {
        /// <summary>
        /// This method is used to jwt generate.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        string Execute(string id);
    }
}
