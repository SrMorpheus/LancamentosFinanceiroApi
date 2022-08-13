using LancamentosFinanceiroApi.DataObjects.Converter.Contract;
using LancamentosFinanceiroApi.Models;

namespace LancamentosFinanceiroApi.DataObjects.Converter.Implementation
{
    public class LoginConverter : ILogin<LoginDTO, Login>, ILogin<Login, LoginVO>
    {
        public Login Parse(LoginDTO origin)
        {
            return new Login
            {

                UserName = origin.UserName,

                Password = origin.Password,

                RefreshToken = origin.RefreshToken,

                RefreshTokenExpiryTibe = origin.RefreshTokenExpiryTibe

            };
        }

        public List<Login> Parse(List<LoginDTO> origin)
        {
            if (origin == null) return null;

            return origin.Select(item => Parse(item)).ToList();
        }

        public LoginVO Parse(Login origin)
        {
            if (origin == null) return null;

            return new LoginVO
            {
                Id = origin.Id,

                UserName = origin.UserName,

                Password = origin.Password,

                RefreshToken = origin.RefreshToken,

                RefreshTokenExpiryTibe = origin.RefreshTokenExpiryTibe

             };

        }

        public List<LoginVO> Parse(List<Login> origin)
        {
            if (origin == null) return null;

            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
