using LancamentosFinanceiroApi.DataObjects.VO;
using LancamentosFinanceiroApi.Models;

namespace LancamentosFinanceiroApi.Services.Contract
{
    public interface ILoginService
    {

        TokenVO ValidateCredentials(LoginDTO login);

        TokenVO ValidateCredentials(TokenVO token);

        bool RevokeToken(string username);




    }
}
