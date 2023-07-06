using BrewUp.Sagas.Warehouses.Messages.Commands;
using BrewUp.Sagas.Warehouses.Messages.Events;
using Microsoft.Extensions.Logging;
using Muflone.Persistence;

namespace BrewUp.Sagas.Warehouses.Adapters;

public sealed class BeersReceivedEventHandler : IntegrationEventHandlerBase<BeersReceived>
{
	private readonly IServiceBus _serviceBus;

	public BeersReceivedEventHandler(ILoggerFactory loggerFactory, IServiceBus serviceBus) : base(loggerFactory)
	{
		_serviceBus = serviceBus;
	}

	public override async Task HandleAsync(BeersReceived @event, CancellationToken cancellationToken = default)
	{
		var command = new StartBeersReceivedSaga(@event.PurchaseOrderId, @event.OrderLines);
		await _serviceBus.SendAsync(command, cancellationToken);
	}
}