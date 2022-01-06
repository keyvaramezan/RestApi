using System.ComponentModel.DataAnnotations;

namespace RestApi.Application.Models.ImageDtos
{

    public class CreateImageDto
    {
        [Required]
        public string? Name { get; set; }

    }
}
