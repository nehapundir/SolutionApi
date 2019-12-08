using System.Collections.Generic;
using System.Linq;
using WooliesChallenge.Business.Models;

namespace WooliesChallenge.Business
{
    public class TrolleyService : ITrolleyService
    {
        public decimal CalculatePrice(TrolleyDto trolley)
        {
            decimal finalSum = 0;
            
            // Calculate max price
            foreach (var quantity in trolley.Quantities)
            {
                //find the product price
                var product = trolley.Products.Where(p => p.Name == quantity.Name).FirstOrDefault();

                if (product != null)
                {
                    product.Quantity += quantity.Quantity;
                    finalSum += product.Price * quantity.Quantity;
                }
            }
            
            //loop over all the offers
            foreach (var special in trolley.Specials)
            {                
                var doesSpecialApply = true;
                Dictionary<ProductDto, int> products = new Dictionary<ProductDto, int>();
                foreach (var quantity in special.Quantities)
                {
                    var product = trolley.Products.Where(p => p.Name == quantity.Name && p.Quantity > 0).FirstOrDefault();
                    if(product != null)
                    {
                        products.Add(product, quantity.Quantity);
                        if (product.Quantity < quantity.Quantity) {
                            doesSpecialApply = false;
                        }
                    }
                    else
                    {
                        doesSpecialApply = false;
                    }
                }
                if (doesSpecialApply)
                {
                    decimal currentSum = 0;
                    foreach (var product in trolley.Products.Where(p => p.Quantity > 0))
                    {

                        if (products.ContainsKey(product))
                        {
                            currentSum += (product.Quantity - products[product]) * product.Price;
                        }
                        else
                        {
                            currentSum += product.Quantity * product.Price;
                        }
                        
                    }
                    currentSum += special.Total;
                    if (finalSum > currentSum) {
                        finalSum = currentSum;
                    }
                }
                
            }
            return finalSum;
        }
    }
}
