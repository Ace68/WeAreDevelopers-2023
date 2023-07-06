using BrewUp.Warehouses.SharedKernel.Dtos;
using FluentValidation;

namespace BrewUp.Warehouses.ApplicationServices.Validators;

public class BeersReceivedValidator : AbstractValidator<BeersReceivedJson>
{
	public BeersReceivedValidator()
	{
		RuleFor(v => v.OrderId).NotEmpty().NotNull();

		RuleForEach(v => v.OrderLines).SetValidator(new OrderLineValidator());
	}
}