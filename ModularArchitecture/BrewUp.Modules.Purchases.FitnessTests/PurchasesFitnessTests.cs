using ArchUnitNET.Domain;
using ArchUnitNET.Fluent;
using ArchUnitNET.Loader;
using ArchUnitNET.xUnit;
using static ArchUnitNET.Fluent.ArchRuleDefinition;

namespace BrewUp.Modules.Purchases.FitnessTests;

public class PurchasesFitnessTests
{
	private static readonly Architecture PurchasesArchitecture
		= new ArchLoader().LoadAssemblies(typeof(IPurchasesAdapter).Assembly).Build();

	private readonly IObjectProvider<IType> _purchasesModule =
		Types().That().ResideInAssembly("Brewup.Modules.Purchases").As("Purchases Module");

	private readonly IObjectProvider<Class> _purchasesClasses =
		Classes().That().ImplementInterface("IPurchasesFacade").As("Purchases Classes");

	private readonly IObjectProvider<IType> _forbiddenLayer = Types().
		That().
		HaveFullNameContaining("BrewUp.Modules.Warehouses").
		As("Forbidden Layer");

	private readonly IObjectProvider<Interface> _forbiddenInterfaces = Interfaces().
		That().
		HaveFullNameContaining("Warehouses").
		As("Forbidden Interfaces");

	[Fact]
	public void PurchasesTypesShouldBeInCorrectLayer()
	{
		IArchRule forbiddenInterfacesShouldBeInForbiddenLayer =
			Interfaces().That().Are(_forbiddenInterfaces).Should().Be(_forbiddenLayer);

		forbiddenInterfacesShouldBeInForbiddenLayer.Check(PurchasesArchitecture);
	}

	[Fact]
	public void TypesShouldBeInCorrectModule()
	{
		IArchRule purchasesClassesShouldBeInPurchasesModule =
			Classes().That().Are(_purchasesClasses).Should().Be(_purchasesModule);
		IArchRule forbiddenInterfacesShouldBeInForbiddenLayer =
			Interfaces().That().Are(_forbiddenInterfaces).Should().Be(_forbiddenLayer);

		//check if your architecture fulfills your rules
		purchasesClassesShouldBeInPurchasesModule.Check(PurchasesArchitecture);
		forbiddenInterfacesShouldBeInForbiddenLayer.Check(PurchasesArchitecture);

		//you can also combine your rules
		IArchRule combinedArchRule =
			purchasesClassesShouldBeInPurchasesModule
				.And(forbiddenInterfacesShouldBeInForbiddenLayer);

		combinedArchRule.Check(PurchasesArchitecture);
	}
}