using BrewUp.Warehouses.SharedKernel.Dtos;
using FluentValidation;

namespace BrewUp.Warehouses.ApplicationServices.Validators;

public sealed class PriceValidator : AbstractValidator<Price>
{
	public PriceValidator()
	{
		RuleFor(v => v.Currency).NotEmpty().NotNull();
		RuleFor(v => v.Value).GreaterThan(0);
	}
}