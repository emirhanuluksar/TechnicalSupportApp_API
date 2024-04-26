using TSA.Core.Application.Repositories.Common;
using TSA.Core.Application.Rules;
using TSA.Core.Application.Services.AuthService.Constants;
using TSA.Infrastructure.Infrastructure.CrossCuttingConcerns.Exception.Types;
using TSA.Infrastructure.Security.Entities;
using TSA.Infrastructure.Security.Helpers.HashingHelpers;

namespace TSA.Core.Application.Services.AuthService.Rules;

public class AuthBusinessRules(IUnitOfWork unitOfWork) : BaseBusinessRules
{
    public async Task<User> GetUserByUserName(string username)
    {
        var user = await unitOfWork.UserRepository.GetAsync(u => u.Username == username);
        if (user is null)
            throw new BusinessException(AuthMessages.UserNotFound);
        return user;
    }

    public async Task UserPasswordShouldBeMatch(Guid id, string password)
    {
        User? user = await unitOfWork.UserRepository.GetAsync(predicate: u => u.Id == id, enableTracking: true);
        if (user is not null && !HashingHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            throw new BusinessException(AuthMessages.PasswordDontMatch);
    }

    internal async Task UserShouldNotBeExist(string userName)
    {
        User? user = await unitOfWork.UserRepository.GetAsync(predicate: u => u.Username == userName, enableTracking: true);
        if (user != null)
            throw new BusinessException(AuthMessages.UserNameAlreadyExists);
    }
}