using Muflone.Core;

namespace BrewUp.Sagas.Warehouses.SharedKernel.DomainIds;

public class ProductId : DomainId
{
	public ProductId(Guid value) : base(value)
	{
	}
}