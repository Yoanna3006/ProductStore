using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStore.Strategies
{
    class BlackFridayDiscountStrategy : IDiscountStrategy
    {
        public decimal CalculateDiscount(decimal price)
        {
            return price * 0.2m; // 20% отстъпка
        }
    }
}
