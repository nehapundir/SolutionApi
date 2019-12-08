using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WooliesChallenge.Business;
using WooliesChallenge.Business.Models;
using WooliesChallenge.Database;
using WooliesChallengeBusiness;

namespace WooliesChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourceController : ControllerBase
    {
        private IUserService _userService;
        private IProductService _productService;
        private ITrolleyService _trolleyService;

        private string userToken = "76f8d8e2-5b0f-43cc-a840-3309f0175de4";
        public ResourceController(IUserService userService,IProductService productService, ITrolleyService trolleyService)
        {
            _userService = userService;
            _productService = productService;
            _trolleyService = trolleyService;
        }

        [Route("User")]
        [HttpGet]
        public IActionResult GetUserToken()
        {
            var userName = "neha";
            if (!String.IsNullOrEmpty(userName))
            {
                var result = _userService.GetUserToken(userName);
                if (result == null)
                {
                    return NotFound(userName);
                }
                return Ok(result);
            }
            else
            {
                return NotFound(userName);
            }
        }

        [HttpGet("sort")]
        public IActionResult Sort([FromQuery] string sortOption)
        {            
            IList<ProductDto> products = new List<ProductDto>();
            
            return RedirectToActionPermanent("GetProducts", new { sortOption = sortOption });
            
        }

        [HttpGet("products")]
        public async Task<IActionResult> GetProducts([FromQuery] string sortOption)
        {
            IList<ProductDto> products = new List<ProductDto>();

            if (sortOption == nameof(SortOptions.Recommended))
            {
                return RedirectToActionPermanent("GetShopperHistory");
            }
            products = await _productService.GetProducts(sortOption);

            return Ok(products);
        }

        [HttpGet("shopperHistory")]
        public async Task<IEnumerable<ProductDto>> GetShopperHistory()
        {
            IList<ShopperHistoryDto> shopperHistoryDtos = new List<ShopperHistoryDto>();
            shopperHistoryDtos = await _productService.GetShoppersHistory();
            Dictionary<string, ProductDto> dictionary = new Dictionary<string, ProductDto>();
            foreach (var history in shopperHistoryDtos)
            {
                foreach (var product in history.Products)
                {
                    if (dictionary.ContainsKey(product.Name)) {
                        dictionary[product.Name].Quantity += product.Quantity;
                    }
                    else
                    {
                        dictionary.Add(product.Name, product);
                    }
                }
            }
            List<ProductDto> products = dictionary.Values.OrderBy(p => p.Quantity).ToList();
            return products;
        }

        [HttpPost("trolleyTotal")]
        public decimal TrolleyCalculator([FromQuery]string token, [FromBody] TrolleyDto trolley)
        {  
            var total = _trolleyService.CalculatePrice(trolley);
            return total;
        }        
    }
}
