namespace ReefTankTracker.Dto.v1.Requests.User
{
    public class UserSignUpRequestsDtoV1
    {
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
