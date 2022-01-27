using System.ComponentModel.DataAnnotations;

namespace RestApi.Application.Models.ProductDtos
{
    public class UpdateProductDto : IValidatableObject
    {
        public string? Name { get; set; }
        public int Price { get; set; }
        public string? Description { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var result = new List<ValidationResult>();
            //if (string.IsNullOrEmpty(Name))
            //    result.Add(new ValidationResult("Name is Required", new[] { "Name" }));
            //else if (!Name.ToCharArray().ToList().All(c => char.IsLetter(c)))
            //    result.Add(new ValidationResult("Invalid Name", new[] { "Name" }));
            //if (Price < 500 || Price > 2000)
            //    result.Add(new ValidationResult("Invalid Price", new[] { "Price" }));
            //if (Name == "phone" && Price == 1560)
            //    result.Add(new ValidationResult("Invalid Product", new[] { "Name", "Price" }));
            //if (!(Description.Contains("@") && Description.Contains(".")))
            //    result.Add(new ValidationResult("Invalid Description", new[] { "Description" }));
            return result;
        }
    }
}
