using System.Collections.Generic;
using System.Threading.Tasks;
using WooliesChallenge.Business.Models;
using WooliesChallenge.Database;

namespace WooliesChallenge.Business
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<ProductDto>> GetProducts(string sortOption)
        {
            return AutoMapperConfig.Mapper.Map<List<ProductDto>>(await _productRepository.GetProducts(sortOption));
        }

        public async Task<List<ShopperHistoryDto>> GetShoppersHistory()
        {
            return AutoMapperConfig.Mapper.Map<List<ShopperHistoryDto>>(await _productRepository.GetShoppersHistory());
        }
    }
}
