using System;
using ProductStore.Adapters;
using ProductStore.Strategies;

namespace ProductStore
{
    class ShoppingCart
    {
        private List<Product> products;
        private IDiscountStrategy discountStrategy;
        private ProductAdapter productAdapter;

        public ShoppingCart()
        {
            products = new List<Product>();
            productAdapter = new ProductAdapter(products);
        }

        public void SetDiscountStrategy(IDiscountStrategy strategy)
        {
            discountStrategy = strategy;
        }

        public void AddProduct(Product product, int quantity)
        {
            products.Add(product);
            product.Quantity = quantity;
        }

        public void CalculateTotalPrice()
        {
            decimal totalPrice = 0;
            foreach (var product in products)
            {
                var quantity = product.Quantity;
                totalPrice += product.Price * quantity;
            }

            if (discountStrategy != null)
            {
                decimal discount = discountStrategy.CalculateDiscount(totalPrice);
                totalPrice -= discount;
            }

            Console.WriteLine($"Total Price: {Math.Round(totalPrice, 2):F2}");
            Console.WriteLine("Пълна количка с продукти:");
            productAdapter.DisplayProducts();
            Console.WriteLine();
        }
    }

}
