using Brewup.Purchases.Infrastructure.MongoDb.Readmodel;
using Brewup.Purchases.ReadModel;
using Brewup.Purchases.ReadModel.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;
using Muflone.Eventstore.Persistence;

namespace Brewup.Purchases.Infrastructure.MongoDb
{
    public static class MongoDBHelpers
	{
		public static IServiceCollection AddMongoDb(this IServiceCollection services,
			MongoDbSettings mongoDbSettings)
		{
			services.AddSingleton<IMongoDatabase>(x =>
			{
				BsonDefaults.GuidRepresentation = GuidRepresentation.Standard;

				//BsonClassMap.RegisterClassMap<Enumeration>(cm =>
				//{
				//  cm.SetIsRootClass(true);
				//  cm.MapMember(m => m.Id);
				//  cm.MapMember(m => m.Name);
				//});
				//BsonClassMap.RegisterClassMap<SeatState>(cm =>
				//{
				//  cm.MapCreator(c => new SeatState(c.Id, c.Name));
				//});

				var client = new MongoClient(mongoDbSettings.ConnectionString);
				var database = client.GetDatabase(mongoDbSettings.DatabaseName);
				return database;
			});
			services.AddScoped<IPersister, Persister>();
			services.AddScoped<IPurchaseOrderService, PurchaseOrderService>();
			services.AddSingleton<IEventStorePositionRepository>(x =>
				new EventStorePositionRepository(x.GetService<ILogger<EventStorePositionRepository>>(), mongoDbSettings));

			return services;
		}
	}
}
