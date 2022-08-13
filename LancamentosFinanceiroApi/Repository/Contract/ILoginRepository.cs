using LancamentosFinanceiroApi.Models;

namespace LancamentosFinanceiroApi.Repository.Contract
{
    public interface ILoginRepository
    {
        Login ValidateCredentials(Login login);

        Login ValidateCredentials(string username);

        bool RevokeToken(string username);

        Login RefreshLoginInfo(Login login);




    }
}
