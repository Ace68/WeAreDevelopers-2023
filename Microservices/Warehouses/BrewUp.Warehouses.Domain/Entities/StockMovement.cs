using BrewUp.Warehouses.SharedKernel.DomainIds;
using BrewUp.Warehouses.SharedKernel.Dtos;
using Muflone.Core;

namespace BrewUp.Warehouses.Domain.Entities;

public sealed class StockMovement : Entity
{
	private PurchaseOrderId _purchaseOrderId;
	private MovementDate _movementDate;

	private BeerId _beerId;
	private Stock _stock;

	internal PurchaseOrderId PurchaseOrderId => _purchaseOrderId;

	protected StockMovement()
	{
	}

	internal StockMovement(PurchaseOrderId purchaseOrderId, BeerId beerId, Stock stock)
	{
		_purchaseOrderId = purchaseOrderId;
		_movementDate = new MovementDate(DateTime.UtcNow);

		_beerId = beerId;
		_stock = stock;
	}
}