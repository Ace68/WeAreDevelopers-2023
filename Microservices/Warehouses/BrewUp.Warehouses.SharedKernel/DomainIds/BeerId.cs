using Muflone.Core;

namespace BrewUp.Warehouses.SharedKernel.DomainIds;

public sealed class BeerId : DomainId
{
	public BeerId(Guid value) : base(value)
	{
	}
}