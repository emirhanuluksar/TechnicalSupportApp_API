using TSA.Core.Application.Repositories.Common;
using TSA.Core.Domain.Entities;

namespace TSA.Core.Application.Repositories;

public interface ICompanyRepository : IAsyncRepository<Company, Guid>, IRepository<Company, Guid>
{
    Task<ICollection<Company>> SearchCompaniesAsync(string search, CancellationToken cancellationToken = default);
}