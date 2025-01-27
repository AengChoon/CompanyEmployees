using CompanyEmployees.Core.Domain.Repositories;
using CompanyEmployees.Core.Services.Abstractions;
using LoggingService;
using Shared.DataTransferObjects;

namespace CompanyEmployees.Core.Services;

internal sealed class CompanyService : ICompanyService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;

    public CompanyService(IRepositoryManager repository, ILoggerManager logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public IEnumerable<CompanyDto> GetAllCompanies(bool trackChanges)
    {
        try
        {
            var companies = _repository.Company.GetAllCompanies(trackChanges);

            var companiesDto = companies.Select(company =>
            {
                return new CompanyDto
                (
                    company.Id,
                    company.Name ?? string.Empty,
                    string.Join(' ', company.Address, company.Country)
                );
            }).ToList();
            
            return companiesDto;
        }
        catch (Exception e)
        {
            _logger.LogError($"Something went wrong in the {nameof(GetAllCompanies)} service method {e}");
            throw;
        }    
    }
}