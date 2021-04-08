using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValitadion
{
    public class UserValidator:AbstractValidator<User>
    {
        public UserValidator()
        {
       
            RuleFor(u => u.FirstName).NotEmpty();
            RuleFor(u => u.FirstName).MinimumLength(2);

            RuleFor(u => u.LastName).NotEmpty();
            RuleFor(u => u.LastName).MinimumLength(2);

            RuleFor(u => u.EMail).NotEmpty();
            RuleFor(u => u.EMail).EmailAddress();

            RuleFor(u => u.Password).NotEmpty();
            RuleFor(u => u.Password).MinimumLength(6);
           

        }
    }
}
