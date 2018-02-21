using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace PokeInfo
{
    public  class WebRequest
    {
        public static async Task GetPokeInfoAsync (int pokeid, Action<Pokemon> Callback)
        {
            HttpClient client = new HttpClient();
            try{
                // client.BaseAddress = new Uri($"http://pokeapi.co/api/v2/pokemon/{pokeid}");
                // HttpResponseMessage response = await client.GetAsync("");
                // string strresponse = await response.Content.ReadAsStringAsync();
                Task<string> response = client.GetStringAsync($"http://pokeapi.co/api/v2/pokemon/{pokeid}");
                string strresponse = await response;
                Console.WriteLine(strresponse);
                JObject Jpokemon = JsonConvert.DeserializeObject<JObject>(strresponse);
                Pokemon pokemon = new Pokemon{
                    Name = Jpokemon["name"].Value<string>(),
                    Weight = Jpokemon["weight"].Value<long>(),
                    Height = Jpokemon["height"].Value<long>(),
                    Types = Jpokemon["types"].Value<JArray>()

                };
                Callback(pokemon);
            }
            catch(HttpRequestException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
    
}