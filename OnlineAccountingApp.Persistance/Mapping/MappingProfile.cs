using AutoMapper;
using OnlineAccountingApp.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;
using OnlineAccountingApp.Domain.AppEntities;

namespace OnlineAccountingApp.Persistance.Mapping
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<CreateCompanyRequest, Company>().ReverseMap();
        }
    }
}
