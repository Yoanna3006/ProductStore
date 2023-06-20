using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStore.Adapters
{
    class ProductAdapter : IProductTarget
    {
        private List<Product> products;

        public ProductAdapter(List<Product> products)
        {
            this.products = products;
        }

        public void DisplayProducts()
        {
            foreach (var product in products)
            {
                Console.WriteLine($"Product: {product.Name}, Price: {product.Price}, Quantity: {product.Quantity}");
            }
        }

        public Dictionary<string, decimal> GetProductPrices()
        {
            var productPrices = new Dictionary<string, decimal>();
            foreach (var product in products)
            {
                productPrices.Add(product.Name, product.Price);
            }
            return productPrices;
        }
    }


}
