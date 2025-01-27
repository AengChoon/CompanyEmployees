using AutoMapper;
using CompanyEmployees.Core.Domain.Entities;
using Shared.DataTransferObjects;

namespace CompanyEmployees;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Company, CompanyDto>().ForCtorParam("FullAddress", expression =>
        {
            expression.MapFrom(company => $"{company.Address} {company.Country}");
        });
    }
}