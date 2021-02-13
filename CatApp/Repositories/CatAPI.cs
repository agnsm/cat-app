using CatApp.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CatApp.Repositories
{
    public class CatAPI : ICatAPI
    {
        private readonly HttpClient client;

        public CatAPI()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://api.thecatapi.com/");
            client.DefaultRequestHeaders.Add("x-api-key", "0b1d77f0-fe78-46b8-8695-017f68141fc2");
            //client.DefaultRequestHeaders.Accept.Clear();
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        /*public async Task<string> GetRandomImageAsync()
        {
            HttpResponseMessage response = await client.GetAsync("v1/images/search?mime_types=jpg,png");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            Console.WriteLine(result);
            var jsonResult = JArray.Parse(result);
            var url = jsonResult.First["url"];
            return url.ToString();
        }*/

        public async Task<CatModel> GetRandomImageAsync()
        {
            var randomImage = new CatModel();
            HttpResponseMessage response;
            JArray jsonResult;
            string result;
            int width, height;
            do
            {
                response = await client.GetAsync("v1/images/search");
                response.EnsureSuccessStatusCode();
                result = await response.Content.ReadAsStringAsync();
                Console.WriteLine(result);
                jsonResult = JArray.Parse(result);
                width = (int)jsonResult.First["width"];
                height = (int)jsonResult.First["height"];
            } while (height < 500 || width < 500);

            var url = jsonResult.First["url"];
            randomImage.Url = (string)url;
            return randomImage;
        }
    }
}
