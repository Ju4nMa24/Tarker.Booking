namespace Tarker.Booking.Domain.Models.ApplicationInsights
{
    public class InsertApplicationInsightsModel
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="content"></param>
        /// <param name="detail"></param>
        public InsertApplicationInsightsModel(string type, string content, string detail)
        {
            Id = Guid.NewGuid().ToString();
            Type = type;
            Content = content;
            Detail = detail;
        }

        public string? Id { get; set; }
        public string? Type { get; set; }
        public string? Content { get; set; }
        public string? Detail { get; set; }
    }
}
