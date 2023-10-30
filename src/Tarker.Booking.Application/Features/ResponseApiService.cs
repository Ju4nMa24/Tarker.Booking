using Tarker.Booking.Domain.Models;

namespace Tarker.Booking.Application.Features
{
    public static class ResponseApiService
    {
        public static BaseResponseModel Response(int statusCode, string message = "", object? data = null)
        {
			try
			{
				bool success = false;
				if (statusCode >= 200 && statusCode < 300)
					success = true;

				return new BaseResponseModel()
                {
                    Message = message,
                    Success = success,
                    StatusCode = statusCode,
                    Data = data
                };
            }
			catch (Exception)
			{

				throw;
			}
        }
    }
}
