using BrewUp.Sagas.Warehouses.Messages.Commands;
using Microsoft.Extensions.Logging;
using Muflone.Transport.RabbitMQ.Abstracts;
using Muflone.Transport.RabbitMQ.Consumers;
using Muflone.Transport.RabbitMQ.Models;

namespace BrewUp.Sagas.Infrastructures.RabbitMq.Commands;

public class CreateBeerConsumer : CommandSenderBase<CreateBeer>
{
	public CreateBeerConsumer(ConsumerConfiguration configuration,
		IMufloneConnectionFactory connectionFactory,
		ILoggerFactory loggerFactory) : base(configuration, connectionFactory, loggerFactory)
	{
	}
}