using LancamentosFinanceiroApi.ServicesAPI.DogAPI.model;
using System.Text.Json;

namespace LancamentosFinanceiroApi.ServicesAPI.DogAPI.Service
{
    public class GetDog
    {


        private readonly HttpClient _client;



        public GetDog(HttpClient httpClient)
        {

            _client = httpClient;
        
        }


        public async Task<DogImage> ProcessDog ()
        {

            try
            {

                var streamTask = _client.GetStreamAsync("api/breeds/image/random");

                var retorno = await JsonSerializer.DeserializeAsync<DogImage>(await streamTask);

                return retorno;


            }catch (HttpRequestException)
            {

                return null;


            }

        }




    }
}
