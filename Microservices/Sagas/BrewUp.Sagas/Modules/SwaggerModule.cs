using Microsoft.OpenApi.Models;

namespace BrewUp.Sagas.Modules
{
	public sealed class SwaggerModule : IModule
	{
		public bool IsEnabled { get; }
		public int Order { get; }

		public SwaggerModule()
		{
			IsEnabled = true;
			Order = 0;
		}

		public IServiceCollection RegisterModule(WebApplicationBuilder builder)
		{
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen(setup => setup.SwaggerDoc("v1", new OpenApiInfo()
			{
				Description = "BrewUp API - Sagas Service",
				Title = "BrewUp - Sagas",
				Version = "v1",
				Contact = new OpenApiContact
				{
					Name = "BrewUp.Sagas"
				}
			}));

			return builder.Services;
		}

		public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints) => endpoints;
	}
}