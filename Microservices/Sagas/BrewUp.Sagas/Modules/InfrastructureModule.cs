using BrewUp.Sagas.Infrastructures;
using BrewUp.Sagas.Infrastructures.MongoDb;
using BrewUp.Sagas.Infrastructures.RabbitMq;

namespace BrewUp.Sagas.Modules;

public class InfrastructureModule : IModule
{
	public bool IsEnabled => true;
	public int Order => 99;
	public IServiceCollection RegisterModule(WebApplicationBuilder builder)
	{
		var mongoDbSettings = builder.Configuration.GetSection("BrewUp:MongoDb").Get<MongoDbSettings>()!;
		var rabbitMqSettings = builder.Configuration.GetSection("BrewUp:RabbitMQ").Get<RabbitMqSettings>()!;

		builder.Services.AddInfrastructure(mongoDbSettings, rabbitMqSettings);

		return builder.Services;
	}

	public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints) => endpoints;
}