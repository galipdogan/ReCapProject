﻿using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValitadion
{
    public class CustomerValidator:AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(cus => cus.CompanyName).NotEmpty();
            
            RuleFor(cus => cus.CompanyName).MinimumLength(2);
         
            RuleFor(cus => cus.UserId).NotEmpty();
            
        }
    }
}
