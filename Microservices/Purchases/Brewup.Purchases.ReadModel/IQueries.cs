using System.Linq.Expressions;
using Brewup.Purchases.ReadModel.Entities;

namespace Brewup.Purchases.ReadModel
{
	public interface IQueries<T> where T : EntityBase
	{
		Task<T> GetById(string id);
		Task<PagedResult<T>> GetByFilter(Expression<Func<T, bool>> query, int page, int pageSize);
	}
}
