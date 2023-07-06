namespace Brewup.Purchases.Rest.Modules;

public sealed class HealthModule : IModule
{
	public bool IsEnabled => true;
	public int Order => 30;

	public IServiceCollection RegisterModule(WebApplicationBuilder builder)
	{
		builder.Services.AddHealthChecks();
		return builder.Services;
	}

	public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
	{
		endpoints.MapHealthChecks("/health");
		return endpoints;
	}
}