using Microsoft.EntityFrameworkCore;
using OnlineAccountingApp.Domain.Abstractions;

namespace OnlineAccountingApp.Domain.Repositories
{
	public interface ICommandRepository<T> : IRepository<T> where T : Entity
	{
		Task AddAsync(T entity);
		Task AddRangeAsync(IEnumerable<T> entities);
		void Update(T entity);
		void UpdateRAnge(IEnumerable<T> entities);
		Task RemoveById(string id);
		void Remove(T entity);
		void RemoveRange(IEnumerable<T> entities);
	}
}
