﻿using Brewup.Purchases.ApplicationService.BindingModels;
using FluentValidation;

namespace Brewup.Purchases.ApplicationService.Validators;

public sealed class OrderLineValidator : AbstractValidator<OrderLine>
{
	public OrderLineValidator()
	{
		RuleFor(v => v.ProductId).NotEqual(Guid.Empty);
		RuleFor(v => v.Title).NotEmpty();

		RuleFor(v => v.Quantity.Value).GreaterThan(0);
		RuleFor(v => v.Quantity.UnitOfMeasure).NotEmpty();

		RuleFor(v => v.Price.Value).GreaterThan(0);
		RuleFor(v => v.Price.Currency).NotEmpty();
	}
}