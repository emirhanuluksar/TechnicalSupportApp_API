using TSA.Core.Application.Repositories;
using TSA.Core.Domain.Entities;
using TSA.Infrastructure.Persistence.Contexts;
using TSA.Infrastructure.Persistence.Repositories.Common;

namespace TSA.Infrastructure.Persistence.Repositories;

public class CompanyRepository : EfRepositoryBase<Company, Guid, TSADbContext>, ICompanyRepository
{
    public CompanyRepository(TSADbContext dbContext) : base(dbContext)
    {
    }
}