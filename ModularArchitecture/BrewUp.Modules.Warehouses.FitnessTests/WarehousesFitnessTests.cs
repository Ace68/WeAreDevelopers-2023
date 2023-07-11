using ArchUnitNET.Domain;
using ArchUnitNET.Fluent;
using ArchUnitNET.Loader;
using ArchUnitNET.xUnit;
using BrewUp.Modules.Purchases;
using static ArchUnitNET.Fluent.ArchRuleDefinition;

namespace BrewUp.Modules.Warehouses.FitnessTests;

public class WarehousesFitnessTests
{
	// Load your architecture once at the start to maximize performance of your tests
	private static readonly Architecture BrewUpArchitecture =
		new ArchLoader().LoadAssemblies(typeof(WarehousesAdapter).Assembly,
			typeof(PurchasesAdapter).Assembly)
			.Build();

	private readonly IObjectProvider<IType> _warehousesModule =
		Types().That().ResideInNamespace("BrewUp.Modules.Warehouses").As("Warehouses Module");

	private readonly IObjectProvider<Class> _warehousesAdapter =
		Classes().That().ImplementInterface("IWarehousesAdapter").As("Warehouses Adapter");

	private readonly IObjectProvider<IType> _purchasesModule =
		Types().That().ResideInNamespace("BrewUp.Modules.Purchases").As("Purchases Module");

	private readonly IObjectProvider<Interface> _purchasesInterfaces =
		Interfaces().That().HaveFullNameContaining("BrewUp.Modules.Purchases").As("Purchases Interfaces");

	[Fact]
	public void TypesShouldBeInCorrectLayer()
	{
		//you can use the fluent API to write your own rules
		IArchRule warehousesClassesShouldBeInWarehousesModule =
			Classes().That().Are(typeof(WarehousesAdapter)).Should().Be(_warehousesModule);
		IArchRule forbiddenInterfacesShouldBeInForbiddenLayer =
			Interfaces().That().Are(_purchasesInterfaces).Should().Be(_purchasesModule);

		//check if your architecture fulfils your rules
		warehousesClassesShouldBeInWarehousesModule.Check(BrewUpArchitecture);
		forbiddenInterfacesShouldBeInForbiddenLayer.Check(BrewUpArchitecture);

		//you can also combine your rules
		IArchRule combinedArchRule =
			warehousesClassesShouldBeInWarehousesModule.And(forbiddenInterfacesShouldBeInForbiddenLayer);
		combinedArchRule.Check(BrewUpArchitecture);
	}

	[Fact]
	public void WarehousesModuleShouldNotAccessPurchasesModule()
	{
		IArchRule warehousesModuleShouldNotAccessPurchasesModule = Types().That().Are(typeof(WarehousesAdapter)).Should()
			.NotDependOnAny(_purchasesModule).Because("it's forbidden");
		warehousesModuleShouldNotAccessPurchasesModule.Check(BrewUpArchitecture);
	}

	[Fact]
	public void PurchasesClassesShouldHaveCorrectName()
	{
		Classes().That().AreAssignableTo(typeof(PurchasesAdapter)).Should().HaveNameContaining("BrewUp.Modules.Purchases")
			.Check(BrewUpArchitecture);
	}

}