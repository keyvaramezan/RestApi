using RestApi.Application.Validation.Product;
using System.ComponentModel.DataAnnotations;

namespace RestApi.Application.Models.ProductDtos
{
    [ProductRule1Validator(ErrorMessage = "Rule1 Not Passed!")]
    [ProductRule2Validator(ErrorMessage = "Rule2 Not Passed!")]
    public class CreateProductDto
    {
        [Required(ErrorMessage = "Costum Message1")]
        //[StringLength(maximumLength: 20, MinimumLength = 3)]
        //[ProductNameValidator]
        public string? Name { get; set; }
        [Range(100, 1000)]
        public int Price { get; set; }
        //[RegularExpression(@"([a-zA-Z0-9\\_\\-\\.]+)@([a-zA-Z]+).(.+)")]
        public string? Description { get; set; }
    }
}
