using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.Extensions.Configuration;
using Tarker.Booking.Application.External.ApplicationInsights;
using Tarker.Booking.Domain.Models.ApplicationInsights;

namespace Tarker.Booking.External.ApplicationInsights
{
    public class InsertApplicationInsightsService : IInsertApplicationInsightsService
    {
        private readonly IConfiguration _configuration;
        /// <summary>
        /// Constructor DI.
        /// </summary>
        /// <param name="configuration"></param>
        public InsertApplicationInsightsService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        /// <summary>
        /// This method is used to metrict custom.
        /// </summary>
        /// <param name="metrict"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public bool Execute(InsertApplicationInsightsModel metrict)
        {
            if (metrict is not null)
            {
                TelemetryConfiguration config = new()
                {
                    ConnectionString = _configuration["ApplicationInsightsConnectionString"]
                };
                TelemetryClient _telemetryClient = new(config);
                _telemetryClient.TrackTrace(metrict.Type, SeverityLevel.Information, new Dictionary<string, string>
                {
                    { "Id", metrict.Id ?? string.Empty},
                    {"Content", metrict.Content  ?? string.Empty},
                    {"Detail", metrict.Detail  ?? string.Empty}
                });
                return true;
            }

            throw new ArgumentNullException(nameof(metrict));
        }
    }
}
