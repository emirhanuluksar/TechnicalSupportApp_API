using TSA.Core.Application.Repositories.Common;
using TSA.Infrastructure.Security.Entities;

namespace TSA.Core.Application.Services.UserService;

public class UserManager(IUnitOfWork unitOfWork) : IUserService
{
    public Task<User> AddAsync(User user)
    {
        return unitOfWork.UserRepository.AddAsync(user);
    }

    public async Task<User> GetUserById(Guid userId)
    {
        return await unitOfWork.UserRepository.GetAsync(u => u.Id == userId);
    }
}