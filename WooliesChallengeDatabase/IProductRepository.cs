using System.Collections.Generic;
using System.Threading.Tasks;
using WooliesChallenge.Database.DataModels;

namespace WooliesChallenge.Database
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProducts(string sortOption);
        Task<List<ShopperHistory>> GetShoppersHistory();
    }
}
