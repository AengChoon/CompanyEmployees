﻿using CompanyEmployees.Core.Domain.Entities;
using CompanyEmployees.Core.Domain.Repositories;

namespace CompanyEmployees.Infrastructure.Persistence.Repositories;

internal sealed class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
{
    public CompanyRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public IEnumerable<Company> GetAllCompanies(bool trackChanges)
    {
        return FindAll(trackChanges).OrderBy(company => company.Name).ToList();
    }
}