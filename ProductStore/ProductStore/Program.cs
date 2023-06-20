using ProductStore.Factories;
using ProductStore.Services;
using ProductStore.Strategies;
using System;

namespace ProductStore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Продукти в магазина:");

            var storeManager = new StoreManager();  //шаблонът Dependency Injection (внедряване на зависимости)
            storeManager.InitializeStore();
            storeManager.DisplayStoreProducts();

            var cart = new ShoppingCart();
            cart.SetDiscountStrategy(new BlackFridayDiscountStrategy());  //шаблонът Strategy (стратегия за отстъпка)

            bool addToCart = true;
            while (addToCart)
            {
                Console.WriteLine("Изберете продукт от магазина, като въведете името му. За да приключите покупката въведете 'край'. ");
                var input = Console.ReadLine();

                if (input.ToLower() == "край")
                {
                    addToCart = false;
                }
                else
                {
                    Product product = null;

                    if (input == "Phone")
                    {
                        product = new PhoneCreator().CreateProduct();
                    }
                    else if (input == "Laptop")
                    {
                        product = new LaptopCreator().CreateProduct();
                    }
                    else if (input == "Headphones")
                    {
                        product = new HeadphonesCreator().CreateProduct();
                    }
                    else if (input == "TV")
                    {
                        product = new TVCreator().CreateProduct();
                    }

                    if (product != null)
                    {
                        Console.WriteLine("Въведете желано количество: ");
                        var quantityInput = Console.ReadLine();
                        if (int.TryParse(quantityInput, out int quantity))
                        {
                            if (storeManager.IsProductAvailable(product.Name, quantity))
                            {
                                cart.AddProduct(product, quantity);
                                storeManager.RemoveProductQuantity(product.Name, quantity);
                                Console.WriteLine($"{quantity} броя от {product.Name} са добавени в кошницата.");
                            }
                            else
                            {
                                Console.WriteLine($"Недостатъчно количество от {product.Name} в магазина.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Невалидно количество!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Невалиден продукт!");
                    }
                }
            }

            cart.CalculateTotalPrice();

            Console.WriteLine("Благодарим за поръчката! Заповядайте отново при нас!");
        }
    }
}
