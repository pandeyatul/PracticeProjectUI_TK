using System.ComponentModel.DataAnnotations;

namespace PracticeProjectUI_TK.Validations
{
    public class UppercaseAttribute:ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value!= null)
            {
                string stringvalue=value.ToString()??string.Empty;
                if (!string.IsNullOrEmpty(stringvalue))
                {
                    char firstletter = stringvalue[0];
                    if (char.IsUpper(firstletter))
                    {
                        return ValidationResult.Success;
                    }
                }
            }
            // return base.IsValid(value, validationContext);
            return new ValidationResult(ErrorMessage??"The First letter must be in upper case");
        }
    }
}
