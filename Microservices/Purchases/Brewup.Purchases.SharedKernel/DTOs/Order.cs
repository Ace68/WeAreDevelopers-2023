namespace Brewup.Purchases.SharedKernel.DTOs;

public class Order
{
	public Guid SupplierId { get; set; }
	public DateTime Date { get; set; }
	public IEnumerable<OrderLine> Lines { get; set; }
	public Guid Id { get; }

	public Order()
	{
		Id = Guid.NewGuid();
	}
}