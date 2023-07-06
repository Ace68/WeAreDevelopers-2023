using Microsoft.Extensions.Logging;
using Muflone.Messages.Events;

namespace BrewUp.Sagas.Warehouses.Adapters;

public abstract class IntegrationEventHandlerBase<T> : IntegrationEventHandlerAsync<T> where T : IntegrationEvent
{
	protected readonly ILogger Logger;

	protected IntegrationEventHandlerBase(ILoggerFactory loggerFactory) : base(loggerFactory)
	{
		Logger = loggerFactory.CreateLogger(GetType());
	}
}