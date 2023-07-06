using Brewup.Purchases.SharedKernel.DomainIds;

namespace Brewup.Purchases.SharedKernel.DTOs;

public class OrderLine
{
	public BeerId BeerId { get; set; } = default!;
	public BeerName BeerName { get; set; } = default!;
	public Quantity Quantity { get; set; } = default!;
	public Price Price { get; set; } = default!;
}