using TSA.Core.Application.Repositories;
using TSA.Core.Application.Repositories.Common;
using TSA.Infrastructure.Persistence.Contexts;

namespace TSA.Infrastructure.Persistence.Repositories.Common;

public class UnitOfWork : IUnitOfWork
{
    private readonly TSADbContext _context;

    public UnitOfWork(TSADbContext context)
    {
        _context = context;
        CompanyRepository = new CompanyRepository(_context);
    }
    public ICompanyRepository CompanyRepository { get; private set; }
}