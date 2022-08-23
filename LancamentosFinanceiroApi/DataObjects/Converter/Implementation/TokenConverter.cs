using LancamentosFinanceiroApi.DataObjects.Converter.Contract;
using LancamentosFinanceiroApi.DataObjects.VO;

namespace LancamentosFinanceiroApi.DataObjects.Converter.Implementation
{
    public class TokenConverter : IToken<TokenDTO, TokenVO>, IToken<TokenVO, TokenDTO>
    {
        public TokenDTO Parse(TokenVO origin)
        {
            if (origin == null) return null;


            return new TokenDTO
            {
                Authenticated = origin.Authenticated,   

                Mensagem = origin.Mensagem,

                Created = origin.Created,

                Expiration = origin.Expiration,

                AccessToken = origin.AccessToken,

                RefreshToken = origin.RefreshToken,


            };




        }

        public List<TokenDTO> Parse(List<TokenVO> origin)
        {
            if (origin == null) return null;

            return origin.Select(item => Parse(item)).ToList();
        }

        public TokenVO Parse(TokenDTO origin)
        {
            if (origin == null) return null;


            return new TokenVO
            {
                Authenticated = origin.Authenticated,

                Mensagem = origin.Mensagem,

                Created = origin.Created,

                Expiration = origin.Expiration,

                AccessToken = origin.AccessToken,

                RefreshToken = origin.RefreshToken,


            };


        }

        public List<TokenVO> Parse(List<TokenDTO> origin)
        {
            if (origin == null) return null;

            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
