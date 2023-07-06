namespace Brewup.Purchases.SharedKernel.DTOs;

public class Price
{
	public decimal Value { get; set; }
	public string Currency { get; set; } = string.Empty;
}