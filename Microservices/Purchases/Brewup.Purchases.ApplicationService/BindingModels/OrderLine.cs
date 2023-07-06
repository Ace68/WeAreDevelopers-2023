namespace Brewup.Purchases.ApplicationService.BindingModels;

public class OrderLine
{
	public Guid ProductId { get; set; }
	public string Title { get; set; }
	public Quantity Quantity { get; set; }
	public Price Price { get; set; }
}