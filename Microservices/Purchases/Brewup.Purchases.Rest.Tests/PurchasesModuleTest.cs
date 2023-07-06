using Brewup.Purchases.ApplicationService.BindingModels;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace Brewup.Purchases.Rest.Tests;

[Collection("Integration Fixture")]
public class PurchasesModuleTest
{
	private readonly AppHttpClientFixture _integrationFixture;

	public PurchasesModuleTest(AppHttpClientFixture integrationFixture)
	{
		_integrationFixture = integrationFixture;
	}

	[Fact]
	public async Task Cannot_Send_InvalidJson()
	{
		var body = new Order
		{
			SupplierId = Guid.Empty,
			Date = DateTime.Now,
			Lines = new List<OrderLine>
			{
				new()
				{
					ProductId = Guid.NewGuid(),
					Title = "Muflone IPA",
					Quantity = new Quantity
					{
						Value = 10,
						UnitOfMeasure = "Lt"
					},
					Price = new Price
					{
						Value = 10,
						Currency = "EUR"
					}
				}
			}
		};

		var stringJson = JsonSerializer.Serialize(body);
		var httpContent = new StringContent(stringJson, Encoding.UTF8, "application/json");
		var postResult = await _integrationFixture.Client.PostAsync("/api/v1/Order", httpContent);

		Assert.Equal(HttpStatusCode.BadRequest, postResult.StatusCode);
	}

	[Fact]
	public async Task Should_Send_ValidJson()
	{
		var body = new Order
		{
			SupplierId = Guid.NewGuid(),
			Date = DateTime.Now,
			Lines = new List<OrderLine>
			{
				new()
				{
					ProductId = Guid.NewGuid(),
					Title = "Muflone IPA",
					Quantity = new Quantity
					{
						Value = 10,
						UnitOfMeasure = "Lt"
					},
					Price = new Price
					{
						Value = 10,
						Currency = "EUR"
					}
				}
			}
		};

		var stringJson = JsonSerializer.Serialize(body);
		var httpContent = new StringContent(stringJson, Encoding.UTF8, "application/json");
		var postResult = await _integrationFixture.Client.PostAsync("/api/v1/Order", httpContent);

		Assert.Equal(HttpStatusCode.Created, postResult.StatusCode);
	}
}