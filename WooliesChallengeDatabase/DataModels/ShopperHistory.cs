using System.Collections.Generic;

namespace WooliesChallenge.Database.DataModels
{
    public class ShopperHistory
    {
        public int CustomerId { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
