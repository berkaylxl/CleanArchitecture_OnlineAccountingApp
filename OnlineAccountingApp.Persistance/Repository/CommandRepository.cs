using Microsoft.EntityFrameworkCore;
using OnlineAccountingApp.Domain.Abstractions;
using OnlineAccountingApp.Domain.Repositories;
using OnlineAccountingApp.Persistance.Context;

namespace OnlineAccountingApp.Persistance.Repository
{
	public class CommandRepository<T> : ICommandRepository<T> where T : Entity
	{
		private static readonly Func<CompanyDbContext, string, Task<T>> GetById =
			EF.CompileAsyncQuery((CompanyDbContext context, string id) =>
			context.Set<T>().FirstOrDefault(p => p.Id == id));

		private CompanyDbContext _context;
		public DbSet<T> Entity { get; set; }

		DbSet<T> IRepository<T>.Entity { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public void CreateDbContextInsatnce(DbContext context)
		{
			_context = (CompanyDbContext)context;
			Entity = _context.Set<T>();
		}
		public async Task AddAsync(T entity)
		{
			await Entity.AddAsync(entity);
		}

		public async Task AddRangeAsync(IEnumerable<T> entities)
		{
			await Entity.AddRangeAsync(entities);
		}

		public void Remove(T entity)
		{
			Entity.Remove(entity);
		}

		public async Task RemoveById(string id)
		{
			T entity = await GetById(_context, id);
			Remove(entity);
		}

		public void RemoveRange(IEnumerable<T> entities)
		{
			Entity.RemoveRange(entities);
		}

		public void Update(T entity)
		{
			Entity.Update(entity);
		}

		public void UpdateRAnge(IEnumerable<T> entities)
		{
			Entity.UpdateRange(entities);
		}
	}
}
