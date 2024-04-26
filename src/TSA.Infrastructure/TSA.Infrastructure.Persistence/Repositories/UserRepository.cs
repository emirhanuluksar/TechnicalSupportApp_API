using TSA.Core.Application.Repositories;
using TSA.Infrastructure.Persistence.Contexts;
using TSA.Infrastructure.Persistence.Repositories.Common;
using TSA.Infrastructure.Security.Entities;

namespace TSA.Infrastructure.Persistence.Repositories;

public class UserRepository : EfRepositoryBase<User, Guid, TSADbContext>, IUserRepository
{
    public UserRepository(TSADbContext dbContext) : base(dbContext)
    {
    }
}