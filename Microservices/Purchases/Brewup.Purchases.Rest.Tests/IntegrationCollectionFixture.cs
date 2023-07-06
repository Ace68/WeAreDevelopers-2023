using Xunit;

namespace Brewup.Purchases.Rest.Tests;

[CollectionDefinition("Integration Fixture")]
public abstract class IntegrationCollectionFixture : ICollectionFixture<AppHttpClientFixture>
{
}