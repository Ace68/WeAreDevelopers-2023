using Brewup.Purchases.ApplicationService.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace Brewup.Purchases.ApplicationService;

public static class PurchasesHelper
{
	public static IServiceCollection AddPurchases(this IServiceCollection services)
	{
		services.AddFluentValidationAutoValidation();
		services.AddValidatorsFromAssemblyContaining<OrderValidator>();
		services.AddSingleton<ValidationHandler>();
		services.AddScoped<IPurchasesOrchestrator, PurchasesOrchestrator>();
		return services;
	}
}