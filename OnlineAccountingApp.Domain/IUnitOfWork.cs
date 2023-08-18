using Microsoft.EntityFrameworkCore;

namespace OnlineAccountingApp.Domain
{
	public interface IUnitOfWork
	{
		void CreateDbContextInsatnce(DbContext context);
		Task<int> SaveChangesAsync();
	}
}
