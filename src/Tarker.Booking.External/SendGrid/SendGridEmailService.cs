using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Text;
using Tarker.Booking.Application.External.SendGridEmail;
using Tarker.Booking.Domain.Models.SendGrid;

namespace Tarker.Booking.External.SendGrid
{
    public class SendGridEmailService : ISendGridEmailService
    {
        private readonly IConfiguration _configuration;
        /// <summary>
        /// Constructor DI.
        /// </summary>
        /// <param name="configuration"></param>
        public SendGridEmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        /// <summary>
        /// This method is used to email send with Twilio API.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<bool> Execute(SendGridRequestModel model)
        {
            string? apiKey = _configuration["TwilioSendGrid:Key"];
            string? apiUrl = _configuration["TwilioSendGrid:Url"];
            HttpClient client = new()
            {
                DefaultRequestHeaders =
                {
                    { "Authorization", $"Bearer {apiUrl}" },
                    { "Content-Type", "application/json" }
                }
            };
            string content = JsonConvert.SerializeObject(model);
            var response = await client.PostAsync(apiUrl, new StringContent(content, Encoding.UTF8, "application/json"));
            return response.IsSuccessStatusCode;
        }
    }
}
