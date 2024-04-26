using TSA.Infrastructure.Security.Entities;

namespace TSA.Core.Application.Services.UserService;

public interface IUserService
{
    Task<User> AddAsync(User user);
    Task<User> GetUserById(Guid userId);
}