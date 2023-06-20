using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStore.Adapters
{
    public interface IProductTarget
    {
        void DisplayProducts();
        Dictionary<string, decimal> GetProductPrices();
    }
}
