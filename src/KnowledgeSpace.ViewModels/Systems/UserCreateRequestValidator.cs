using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace KnowledgeSpace.ViewModels.Systems
{
    public class UserCreateRequestValidator : AbstractValidator<UserCreateRequest>
    {
        public UserCreateRequestValidator() 
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("User name value is required");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Password value is required")
                .MinimumLength(8).WithMessage("Password has to atleast 8 characters")
                .Matches(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$")
                .WithMessage("Password is not match complexity rules.");

            RuleFor(x => x.Email).NotEmpty().WithMessage("Email value is required")
                .Matches(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").WithMessage("Email format is not match");

            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Phone number value is required");

            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name value is required")
                .MaximumLength(50).WithMessage("First name can not over 50 characters limit");

            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name value is required")
                .MaximumLength(50).WithMessage("Last name can not over 50 characters limit");
        }
    }
}
