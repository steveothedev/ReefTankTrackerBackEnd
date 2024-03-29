﻿using System.ComponentModel.DataAnnotations;

namespace ReefTankTracker.Dto.v1.Requests.ReefTank
{
    public class ReefTankUpdateRequestDtoV1
    {
        [Required] 
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
    }
}
