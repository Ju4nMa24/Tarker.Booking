using Tarker.Booking.Domain.Models.SendGrid;

namespace Tarker.Booking.Application.External.SendGridEmail
{
    public interface ISendGridEmailService
    {
        /// <summary>
        /// This method is used to email send with Twilio API.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<bool> Execute(SendGridRequestModel model);
    }
}
