using System.Collections.Generic;

namespace WooliesChallenge.Business.Models
{
    public class TrolleyDto
    {
        public IList<ProductDto> Products { get; set; }

        public IList<SpecialDto> Specials { get; set; }

        public IList<QuantityDto> Quantities { get; set; }
    }

    public class SpecialDto
    {
        public IList<QuantityDto> Quantities { get; set; }
        public decimal Total { get; set; }
    }

    public class QuantityDto
    {
        public string Name { get; set; }

        public int Quantity { get; set; }
    }
}
