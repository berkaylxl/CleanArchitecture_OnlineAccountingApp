using Microsoft.EntityFrameworkCore;
using OnlineAccountingApp.Domain.Abstractions;

namespace OnlineAccountingApp.Domain.Repositories
{
	public interface IRepository<T> where T: Entity
	{
		void CreateDbContextInsatnce(DbContext context);
		DbSet<T> Entity { get; set; }
	}
}
