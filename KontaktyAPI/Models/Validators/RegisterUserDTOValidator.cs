using FluentValidation;
using KontaktyAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KontaktyAPI.Models.Validators
{
    public class RegisterUserDTOValidator : AbstractValidator<RegisterUserDTO>          //Validator for Data Transfer Object(DTO) for registering new User
    {
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
                    var emailUsed = dbContext.Users.Any(u => u.Email == value);             //Guarantee that email is unique and is compatible with email address format
                    if (emailUsed)
                    {
                        context.AddFailure("Email", "Email already used");                  //if wrong email is given, the API returns text message
                    }
                });
        }

    }
}
