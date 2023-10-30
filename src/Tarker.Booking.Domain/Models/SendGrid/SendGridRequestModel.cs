namespace Tarker.Booking.Domain.Models.SendGrid
{
    public class SendGridRequestModel
    {
        public required ContentEmail From { get; set; }
        public required List<ContentBody> Body { get; set; }
        public List<Personalization>? Personalizations { get; set; }
    }
    /// <summary>
    /// This class is used to personalization.
    /// Subject > Contain subject by email.
    /// To > ContentEmail List.
    /// </summary>
    public class Personalization
    {
        public required string Subject { get; set; }
        public required List<ContentEmail> To { get; set; }
    }
    /// <summary>
    /// This class is used to content Email
    /// Email > Email Send and Received.
    /// Name > Name Send and Received.
    /// </summary>
    public class ContentEmail
    {
        public required string Email { get; set; }
        public required string Name { get; set; }
    }
    /// <summary>
    /// This class is used to content body.
    /// Type > Contain Text or HTML.
    /// Value > Contain Value.
    /// </summary>
    public class ContentBody
    {
        public required string Type { get; set; }
        public required string Value { get; set; }
    }
}
