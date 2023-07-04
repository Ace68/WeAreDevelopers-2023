using BrewUp.Modules.Purchases.ReadModel.EventHandlers;
using Microsoft.Extensions.DependencyInjection;

namespace BrewUp.Modules.Purchases.ReadModel;

public static class PurchasesReadModelHelper
{
	public static IServiceCollection AddPurchasesReadModel(this IServiceCollection services)
	{
		services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(PurchaseOrderCreatedEventHandler).Assembly));

		return services;
	}
}