using FluentValidation;
using KontaktyAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KontaktyAPI.Models.Validators
{
    /// <summary>
    /// //Validator for Data Transfer Object(DTO) for registering new User in database
    /// </summary>
    public class RegisterUserDTOValidator : AbstractValidator<RegisterUserDTO>          
    {
        /// <summary>
        /// Requirements for some fields' length or format
        /// //Guarantee that email is unique 
        /// //if non unique email is given, display errorMessage
        /// </summary>
        /// <param name="dbContext"></param>
        public RegisterUserDTOValidator(ContactDB dbContext)
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Password)
                .MinimumLength(5);

            RuleFor(x => x.ConfirmPassword)
                .Equal(e => e.Password);
            
            RuleFor(x => x.Email)
                .Custom((value, context) =>
                {
                    var emailUsed = dbContext.Users.Any(u => u.Email == value);             
                    if (emailUsed)
                    {
                        context.AddFailure("Email", "Email already used");                  
                    }
                });
        }

    }
}
