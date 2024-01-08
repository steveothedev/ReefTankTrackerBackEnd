using System.ComponentModel.DataAnnotations;

namespace ReefTankTracker.Dto.v1.Requests.Parameter
{
    public class ParameterCreateRequestDtoV1
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required]
        public Boolean Default { get; set; }
    }
}
