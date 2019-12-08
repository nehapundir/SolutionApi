using System.Collections.Generic;
using System.Threading.Tasks;
using WooliesChallenge.Business.Models;

namespace WooliesChallenge.Business
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetProducts(string sortOption);

        Task<List<ShopperHistoryDto>> GetShoppersHistory();
    }
}
