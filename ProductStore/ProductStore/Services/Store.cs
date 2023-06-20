using ProductStore.Factories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductStore.Services
{
    class Store
    {
        //шаблонът Singleton
        private static Store instance;
        private List<Product> products;

        private Store()
        {
            products = new List<Product>();
        }

        public static Store GetInstance()
        {
            if (instance == null)
            {
                instance = new Store();
            }
            return instance;
        }


        public void Initialize()
        {
            products.Add(new PhoneCreator().CreateProduct());
            products.Add(new LaptopCreator().CreateProduct());
            products.Add(new HeadphonesCreator().CreateProduct());
            products.Add(new TVCreator().CreateProduct());
        }

        public void DisplayProducts()
        {
            foreach (var product in products)
            {
                Console.WriteLine($"Product: {product.Name}, Price: {product.Price}, Quantity: {product.Quantity}");
            }
        }

        public bool IsProductAvailable(string productName, int quantity)
        {
            var product = products.FirstOrDefault(p => p.Name == productName);
            if (product == null)
                return false;

            return product.Quantity >= quantity;
        }

        public void RemoveProductQuantity(string productName, int quantity)
        {
            var product = products.FirstOrDefault(p => p.Name == productName);
            if (product != null)
                product.Quantity -= quantity;
        }

        internal Product GetProductByName(string productName)
        {
            return products.FirstOrDefault(p => p.Name == productName);
        }
        public List<Product> GetAllProducts()
        {
            return products;
        }
    }
}
