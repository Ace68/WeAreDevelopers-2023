﻿using BrewUp.Warehouses.SharedKernel.DomainIds;
using BrewUp.Warehouses.SharedKernel.Dtos;
using Muflone.Messages.Commands;

namespace BrewUp.Warehouses.Messages.Commands;

public sealed class LoadBeerInStock : Command
{
	public readonly BeerId BeerId;
	public readonly Stock Stock;
	public readonly Price Price;
	public readonly PurchaseOrderId PurchaseOrderId;

	public LoadBeerInStock(BeerId aggregateId, Guid commitId, Stock stock, Price price, PurchaseOrderId purchaseOrderId)
		: base(aggregateId, commitId)
	{
		BeerId = aggregateId;
		Stock = stock;
		Price = price;
		PurchaseOrderId = purchaseOrderId;
	}
}