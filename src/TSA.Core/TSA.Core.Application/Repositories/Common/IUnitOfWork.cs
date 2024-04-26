namespace TSA.Core.Application.Repositories.Common;

public interface IUnitOfWork
{
    ICompanyRepository CompanyRepository { get; }
    IOperationClaimRepository OperationClaimRepository { get; }
    IUserOperationClaimRepository UserOperationClaimRepository { get; }
    IUserRepository UserRepository { get; }
    IRefreshTokenRepository RefreshTokenRepository { get; }
}