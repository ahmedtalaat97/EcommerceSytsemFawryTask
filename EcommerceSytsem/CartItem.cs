using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceSytsem
{
    public class CartItem
    {

        public Product Product { get; private set; }

        public int Quantity { get; private set; }

        public CartItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

       
        public double GetTotalItemPrice()
        {
            return Product.Price*Quantity;
        }


    }
}
