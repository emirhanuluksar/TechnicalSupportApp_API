namespace TSA.Core.Application.Repositories.Common;

public interface IUnitOfWork
{
    ICompanyRepository CompanyRepository { get; }
}