using Microsoft.Extensions.Logging;
using Muflone.Messages.Events;

namespace Brewup.Purchases.ReadModel.EventHandlers;

public abstract class DomainEventHandlerBase<T> : DomainEventHandlerAsync<T> where T : class, IDomainEvent
{
	protected readonly ILogger Logger;

	protected DomainEventHandlerBase(ILoggerFactory loggerFactory) : base(loggerFactory)
	{
		Logger = loggerFactory.CreateLogger(GetType());
	}
}