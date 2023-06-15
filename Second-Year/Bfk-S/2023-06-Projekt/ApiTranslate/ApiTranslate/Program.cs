using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Net.Http;
//Muss auf Schulrechnern als NuGet-Package kommen
using System.Text.Json;


namespace ApiTranslate
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What would you like to translate?");
            translate(Console.ReadLine());
            Console.ReadKey();
        }
        static async void translate(string whatToTranslate)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://google-translate1.p.rapidapi.com/language/translate/v2"),
                Headers =
                {
                    //Key eindeutig nach Anmeldung bei RapidAPI
                    { "X-RapidAPI-Key", "Bitte eigenen Key auf rapidapi generieren :-)" },
                    { "X-RapidAPI-Host", "google-translate1.p.rapidapi.com" },
                },
                Content = new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    { "source", "en" },
                    { "target", "de" },
                    { "q", $"{whatToTranslate}" },
                }),
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var t = await response.Content.ReadAsStringAsync();
                Console.WriteLine(t);
                var tm = JsonSerializer.Deserialize<TranslationResponse>(t);
                for (int i =0; i< tm.data.translations.Count; i++)
                {
                    Console.WriteLine(tm.data.translations[i].translatedText);
                }
                
                
            }
        }
    }
}
