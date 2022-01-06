using System.ComponentModel.DataAnnotations;

namespace RestApi.Application.Models.ImageDtos
{

    public class UpdateImageDto
    {
        [Required]
        public string? Name { get; set; }

    }
}
