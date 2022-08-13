using LancamentosFinanceiroApi.Data.Context;
using LancamentosFinanceiroApi.Models;
using LancamentosFinanceiroApi.Repository.Contract;
using System.Security.Cryptography;
using System.Text;

namespace LancamentosFinanceiroApi.Repository.Implementations
{
    public class LoginRepositoryImplementations : ILoginRepository
    {
        private readonly FinancaContextoAPI _context;

        public LoginRepositoryImplementations(FinancaContextoAPI context)
        {

            _context = context;

        }

        public Login ValidateCredentials(Login login)
        {

            var pass = ComputeHash(login.Password, new SHA256CryptoServiceProvider());

            return _context.Logins.FirstOrDefault(u => (u.UserName == login.UserName) && (u.Password == pass));

        }

        private string ComputeHash(string password, SHA256CryptoServiceProvider algoritm)
        {

            Byte[] inputBytes = Encoding.UTF8.GetBytes(password);

            Byte[] hashedBytes = algoritm.ComputeHash(inputBytes);


            return BitConverter.ToString(hashedBytes);



        }

        public Login RefreshLoginInfo(Login login)
        {


            if (!_context.Logins.Any(L => L.Id.Equals(login.Id))) return null;

            var result = _context.Logins.SingleOrDefault(L => L.Id.Equals(login.Id));

            if (result != null)
            {
                try
                {

                    _context.Entry(result).CurrentValues.SetValues(login);
                    _context.SaveChanges();
                    return result;


                }
                catch (Exception)
                {
                    throw;

                }


            }


            return result;



        }

        public Login ValidateCredentials(string username)
        {

            return _context.Logins.SingleOrDefault(u => (u.UserName == username));


        }

        public bool RevokeToken(string username)
        {

            var user = _context.Logins.SingleOrDefault(u => (u.UserName == username));

            if (user is null) return false;

            user.RefreshToken = null;

            _context.SaveChanges();

            return true;



        }
    }

}
