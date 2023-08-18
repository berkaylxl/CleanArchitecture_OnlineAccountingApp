using Microsoft.EntityFrameworkCore;
using OnlineAccountingApp.Domain;
using OnlineAccountingApp.Persistance.Context;

namespace OnlineAccountingApp.Persistance
{
	public sealed class UnitOfWork : IUnitOfWork
	{
		private CompanyDbContext _context;
		public void CreateDbContextInsatnce(DbContext context)
		{
			_context = (CompanyDbContext)context;
		}

		public async Task<int> SaveChangesAsync()
		{
			 return await _context.SaveChangesAsync();
		}
	}
}
