using System.ComponentModel.DataAnnotations;

namespace RestApi.Application.Validation.Product
{
    public class ProductNameValidator : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value == null) return true;
            return value.ToString().ToCharArray().ToList().All(c => char.IsLetter(c));

        }
    }
}
