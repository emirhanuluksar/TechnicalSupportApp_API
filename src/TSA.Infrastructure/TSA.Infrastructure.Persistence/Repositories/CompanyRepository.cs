using Microsoft.EntityFrameworkCore;
using TSA.Core.Application.Repositories;
using TSA.Core.Domain.Entities;
using TSA.Infrastructure.Persistence.Contexts;
using TSA.Infrastructure.Persistence.Repositories.Common;

namespace TSA.Infrastructure.Persistence.Repositories;

public class CompanyRepository : EfRepositoryBase<Company, Guid, TSADbContext>, ICompanyRepository
{
    private readonly TSADbContext _dbContext;
    public CompanyRepository(TSADbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ICollection<Company>> SearchCompaniesAsync(string search, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Companies
            .Where(c => c.Name.Contains(search))
            .ToListAsync(cancellationToken);
    }
}