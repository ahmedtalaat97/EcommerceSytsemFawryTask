using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceSytsem
{
    public class ShoppingCart
    {
        public List<CartItem> Items { get; private set; }=new List<CartItem>();
           
        
        public void AddItem(Product product, int quantity)
        {
            if (product == null) throw new Exception("product cannot be null");

            if (quantity < 0) throw new Exception("quantity cannot be negative");

            if(product.IsOutOfStock())
            {
                throw new Exception($"product {product.Name} is out of stock");

            }

            if(product.IsExpired())
            {
                throw new Exception($"product {product.Name} is expired");
            }
            if(product.StockQuantity<quantity)
            {
                throw new Exception($"product {product.Name} is out of stock");
            }

            var exist = Items.FirstOrDefault(i => i.Product.Name == product.Name);

            if (exist != null)
            {
                int newQuantity=exist.Quantity+quantity;
                
                if(product.StockQuantity < newQuantity)
                {
                    throw new Exception($"cannot add {quantity} for {product.Name} will exceed the stock amount");
                }

                Items.Remove(exist);
                Items.Add(new CartItem(product, newQuantity)); 

            }
            else
            {
                Items.Add(new CartItem(product, quantity));
            }

        }

        public double SubTotal()
        {
            return Items.Sum(i => i.GetTotalItemPrice());
        }

        public bool IsEmpty()
        {
            return Items.Count == 0;
        }
    }
}
