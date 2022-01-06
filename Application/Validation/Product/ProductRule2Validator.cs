using RestApi.Application.Models.ProductDtos;
using System.ComponentModel.DataAnnotations;

namespace RestApi.Application.Validation.Product
{
    public class ProductRule2Validator : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value == null) return true;
            var createproductDto = (CreateProductDto)value;
            return !(createproductDto.Name == "tablet" && createproductDto.Price == 1400);
        }
    }
}
