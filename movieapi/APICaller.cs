using System.Threading.Tasks;
using System.Net.Http;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using movieapi.Models;
using System.Collections.Generic;
namespace movieapi
{
    public class WebRequest
    {
        public static async Task GetInfoForMovies(string name, Action<Movie> Callback)
        {
            HttpClient client = new HttpClient();
            try
            {
                Task<string> response = client.GetStringAsync($"https://api.themoviedb.org/3/search/movie?api_key=4ee05c998b055e3192a2b7c0ad6813f5&query={name}");
                string result = await response;
                // Console.WriteLine(result);
                JObject JMoive = JsonConvert.DeserializeObject<JObject>(result);
                Movie movie = new Movie{
                    Name = (string)JMoive["results"][0]["original_title"],
                    Rate =  (float)JMoive["results"][0]["vote_average"],
                    Released_date =  (string)JMoive["results"][0]["release_date"] 
                };
                // Console.WriteLine(movie.Name);
                Callback(movie);
            }
            catch(HttpRequestException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}