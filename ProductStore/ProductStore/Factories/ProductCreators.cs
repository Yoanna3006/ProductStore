using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStore.Factories
{
    class PhoneCreator : IProductCreator
    {
        public Product CreateProduct()
        {
            return new Phone { Name = "Phone", Price = 500, Quantity = 7 };
        }
    }

    class LaptopCreator : IProductCreator
    {
        public Product CreateProduct()
        {
            return new Laptop { Name = "Laptop", Price = 1000, Quantity = 20 };
        }
    }

    class HeadphonesCreator : IProductCreator
    {
        public Product CreateProduct()
        {
            return new Headphones { Name = "Headphones", Price = 100, Quantity = 15 };
        }
    }

    class TVCreator : IProductCreator
    {
        public Product CreateProduct()
        {
            return new TV { Name = "TV", Price = 1500, Quantity = 1 };
        }
    }
}
