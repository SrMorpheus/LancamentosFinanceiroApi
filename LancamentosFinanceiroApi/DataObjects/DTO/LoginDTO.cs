namespace LancamentosFinanceiroApi.Models
{
    public class LoginDTO
    {

      
        public long Id { get; set; }

        public string UserName { get; set; }
   
        public string Password { get; set; }
     
        public string RefreshToken { get; set; }

        public DateTime RefreshTokenExpiryTibe { get; set; }


        public LoginDTO() { }

        public LoginDTO(string userName, string password, string refreshToken, DateTime refreshTokenExpiryTibe)
        {
            
            UserName = userName;
            Password = password;
            RefreshToken = refreshToken;
            RefreshTokenExpiryTibe = refreshTokenExpiryTibe;
        }
    }
}
