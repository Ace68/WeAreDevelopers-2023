using ArchUnitNET.Domain;
using ArchUnitNET.Fluent;
using ArchUnitNET.Loader;
using ArchUnitNET.xUnit;
using static ArchUnitNET.Fluent.ArchRuleDefinition;

namespace BrewUp.Modules.Purchases.FitnessTests;

public class PurchasesFitnessTests
{
	private static readonly Architecture Architecture = new ArchLoader().LoadAssemblies(typeof(IPurchasesOrchestrator).Assembly).Build();

	private readonly IObjectProvider<IType> _purchasesModule =
		Types().That().ResideInAssembly("Brewup.Modules.Purchases").As("Purchases Module");

	private readonly IObjectProvider<Class> _purchasesClasses =
		Classes().That().ImplementInterface("IPurchasesOrchestrator").As("Purchases Classes");

	private readonly IObjectProvider<IType> _forbiddenModule = Types().
		That().
		ResideInNamespace("Brewup.Modules.Warehouse").
		As("Forbidden Layer");

	private readonly IObjectProvider<IType> _forbiddenLayer = Types().
		That().
		ResideInNamespace("BrewUp.Modules.Warehouses").
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

		forbiddenInterfacesShouldBeInForbiddenLayer.Check(Architecture);
	}

	[Fact]
	public void TypesShouldBeInCorrectModule()
	{
		IArchRule exampleClassesShouldBeInSalesModule =
			Classes().That().Are(_purchasesClasses).Should().Be(_purchasesModule);
		IArchRule forbiddenInterfacesShouldBeInForbiddenLayer =
			Interfaces().That().Are(_forbiddenInterfaces).Should().Be(_forbiddenModule);

		//check if your architecture fulfills your rules
		exampleClassesShouldBeInSalesModule.Check(Architecture);
		forbiddenInterfacesShouldBeInForbiddenLayer.Check(Architecture);

		//you can also combine your rules
		IArchRule combinedArchRule =
			exampleClassesShouldBeInSalesModule
				.And(forbiddenInterfacesShouldBeInForbiddenLayer);

		combinedArchRule.Check(Architecture);
	}
}