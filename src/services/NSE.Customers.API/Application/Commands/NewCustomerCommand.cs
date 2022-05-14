﻿using FluentValidation;
using NSE.Core.DomainObject.ValueObjects;
using NSE.Core.Messages;

namespace NSE.Customers.API.Application.Commands
{
    public class NewCustomerCommand : Command
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string SocialNumber { get; private set; }

        public NewCustomerCommand(Guid id, string name, string email, string socialNumber)
        {
            AggregateId = id;
            Id = id;
            Name = name;
            Email = email;
            SocialNumber = socialNumber;
        }

        public override bool IsValid()
        {
            ValidationResult = new NewCustomerValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class NewCustomerValidation : AbstractValidator<NewCustomerCommand>
    {
        public NewCustomerValidation()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("Invalid customer id");

            RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage("Customer name must be set");

            RuleFor(c => c.SocialNumber)
                .Must(IsValidSsn)
                .WithMessage("Invalid SSN.");

            RuleFor(c => c.Email)
                .Must(HasValidEmail)
                .WithMessage("Wrong e-mail.");
        }

        protected static bool IsValidSsn(string ssn)
        {
            return !string.IsNullOrEmpty(ssn);
        }

        protected static bool HasValidEmail(string email)
        {
            return Email.Validate(email);
        }
    }
}
