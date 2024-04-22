using BlueGrassDigitalAPI.Interface;
using BlueGrassDigitalAPI.Models.Person;
using Newtonsoft.Json;
using System.Net.Http;

namespace BlueGrassDigitalAPI.Logic
{
    public class Person : IPerson
    {
        private static readonly HttpClient _httpClient = new HttpClient();

            public async Task<List<PersonResponse>> GetAllPerson()
            {
                try
                {

                    var request = new HttpRequestMessage
                    {
                        Method = HttpMethod.Get,
                        RequestUri = new Uri("https://us-east-1.aws.webhooks.mongodb-realm.com/api/client/v2.0/app/testing-skqpg/service/myProfileApi/incoming_webhook/GetProducts")
                    };
                    using var response = await _httpClient.SendAsync(request);
                    var body = await response.Content.ReadAsStringAsync();

                    // Deserialize the JSON to a single PokemonImages object
                    List<PersonResponse> people = JsonConvert.DeserializeObject<List<PersonResponse>>(body);

                    return people;

                }
                catch (Exception ex)
                {
                    throw;
                }
            

        }
    }
}
