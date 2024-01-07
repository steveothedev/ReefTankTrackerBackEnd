using ReefTankTracker.Models.v1;

namespace ReefTankTracker.Dto.v1.Responses.ReefTank
{
    public class ReefTankResponseDtoV1
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDateTime { get; set; }
    }
}
