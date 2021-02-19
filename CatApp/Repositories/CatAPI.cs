using CatApp.Models;
using Newtonsoft.Json.Linq;
using System;
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
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("x-api-key", "0b1d77f0-fe78-46b8-8695-017f68141fc2");
        }

        private async Task<CatModel> GetRandomAsync(string query, int minWidth, int minHeight)
        {
            CatModel randomCat = new CatModel();
            HttpResponseMessage response;
            JArray jsonResult;
            string result;
            int width, height;
            do
            {
                response = await client.GetAsync(query);
                result = await response.Content.ReadAsStringAsync();
                jsonResult = JArray.Parse(result);
                width = (int)jsonResult.First["width"];
                height = (int)jsonResult.First["height"];
            } while (width < minWidth || height < minHeight);

            var url = jsonResult.First["url"];
            randomCat.Url = (string)url;
            return randomCat;
        }

        public async Task<CatModel> GetRandomImageAsync()
        {
            string query = "v1/images/search?mime_types=jpg,png";
            int minWidth = 500;
            int minHeight = 300;
            var result = await GetRandomAsync(query, minWidth, minHeight);
            return result;
        }

        public async Task<CatModel> GetRandomGifAsync()
        {
            string query = "v1/images/search?mime_types=gif";
            int minWidth = 500;
            int minHeight = 200;
            var result = await GetRandomAsync(query, minWidth, minHeight);
            return result;
        }
    }
}
