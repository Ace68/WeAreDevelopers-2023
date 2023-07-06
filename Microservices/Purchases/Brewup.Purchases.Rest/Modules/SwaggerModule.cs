using Brewup.Purchases.ApplicationService.BindingModels;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Brewup.Purchases.Rest.Modules;

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
		builder.Services.AddSwaggerGen(setup =>
		{
			setup.SchemaFilter<OrderSchemaFilter>();
			setup.SwaggerDoc("v1", new OpenApiInfo()
			{
				Description = "BrewUp API - Purchases REST Service",
				Title = "BrewUp API - Purchases",
				Version = "v1",
				Contact = new OpenApiContact
				{
					Name = "BrewUp.API.Purchases"
				}
			});
		});

		return builder.Services;
	}

	public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
	{
		return endpoints;
	}
}

public class OrderSchemaFilter : ISchemaFilter
{
	public void Apply(OpenApiSchema schema, SchemaFilterContext context)
	{
		if (context.Type == typeof(Order))
			schema.Example = new OpenApiObject
			{
				["Id"] = new OpenApiString(Guid.NewGuid().ToString()),
				["SupplierId"] = new OpenApiString(Guid.NewGuid().ToString()),
				["Date"] = new OpenApiDate(DateTime.Today),
				["Lines"] = new OpenApiArray
				{
					new OpenApiObject
					{
						["ProductId"] = new OpenApiString(Guid.NewGuid().ToString()),
						["Title"] = new OpenApiString("Muflone IPA"),
						["Quantity"] = new OpenApiObject()
						{
							["Value"] = new OpenApiDouble(10),
							["UnitOfMeasure"] = new OpenApiString("N.")
						},
						["Price"] = new OpenApiObject()
						{
							["Value"] = new OpenApiDouble(7),
							["Currency"] = new OpenApiString("EUR")
						}
					}
				}
			};
	}
}