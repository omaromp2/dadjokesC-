using System.Net.Http.Json;
using System.Text.Json;
using Newtonsoft.Json; 

internal class Program
{
    private static async Task Main(string[] args)
    {
        // Greeting 
        Console.WriteLine("Hello, I shall fetch you a joke!");

        // Http Client 
        var client = new HttpClient();
        client.DefaultRequestHeaders.Add("Accept", "application/json");
        var result = client.GetAsync("https://icanhazdadjoke.com").Result;

        //Check resp 
        if (result.IsSuccessStatusCode)
        {
            var dadJokeJson = result.Content.ReadAsStringAsync().Result;
            dynamic dadJokeData = JsonConvert.DeserializeObject(dadJokeJson);
            string dadjoke = dadJokeData.joke;

            Console.WriteLine(dadjoke); 

        }
        else
        {
            Console.WriteLine("Oops! Unable to joke at the moment");
        }



    }

}