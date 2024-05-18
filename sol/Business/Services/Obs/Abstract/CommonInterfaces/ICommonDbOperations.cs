using System.Linq.Expressions;

namespace Business.Services.Obs.Abstract.CommonInterfaces;

public interface ICommonDbOperations <T>
{
	bool Any(Expression<Func<T, bool>> filter);
	T Get(Expression<Func<T, bool>> filter);
	T Add(T entity);
	T Update(T entity);
	bool Remove(T entity);
	List<T> GetList(Expression<Func<T, bool>>? filter = null);
}