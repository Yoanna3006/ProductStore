using System;

namespace ProductStore
{
    abstract class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }

    class Phone : Product { }
    class Laptop : Product { }
    class Headphones : Product { }
    class TV : Product { }
}
