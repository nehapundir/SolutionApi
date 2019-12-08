using System.Collections.Generic;

namespace WooliesChallenge.Business.Models
{
    public class ShopperHistoryDto
    {
        public int CustomerId { get; set; }
        public List<ProductDto> Products { get; set; }
    }
}
