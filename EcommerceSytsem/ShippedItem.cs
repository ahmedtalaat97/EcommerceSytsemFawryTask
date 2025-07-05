using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceSytsem
{
    public class ShippedItem : IShipped
    {
        public Product Product {  get; private set; }
        public int Quantity { get; private set; }

        public ShippedItem(Product product, int quantity)
        {
            if(!product.CanBeShipped)
            {
                throw new Exception($"this product  {product.Name} cant be shipped");
            }

            Product = product;
            Quantity = quantity;
        }



        public string GetName()
        {
            return $" {Quantity}x {Product.Name}";
        }

        public double GetWeight()
        {
            return Product.Weight* Quantity;
        }
    }
}
