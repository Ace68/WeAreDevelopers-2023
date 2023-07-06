using Brewup.Purchases.ApplicationService.Validators;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Brewup.Purchases.ApplicationService.Endpoints;

public static class PurchasesEndpoints
{
	public static async Task<IResult> HandleCreateOrder(
		IPurchasesOrchestrator purchasesOrchestrator,
		IValidator<BindingModels.Order> validator,
		ValidationHandler validationHandler,
		BindingModels.Order body,
		CancellationToken cancellationToken)
	{
		await validationHandler.ValidateAsync(validator, body);
		if (!validationHandler.IsValid)
			return Results.BadRequest(validationHandler.Errors);

		var orderId = await purchasesOrchestrator.CreateOrderAsync(body, cancellationToken);

		return Results.Created($"/api/v1/Order/{orderId}", orderId);
	}

	public static async Task<IResult> HandleSetOrderStatusToComplete(IPurchasesOrchestrator purchasesOrchestrator, Guid id, CancellationToken cancellationToken)
	{
		await purchasesOrchestrator.ChangeStatusToComplete(id, cancellationToken);
		return Results.Ok();
	}
}