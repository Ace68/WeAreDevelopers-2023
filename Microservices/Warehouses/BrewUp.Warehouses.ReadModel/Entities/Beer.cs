using BrewUp.Warehouses.SharedKernel.DomainIds;
using BrewUp.Warehouses.SharedKernel.Dtos;

namespace BrewUp.Warehouses.ReadModel.Entities;

public class Beer : EntityBase
{
	public string BeerName { get; private set; } = string.Empty;
	public decimal Stock { get; private set; } = 0;
	public decimal Availability { get; private set; } = 0;
	public Price Price { get; private set; }

	protected Beer()
	{
	}

	public static Beer Create(BeerId beerId, BeerName beerName)
	{
		return new Beer(beerId.ToString(), beerName.Value);
	}

	private Beer(string beerId, string beerName)
	{
		Id = beerId;
		BeerName = beerName;
		Stock = 0;
		Availability = 0;
		Price = new Price(0, "EUR");
	}

	public void UpdateStock(Stock stock)
	{
		Stock = stock.Value;
		Availability += Stock;
	}

	public void UpdatePrice(Price price)
	{
		Price = price;
	}

	public BeerJson ToJson()
	{
		return new BeerJson
		{
			BeerId = Id,
			BeerName = BeerName,
			Stock = Stock,
			Availability = Availability,
			Price = Price
		};
	}
}