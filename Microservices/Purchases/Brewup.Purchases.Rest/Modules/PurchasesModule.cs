using Brewup.Purchases.ApplicationService;
using Brewup.Purchases.ApplicationService.Endpoints;

namespace Brewup.Purchases.Rest.Modules;

public class PurchasesModule : IModule
{
	public bool IsEnabled => true;
	public int Order => 20;

	public IServiceCollection RegisterModule(WebApplicationBuilder builder)
	{
		builder.Services.AddPurchases();

		return builder.Services;
	}

	public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
	{
		var group = endpoints.MapGroup("/api/v1/")
			.WithTags("Purchases");

		group.MapGet("/", () => Results.Ok())
			.Produces(StatusCodes.Status400BadRequest)
			.Produces(StatusCodes.Status200OK)
			.WithName("GetOrders");

		group.MapPost("/Order", PurchasesEndpoints.HandleCreateOrder)
			.Produces(StatusCodes.Status400BadRequest)
			.Produces(StatusCodes.Status201Created)
			.WithName("CreateOrder");

		group.MapPost("/Order/{id}/complete", PurchasesEndpoints.HandleSetOrderStatusToComplete)
			.Produces(StatusCodes.Status400BadRequest)
			.Produces(StatusCodes.Status200OK)
			.WithName("SetStatusToComplete");


		return endpoints;
	}
}