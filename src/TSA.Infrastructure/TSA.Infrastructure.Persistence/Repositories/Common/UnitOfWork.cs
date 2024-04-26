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
        OperationClaimRepository = new OperationClaimRepository(_context);
        UserOperationClaimRepository = new UserOperationClaimRepository(_context);
        UserRepository = new UserRepository(_context);
        RefreshTokenRepository = new RefreshTokenRepository(_context);
    }
    public ICompanyRepository CompanyRepository { get; private set; }
    public IOperationClaimRepository OperationClaimRepository { get; private set; }
    public IUserOperationClaimRepository UserOperationClaimRepository { get; private set; }
    public IUserRepository UserRepository { get; private set; }
    public IRefreshTokenRepository RefreshTokenRepository { get; private set; }
}