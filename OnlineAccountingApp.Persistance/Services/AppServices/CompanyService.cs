using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineAccountingApp.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;
using OnlineAccountingApp.Application.Services.AppServices;
using OnlineAccountingApp.Domain.AppEntities;
using OnlineAccountingApp.Persistance.Context;

namespace OnlineAccountingApp.Persistance.Services.AppServices
{
    public sealed class CompanyService : ICompanyService
    {
        private static readonly Func<AppDbContext, string, Task<Company?>>
            GetCompanyByNameCompiled =
                EF.CompileAsyncQuery((AppDbContext context, string name) =>
                     context.Set<Company>().FirstOrDefault(x => x.Name == name));
            
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CompanyService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateCompany(CreateCompanyRequest request)
        {
            var company = _mapper.Map<Company>(request);
            company.Id =Guid.NewGuid().ToString();
            await _context.Set<Company>().AddAsync(company);
            await _context.SaveChangesAsync();
        }

        public async Task<Company?> GetCompanyByName(string name)
        {
            return await GetCompanyByNameCompiled(_context, name);
        }
    }
}
