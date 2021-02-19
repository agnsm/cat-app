using CatApp.Models;
using System;
using System.Threading.Tasks;

namespace CatApp.Repositories
{
    public interface ICatAPI
    {
        Task<CatModel> GetRandomImageAsync();
        Task<CatModel> GetRandomGifAsync();
    }
}
