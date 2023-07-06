using Brewup.Purchases.Messages.Events;
using Brewup.Purchases.SharedKernel.DomainIds;
using Brewup.Purchases.SharedKernel.DTOs;
using Muflone.Core;

namespace Brewup.Purchases.Domain.Entities;

public class Order : AggregateRoot
{
	private SupplierId _supplierId;
	private DateTime _date;
	private IEnumerable<OrderLine> _lines;
	private Status _status;

	//Called when loaded from the event store
	protected Order()
	{
	}

	internal static Order Create(PurchaseOrderId id, SupplierId supplierId, DateTime date,
		IEnumerable<SharedKernel.DTOs.OrderLine> lines)
	{
		return new Order(id, supplierId, date, lines);
	}


	private Order(PurchaseOrderId id, SupplierId supplierId, DateTime date,
		IEnumerable<SharedKernel.DTOs.OrderLine> lines)
	{
		//Invariants checks
		//if (!_lines.Any())
		//	throw new ArgumentException("Order must have at least one line", nameof(lines));

		/////////
		RaiseEvent(new PurchaseOrderCreated(id, supplierId, date, lines));
	}

	private void Apply(PurchaseOrderCreated @event)
	{
		Id = @event.AggregateId;
		_status = Status.Created;
		//_supplierId = @event.SupplierId;
		//_date = @event.Date;
		_lines = @event.Lines.ToEntities();
	}

	public void Complete()
	{
		if (!_status.Equals(Status.Complete))
			RaiseEvent(new PurchaseOrderStatusChangedToComplete((PurchaseOrderId)Id, _lines.ToDtos()));
	}

	private void Apply(PurchaseOrderStatusChangedToComplete @event)
	{
		_status = Status.Complete;
	}
}