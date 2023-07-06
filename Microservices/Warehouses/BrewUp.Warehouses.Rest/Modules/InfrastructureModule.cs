using BrewUp.Warehouses.Infrastructure;
using BrewUp.Warehouses.Infrastructure.MongoDb;
using BrewUp.Warehouses.Infrastructure.RabbitMq;

namespace BrewUp.Warehouses.Rest.Modules;

public class InfrastructureModule : IModule
{
	public bool IsEnabled => true;
	public int Order => 99;
	public IServiceCollection RegisterModule(WebApplicationBuilder builder)
	{
		var mongoDbSettings = builder.Configuration.GetSection("BrewUp:MongoDb").Get<MongoDbSettings>()!;
		var rabbtiMqSettings = builder.Configuration.GetSection("BrewUp:RabbitMQ").Get<RabbitMqSettings>()!;
		var eventStoreSettings = builder.Configuration.GetSection("BrewUp:EventStore").Get<EventStoreSettings>()!;

		builder.Services.AddInfrastructure(mongoDbSettings, eventStoreSettings, rabbtiMqSettings);

		return builder.Services;
	}

	public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
	{
		return endpoints;
	}
}