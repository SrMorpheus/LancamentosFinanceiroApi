namespace LancamentosFinanceiroApi.Configurations
{
    public class TokenConfigurationVO
    {

        public string Audience { get; set; }

        public string Issuer { get; set; }

        public string Secret { get; set; }


        public int Minutes { get; set; }

        public int DaysToExpiry { get; set; }


    }
}
