using BrewUp.Sagas.Warehouses.Messages.Commands;
using BrewUp.Sagas.Warehouses.Messages.Events;
using BrewUp.Sagas.Warehouses.SharedKernel.DomainIds;
using BrewUp.Sagas.Warehouses.SharedKernel.Dtos;
using Microsoft.Extensions.Logging;
using Muflone.Persistence;
using Muflone.Saga;
using Muflone.Saga.Persistence;

namespace BrewUp.Sagas.Warehouses.Sagas;

public sealed class BeersReceivedSaga : Saga<BeersReceivedSaga.BeersReceivedSagaState>,
	ISagaStartedByAsync<StartBeersReceivedSaga>,
	ISagaEventHandlerAsync<BeerCreated>,
	ISagaEventHandlerAsync<BeerLoadedInStock>
{
	public class BeersReceivedSagaState
	{
		public string PurchaseOrderId { get; set; } = string.Empty;

		public IEnumerable<OrderLine> OrderLines { get; set; } = Enumerable.Empty<OrderLine>();

		public DateTime StartedAt { get; set; } = DateTime.MinValue;
		public DateTime FinishedAt { get; set; } = DateTime.MinValue;
	}


	public BeersReceivedSaga(IServiceBus serviceBus, ISagaRepository repository, ILoggerFactory loggerFactory)
		: base(serviceBus, repository, loggerFactory)
	{
	}

	public async Task StartedByAsync(StartBeersReceivedSaga command)
	{
		//cancellationToken.ThrowIfCancellationRequested();

		SagaState = new BeersReceivedSagaState
		{
			PurchaseOrderId = command.PurchaseOrderId.Value.ToString(),
			OrderLines = command.OrderLines,
			StartedAt = DateTime.UtcNow
		};
		await Repository.SaveAsync(command.MessageId, SagaState);

		foreach (var orderLine in command.OrderLines)
		{
			var createBeer = new CreateBeer(orderLine.BeerId, command.MessageId, orderLine.BeerName);
			await ServiceBus.SendAsync(createBeer /* , cancellationToken */);
		}
	}

	public async Task HandleAsync(BeerCreated @event)
	{
		var correlationId =
			new Guid(@event.UserProperties.FirstOrDefault(u => u.Key.Equals("CorrelationId")).Value.ToString()!);
		if (correlationId.Equals(Guid.Empty))
			return;

		var sagaState = await Repository.GetByIdAsync<BeersReceivedSagaState>(correlationId);
		var orderLine = sagaState.OrderLines.FirstOrDefault(o => o.BeerId.Equals(@event.BeerId));
		if (orderLine == null)
			return;

		var loadBeerInStock = new LoadBeerInStock(@event.BeerId, correlationId, new Stock(orderLine.Quantity.Value),
			new Price(orderLine.Price.Value, orderLine.Price.Currency),
			new PurchaseOrderId(new Guid(sagaState.PurchaseOrderId)));
		await ServiceBus.SendAsync(loadBeerInStock /* , cancellationToken */);
	}

	public async Task HandleAsync(BeerLoadedInStock @event)
	{
		var correlationId =
			new Guid(@event.UserProperties.FirstOrDefault(u => u.Key.Equals("CorrelationId")).Value.ToString()!);
		if (correlationId.Equals(Guid.Empty))
			return;

		var sagaState = await Repository.GetByIdAsync<BeersReceivedSagaState>(correlationId);
		sagaState.FinishedAt = DateTime.UtcNow;
		await Repository.SaveAsync(correlationId, sagaState);
	}
}