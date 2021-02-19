using CatApp.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CatApp.Repositories
{
    public class CatFactsAPI : ICatFactsAPI
    {
        private readonly HttpClient client;

        public CatFactsAPI()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://catfact.ninja/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        private async Task<CatModel> GetRandomAsync(string query)
        {
            CatModel randomCat = new CatModel();

            HttpResponseMessage response = await client.GetAsync(query);
            string result = await response.Content.ReadAsStringAsync();
            JObject jsonResult = JObject.Parse(result);
            var fact = jsonResult["fact"];
            randomCat.Text = (string)fact;
            return randomCat;
        }

        public async Task<CatModel> GetRandomFactAsync()
        {
            string query = "fact?max_length=140";
            var result = await GetRandomAsync(query);
            return result;
        }
    }
}
