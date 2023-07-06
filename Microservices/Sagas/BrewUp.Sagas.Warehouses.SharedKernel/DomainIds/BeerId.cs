using Muflone.Core;

namespace BrewUp.Sagas.Warehouses.SharedKernel.DomainIds;

public sealed class BeerId : DomainId
{
	public BeerId(Guid value) : base(value)
	{
	}
}