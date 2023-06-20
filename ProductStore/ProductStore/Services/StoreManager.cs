using System;
using System.Collections.Generic;
using System.Linq;
using ProductStore.Adapters;
using ProductStore.Factories;
using static System.Formats.Asn1.AsnWriter;

namespace ProductStore.Services
{
    class StoreManager
    {
        private Store store;  //шаблонът Singleton
        private IProductTarget productTarget;
        private IProductCreator productCreator; // Добавяме интерфейс за Factory Method

        public StoreManager()
        {
            store = Store.GetInstance();  //шаблонът Singleton
            productTarget = new ProductAdapter(store.GetAllProducts());
            productCreator = new PhoneCreator(); // Използваме Factory Method 
        }

        public void InitializeStore()
        {
            store.Initialize();
        }

        public void DisplayStoreProducts()
        {
            productTarget.DisplayProducts();
        }

        public Dictionary<string, decimal> GetStoreProductPrices()
        {
            return productTarget.GetProductPrices();
        }

        public bool IsProductAvailable(string productName, int quantity)
        {
            var product = store.GetProductByName(productName) as Product;
            if (product != null && product.Quantity >= quantity)
            {
                return true;
            }
            return false;
        }

        public void RemoveProductQuantity(string productName, int quantity)
        {
            var product = store.GetProductByName(productName) as Product;
            if (product != null)
            {
                product.Quantity -= quantity;
            }
        }

        // Factory Method, използван в метода AddProduct
        private Product CreateProduct()
        {
            return productCreator.CreateProduct();
        }
    }
}
