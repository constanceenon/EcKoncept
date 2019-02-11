using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EcKoncept.Models.View
{
    public class RegistrationViewModel: IValidatableObject
    {
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(Password != ConfirmPassword)
            {
                yield return new ValidationResult("Passwords do not match", new[] { nameof(Password), nameof(ConfirmPassword) });
            }
        }
    }
}
