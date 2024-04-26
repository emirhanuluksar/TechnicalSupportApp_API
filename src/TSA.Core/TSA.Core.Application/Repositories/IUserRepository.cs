using TSA.Core.Application.Repositories.Common;
using TSA.Infrastructure.Security.Entities;

namespace TSA.Core.Application.Repositories;

public interface IUserRepository : IAsyncRepository<User, Guid>, IRepository<User, Guid>
{

}