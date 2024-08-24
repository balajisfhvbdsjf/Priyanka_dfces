using Autoguard.Application.DTOs;
using FluentValidation;

namespace Autoguard.Application.Validators
{
    public class BusinessValidator : AbstractValidator<BusinessDto>
    {
        public BusinessValidator()
        {
            RuleFor(b => b.BusinessName).NotEmpty().WithMessage("Business Name is required.");
            RuleFor(b => b.RegNumber).Matches(@"^\d{3}\/\d{6}\/\d{2}$").WithMessage("Invalid Registration Number format.");
            RuleFor(b => b.BusinessEmail).EmailAddress().WithMessage("Invalid email format.");
            RuleFor(b => b.BusinessContactNumber).Matches(@"^\(\d{2}\) \d{3} \d{4}$").WithMessage("Invalid Contact Number format.");
            RuleFor(b => b.PostalCode).InclusiveBetween(1, 9999).WithMessage("Postal Code must be between 0001 and 9999.");
            RuleFor(b => b.TaxNumber).Must(t => t.ToString().Length == 10).WithMessage("Tax Number must be 10 digits.");
            RuleFor(b => b.PayeNumber).Matches(@"^7\d{9}$").WithMessage("PAYE Number must start with 7 and be 10 digits.");
            RuleFor(b => b.VatNumber).Matches(@"^4\d{9}$").WithMessage("VAT Number must start with 4 and be 10 digits.");
        }
    }
}
