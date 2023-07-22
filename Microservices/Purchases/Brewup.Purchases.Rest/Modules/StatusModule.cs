using Brewup.Purchases.Rest.Extensions;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

namespace Brewup.Purchases.Rest.Modules
{
	public sealed class StatusModule : IModule
	{
		public bool IsEnabled => true;
		public int Order => 0;

		public IServiceCollection RegisterModule(WebApplicationBuilder builder)
		{
			builder.Services.AddHealthChecks();
			return builder.Services;
		}

		public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
		{
			endpoints.MapHealthChecks("/health/api", new HealthCheckOptions
			{
				ResponseWriter = HealthCheckHelper.WriteResponse
			});

			return endpoints;
		}
	}
}