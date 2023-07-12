using BrewUp.Modules.Purchases.Validators;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace BrewUp.Modules.Purchases.Endpoints;

public static class PurchasesEndpoints
{
	public static async Task<IResult> HandleCreateOrder(
		IPurchasesFacade purchasesFacade,
		IValidator<BindingModels.Order> validator,
		ValidationHandler validationHandler,
		BindingModels.Order body,
		CancellationToken cancellationToken)
	{
		await validationHandler.ValidateAsync(validator, body);
		if (!validationHandler.IsValid)
			return Results.BadRequest(validationHandler.Errors);

		var orderId = await purchasesFacade.CreateOrderAsync(body, cancellationToken);

		return Results.Created($"/api/v1/Order/{orderId}", orderId);
	}

	public static async Task<IResult> HandleSetOrderStatusToComplete(IPurchasesFacade purchasesFacade,
		Guid id,
		CancellationToken cancellationToken)
	{
		await purchasesFacade.ChangeStatusToComplete(id, cancellationToken);
		return Results.Ok();
	}
}