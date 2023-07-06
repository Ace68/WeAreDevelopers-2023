using BrewUp.Warehouses.Infrastructure.RabbitMq.Commands;
using BrewUp.Warehouses.Infrastructure.RabbitMq.Events;
using BrewUp.Warehouses.ReadModel.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Muflone.Persistence;
using Muflone.Transport.RabbitMQ;
using Muflone.Transport.RabbitMQ.Abstracts;
using Muflone.Transport.RabbitMQ.Factories;
using Muflone.Transport.RabbitMQ.Models;

namespace BrewUp.Warehouses.Infrastructure.RabbitMq;

public static class RabbitMqHelper
{
	public static IServiceCollection AddRabbitMq(this IServiceCollection services,
		RabbitMqSettings rabbitMqSettings)
	{
		var serviceProvider = services.BuildServiceProvider();
		var repository = serviceProvider.GetRequiredService<IRepository>();
		var loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();

		var rabbitMQConfiguration = new RabbitMQConfiguration(rabbitMqSettings.Host, rabbitMqSettings.Username,
			rabbitMqSettings.Password, rabbitMqSettings.ExchangeCommandName, rabbitMqSettings.ExchangeEventName);
		var connectionFactory = new MufloneConnectionFactory(rabbitMQConfiguration, loggerFactory);

		services.AddMufloneTransportRabbitMQ(loggerFactory, rabbitMQConfiguration);

		serviceProvider = services.BuildServiceProvider();
		services.AddMufloneRabbitMQConsumers(new List<IConsumer>
		{
			new CreateBeerConsumer(repository!, connectionFactory,
				loggerFactory),

			new BeerCreatedConsumer(serviceProvider.GetRequiredService<IBeerService>(),
				connectionFactory,
				loggerFactory),

			new LoadBeerInStockConsumer(repository!, connectionFactory,
				loggerFactory),

			new BeerLoadedInStockConsumer(serviceProvider.GetRequiredService<IBeerService>(),
				connectionFactory,
				loggerFactory)
		});

		return services;
	}
}