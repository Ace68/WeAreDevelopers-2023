using BrewUp.Warehouses.Domain.CommandHandlers;
using BrewUp.Warehouses.Messages.Commands;
using Microsoft.Extensions.Logging;
using Muflone.Messages.Commands;
using Muflone.Persistence;
using Muflone.Transport.RabbitMQ.Abstracts;
using Muflone.Transport.RabbitMQ.Consumers;

namespace BrewUp.Warehouses.Infrastructure.RabbitMq.Commands;

public sealed class CreateBeerConsumer : CommandConsumerBase<CreateBeer>
{
	protected override ICommandHandlerAsync<CreateBeer> HandlerAsync { get; }

	public CreateBeerConsumer(IRepository repository, IMufloneConnectionFactory connectionFactory, ILoggerFactory loggerFactory) 
		: base(repository, connectionFactory, loggerFactory)
	{
		HandlerAsync = new CreateBeerCommandHandler(repository, loggerFactory);
	}
}