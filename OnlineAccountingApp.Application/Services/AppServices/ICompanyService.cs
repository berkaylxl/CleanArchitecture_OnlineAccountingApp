using OnlineAccountingApp.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;
using OnlineAccountingApp.Domain.AppEntities;

namespace OnlineAccountingApp.Application.Services.AppServices
{
    public  interface ICompanyService
    {
        Task CreateCompany(CreateCompanyRequest request);
        Task<Company?> GetCompanyByName(string name);    
    }
}
