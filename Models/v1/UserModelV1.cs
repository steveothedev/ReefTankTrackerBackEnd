namespace ReefTankTracker.Models.v1
{
    public class UserModelV1
    {
        public Guid ID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedDateTime { get; set; }
    }
}
