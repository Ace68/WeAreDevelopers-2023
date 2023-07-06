using BrewUp.Warehouses.Infrastructure.MongoDb;
using BrewUp.Warehouses.Infrastructure.RabbitMq;
using Microsoft.Extensions.DependencyInjection;
using Muflone.Eventstore;
using Muflone.Saga.Persistence.MongoDb;

namespace BrewUp.Warehouses.Infrastructure;

public static class InfrastructureHelper
{
	public static IServiceCollection AddInfrastructure(this IServiceCollection services,
		MongoDbSettings mongoDbSettings,
		EventStoreSettings eventStoreSettings,
		RabbitMqSettings rabbitMqSettings)
	{
		services.AddMongoDb(mongoDbSettings);
		services.AddMongoSagaStateRepository(new MongoSagaStateRepositoryOptions(mongoDbSettings.ConnectionString, mongoDbSettings.DatabaseName));
		services.AddMufloneEventStore(eventStoreSettings.ConnectionString);
		services.AddRabbitMq(rabbitMqSettings);

		return services;
	}
}