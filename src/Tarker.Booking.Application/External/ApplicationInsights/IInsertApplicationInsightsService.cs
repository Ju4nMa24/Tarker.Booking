using Tarker.Booking.Domain.Models.ApplicationInsights;

namespace Tarker.Booking.Application.External.ApplicationInsights
{
    public interface IInsertApplicationInsightsService
    {
        /// <summary>
        /// This method is used to metrict custom.
        /// </summary>
        /// <param name="metrict"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        bool Execute(InsertApplicationInsightsModel metrict);
    }
}
