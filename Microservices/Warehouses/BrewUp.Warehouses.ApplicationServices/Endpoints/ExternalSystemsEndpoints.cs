using BrewUp.Warehouses.ApplicationServices.Validators;
using BrewUp.Warehouses.Messages.Events;
using BrewUp.Warehouses.SharedKernel;
using BrewUp.Warehouses.SharedKernel.DomainIds;
using BrewUp.Warehouses.SharedKernel.Dtos;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Muflone;

namespace BrewUp.Warehouses.ApplicationServices.Endpoints;

public static class ExternalSystemsEndpoints
{
	public static async Task<IResult> HandleUpdateAvailability(
		IValidator<BeersReceivedJson> validator,
		ValidationHandler validationHandler,
		BeersReceivedJson body,
		IEventBus eventBus,
		CancellationToken cancellationToken)
	{
		await validationHandler.ValidateAsync(validator, body);
		if (!validationHandler.IsValid)
			return Results.BadRequest(validationHandler.Errors);

		var beersReceived = new BeersReceived(new PurchaseOrderId(new Guid(body.OrderId)),
			Guid.NewGuid(), body.OrderLines.ToEntity());

		await eventBus.PublishAsync(beersReceived, cancellationToken);

		return Results.Ok();
	}
}