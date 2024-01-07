namespace ReefTankTracker.Models.v1
{
    public class ReefTankModelV1
    {
        public Guid Id { get; set; }
        public UserModelV1 UserId { get; set; } = null!;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedDateTime { get; set; } 
        public DateTime? UpdatedDateTime { get; set;}
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDateTime { get; set; }
    }
}
