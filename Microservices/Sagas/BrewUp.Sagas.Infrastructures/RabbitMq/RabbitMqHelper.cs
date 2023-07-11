using BrewUp.Sagas.Infrastructures.RabbitMq.Commands;
using BrewUp.Sagas.Infrastructures.RabbitMq.Events;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Muflone.Persistence;
using Muflone.Saga.Persistence;
using Muflone.Transport.RabbitMQ;
using Muflone.Transport.RabbitMQ.Abstracts;
using Muflone.Transport.RabbitMQ.Factories;
using Muflone.Transport.RabbitMQ.Models;

namespace BrewUp.Sagas.Infrastructures.RabbitMq;

public static class RabbitMqHelper
{
	public static IServiceCollection AddRabbitMq(this IServiceCollection services,
		RabbitMqSettings rabbitMqSettings)
	{
		var serviceProvider = services.BuildServiceProvider();
		var loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();

		var rabbitMQConfiguration = new RabbitMQConfiguration(
			rabbitMqSettings.Host,
			rabbitMqSettings.Username,
			rabbitMqSettings.Password,
			new TimeSpan(0, 0, 0, 0, 200),
			rabbitMqSettings.ExchangeCommandName,
			rabbitMqSettings.ExchangeEventName);

		var mufloneConnectionFactory = new MufloneConnectionFactory(rabbitMQConfiguration, loggerFactory!);

		services.AddMufloneTransportRabbitMQ(loggerFactory, rabbitMQConfiguration);

		serviceProvider = services.BuildServiceProvider();
		services.AddMufloneRabbitMQConsumers(new List<IConsumer>
		{
			new BeersReceivedConsumer(serviceProvider.GetRequiredService<IServiceBus>(),
				mufloneConnectionFactory,
				loggerFactory),
			new StartBeersReceivedSagaConsumer(serviceProvider.GetRequiredService<IServiceBus>(),
				serviceProvider.GetRequiredService<ISagaRepository>(),
				mufloneConnectionFactory, loggerFactory),
			new BeerCreatedSagaConsumer(serviceProvider.GetRequiredService<IServiceBus>(),
				serviceProvider.GetRequiredService<ISagaRepository>(),
				mufloneConnectionFactory, loggerFactory),
			new BeerLoadedInStockSagaConsumer(serviceProvider.GetRequiredService<IServiceBus>(),
				serviceProvider.GetRequiredService<ISagaRepository>(),
				mufloneConnectionFactory, loggerFactory),

			new CreateBeerConsumer(new ConsumerConfiguration(), mufloneConnectionFactory, loggerFactory),
		});

		return services;
	}
}