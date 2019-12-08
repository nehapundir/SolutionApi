using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WooliesChallenge.Database.DataModels;


namespace WooliesChallenge.Database
{
    public class ProductRepository: IProductRepository
    {       
        
        private async Task<List<Product>> GetProductsData()
        {
            List<Product> products = new List<Product>();
            HttpClient client = new HttpClient();
            var path = "http://dev-wooliesx-recruitment.azurewebsites.net/api/resource/products?token=76f8d8e2-5b0f-43cc-a840-3309f0175de4";
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                products = await response.Content.ReadAsAsync<List<Product>>();
            }
            return products;            
        }
        private async Task<List<ShopperHistory>> GetShoppersHistoryData()
        {
            List<ShopperHistory> shoppersHistory = new List<ShopperHistory>();
            
            HttpClient client = new HttpClient();
            var path = "http://dev-wooliesx-recruitment.azurewebsites.net/api/resource/shopperHistory?token=76f8d8e2-5b0f-43cc-a840-3309f0175de4";
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                shoppersHistory = await response.Content.ReadAsAsync<List<ShopperHistory>>();
            }
            return shoppersHistory;           

        }

        public async Task<List<Product>> GetProducts(string sortOption)
        {
           var products = await GetProductsData();
            SortOptions options = SortOptions.None;
            if (!string.IsNullOrEmpty(sortOption))
            {
                Enum.TryParse(sortOption, out options);
            }
            
            if (products.Any())
            {
                switch(options)
                {
                    case SortOptions.Low:
                        products = products.OrderBy(p => p.Price).ToList();
                        break;
                    case SortOptions.High:
                        products = products.OrderByDescending(p => p.Price).ToList();
                        break;
                    case SortOptions.Ascending:
                        products = products.OrderBy(p => p.Name).ToList();
                        break;
                    case SortOptions.Descending:
                        products = products.OrderByDescending(p => p.Name).ToList();
                        break;
                    default:
                        break;
                }

            }
            return products;
        }

        public async Task<List<ShopperHistory>> GetShoppersHistory()
        {
            return await GetShoppersHistoryData();
        }
    }
}
