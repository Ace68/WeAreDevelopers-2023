using System.Linq.Expressions;
using BrewUp.Warehouses.ReadModel.Entities;

namespace BrewUp.Warehouses.ReadModel;

public interface IQueries<T> where T : EntityBase
{
	Task<T> GetByIdAsync(string id);
	Task<PagedResult<T>> GetByFilterAsync(Expression<Func<T, bool>>? query, int page, int pageSize);
}