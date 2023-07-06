﻿namespace Brewup.Purchases.ApplicationService;

public interface IPurchasesOrchestrator
{
    Task<string> CreateOrderAsync(BindingModels.Order order, CancellationToken cancellationToken);
    Task ChangeStatusToComplete(Guid id, CancellationToken cancellationToken);
}