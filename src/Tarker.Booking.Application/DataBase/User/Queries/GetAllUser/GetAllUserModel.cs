namespace Tarker.Booking.Application.DataBase.User.Queries.GetAllUser
{
    public class GetAllUserModel
    {
        public Guid UserId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string UserName { get; set; }
        public required string Password { get; set; }
    }
}
