using BrewUp.Sagas.Infrastructures.MongoDb;
using BrewUp.Sagas.Infrastructures.RabbitMq;
using Microsoft.Extensions.DependencyInjection;
using Muflone.Saga.Persistence.MongoDb;

namespace BrewUp.Sagas.Infrastructures;

public static class InfrastructureHelper
{
	public static IServiceCollection AddInfrastructure(this IServiceCollection services,
		MongoDbSettings mongoDbSettings,
		RabbitMqSettings rabbitMqSettings)
	{
		services.AddMongoDb(mongoDbSettings);
		services.AddMongoSagaStateRepository(new MongoSagaStateRepositoryOptions(mongoDbSettings.ConnectionString, mongoDbSettings.DatabaseName));
		services.AddRabbitMq(rabbitMqSettings);

		return services;
	}
}