using TSA.Core.Application.Repositories.Common;
using TSA.Core.Application.Rules;

namespace TSA.Core.Application.Services.CompanyService.Rules;

public class CompanyBusinessRules(IUnitOfWork unitOfWork) : BaseBusinessRules
{
    private async Task CheckIfCompanyExists(string companyName)
    {
        var company = await unitOfWork.CompanyRepository.GetAsync(x => x.Name == companyName);
        return;
    }
}