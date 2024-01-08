namespace ReefTankTracker.Dto.v1.Responses.Parameter
{
    public class ParameterResponseDtoV1
    {
        public Guid Id { get; set; }
        public String UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Boolean Default { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDateTime { get; set; }
    }
}
