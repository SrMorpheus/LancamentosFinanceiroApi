using System.Text.Json.Serialization;

namespace LancamentosFinanceiroApi.DataObjects.VO
{
    public class TokenDTO
    {


        public bool Authenticated { get; set; }


        [JsonIgnore]
        public  string? Mensagem { set; get; }
        public string Created { get; set; }

        public string Expiration { get; set; }

        public string AccessToken { get; set; }

        public string RefreshToken { get; set; }


        public TokenDTO() { }

        public TokenDTO(bool authenticated, string mensagem, string created, string expiration, string accessToken, string refreshToken)
        {
            Authenticated = authenticated;

            Mensagem = mensagem;

            Created = created;

            Expiration = expiration;

            AccessToken = accessToken;

            RefreshToken = refreshToken;
        }
    }
}
