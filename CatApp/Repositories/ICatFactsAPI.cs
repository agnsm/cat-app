using CatApp.Models;
using System;
using System.Threading.Tasks;

namespace CatApp.Repositories
{
    public interface ICatFactsAPI
    {
        Task<CatModel> GetRandomFactAsync();
    }
}
