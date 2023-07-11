using Brewup.Purchases.Messages.Events;
using Microsoft.Extensions.Logging;
using Muflone.Messages.Events;

namespace Brewup.Purchases.ReadModel.EventHandlers;

public sealed class BeersReceivedEventHandler : IntegrationEventHandlerAsync<BeersReceived>
{
	public BeersReceivedEventHandler(ILoggerFactory loggerFactory) : base(loggerFactory)
	{
	}

	public override Task HandleAsync(BeersReceived @event, CancellationToken cancellationToken = new())
	{
		return Task.CompletedTask;
	}
}