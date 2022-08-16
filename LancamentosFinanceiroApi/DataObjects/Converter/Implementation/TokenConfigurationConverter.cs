using LancamentosFinanceiroApi.Configurations;
using LancamentosFinanceiroApi.DataObjects.Converter.Contract;

namespace LancamentosFinanceiroApi.DataObjects.Converter.Implementation
{
    public class TokenConfigurationConverter : ITokenConfiguration<TokenConfigurationDTO, TokenConfiguration>, ITokenConfiguration<TokenConfiguration, TokenConfigurationVO>
    {
        public TokenConfiguration Parse(TokenConfigurationDTO origin)
        {
            if (origin == null) return null;

            return new TokenConfiguration
            {

                Audience = origin.Audience,

                Issuer = origin.Issuer,

                Secret = origin.Secret,

                Minutes = origin.Minutes,

                DaysToExpiry = origin.DaysToExpiry


            };
        }

        public List<TokenConfiguration> Parse(List<TokenConfigurationDTO> origin)
        {
            if (origin == null) return null;

            return origin.Select(item => Parse(item)).ToList();
        }

        public TokenConfigurationVO Parse(TokenConfiguration origin)
        {

            if (origin == null) return null;

            return new TokenConfigurationVO
            {

                Audience = origin.Audience,

                Issuer = origin.Issuer,

                Secret = origin.Secret,

                Minutes = origin.Minutes,

                DaysToExpiry = origin.DaysToExpiry


            };




    }


        public List<TokenConfigurationVO> Parse(List<TokenConfiguration> origin)
        {
            if (origin == null) return null;

            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
