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
		new ArchLoader().LoadAssemblies(typeof(WarehousesFacade).Assembly,
			typeof(PurchasesFacade).Assembly)
			.Build();

	private readonly IObjectProvider<IType> _warehousesModule =
		Types().That().ResideInNamespace("BrewUp.Modules.Warehouses").As("Warehouses Module");

	private readonly IObjectProvider<Class> _warehousesFacade =
		Classes().That().ImplementInterface("IWarehousesAdapter").As("Warehouses Facade");

	private readonly IObjectProvider<IType> _purchasesModule =
		Types().That().ResideInNamespace("BrewUp.Modules.Purchases").As("Purchases Module");

	private readonly IObjectProvider<Interface> _purchasesInterfaces =
		Interfaces().That().HaveFullNameContaining("BrewUp.Modules.Purchases").As("Purchases Interfaces");

	[Fact]
	public void TypesShouldBeInCorrectLayer()
	{
		IArchRule warehousesClassesShouldBeInWarehousesModule =
			Classes().That().Are(typeof(WarehousesFacade)).Should().Be(_warehousesModule);
		IArchRule forbiddenInterfacesShouldBeInForbiddenLayer =
			Interfaces().That().Are(_purchasesInterfaces).Should().Be(_purchasesModule);

		// check if your architecture fulfils your rules
		warehousesClassesShouldBeInWarehousesModule.Check(BrewUpArchitecture);
		forbiddenInterfacesShouldBeInForbiddenLayer.Check(BrewUpArchitecture);

		// combine rules
		IArchRule combinedArchRule =
			warehousesClassesShouldBeInWarehousesModule.And(forbiddenInterfacesShouldBeInForbiddenLayer);
		combinedArchRule.Check(BrewUpArchitecture);
	}

	[Fact]
	public void WarehousesModuleShouldNotAccessPurchasesModule()
	{
		IArchRule warehousesModuleShouldNotAccessPurchasesModule = Types().That().Are(typeof(WarehousesFacade)).Should()
			.NotDependOnAny(_purchasesModule).Because("it's forbidden");
		warehousesModuleShouldNotAccessPurchasesModule.Check(BrewUpArchitecture);
	}

	[Fact]
	public void PurchasesClassesShouldHaveCorrectName()
	{
		Classes().That().AreAssignableTo(typeof(IPurchasesFacade)).Should().HaveNameContaining("BrewUp.Modules.Purchases")
			.Check(BrewUpArchitecture);
	}

}