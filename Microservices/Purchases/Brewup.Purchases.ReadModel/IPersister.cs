using Brewup.Purchases.ReadModel.Entities;

namespace Brewup.Purchases.ReadModel
{
	public interface IPersister
	{
		Task<T> GetBy<T>(string id) where T : EntityBase;
		Task Insert<T>(T entity) where T : EntityBase;
		Task Update<T>(T entity) where T : EntityBase;
		Task Delete<T>(T entity) where T : EntityBase;
	}
}