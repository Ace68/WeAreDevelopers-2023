namespace BrewUp.Modules.Purchases;

public interface IPurchasesAdapter
{
	Task<string> CreateOrderAsync(BindingModels.Order order, CancellationToken cancellationToken);
	Task ChangeStatusToComplete(Guid id, CancellationToken cancellationToken);
}