using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceSytsem
{
    public class EcommerceSystem
    {

        private List<Product> _products =new List<Product>();

        private ShippingService _shippingService = new ShippingService();

        public void AddProduct (Product product)
        {

            if(product == null)
            {
                throw new Exception("Invalid Product");
            }

            _products.Add(product);
        }


        // assume el name unique 

        public Product GetProduct(string name)
        {

            return _products.FirstOrDefault(p => p.Name == name);

        }


        public CheckoutResult Checkout(Customer customer,ShoppingCart cart)
        {
            var result = new CheckoutResult();
            result.Success = false;

            if(cart.IsEmpty())
            {
                result.Message = "Cart is empty . cant checkout";
                return result;
            }

            foreach (var item in cart.Items)
            {
                var productFounded=GetProduct(item.Product.Name);

                if(productFounded is null)
                {
                    result.Message = $" Product {item.Product.Name} not found ";
                    return result;
                }

                if(productFounded.IsOutOfStock()|| productFounded.StockQuantity<item.Quantity)
                {
                    result.Message = $" Product {item.Product.Name} is out of stock ";
                    return result;
                }

                if (productFounded.IsExpired())
                {
                    result.Message = $"Product  {item.Product.Name} is expired";
                }


            }

            double subtotal = cart.SubTotal();

            List<ShippedItem> shippedItems = cart.Items

                .Where(i => i.Product.CanBeShipped)
                .Select(i => (i.Product, i.Quantity))
                .Select(p => new ShippedItem(p.Product, p.Quantity))
                .ToList();

            double shippingFees = _shippingService.CalculateShippingFee(shippedItems);

            double paidAmount = subtotal + shippingFees;

            if (customer.Balance < paidAmount)
            {
                result.Message = $"Customer {customer.Name} has insufficient  {customer.Balance} need {paidAmount} to checkout ";
                return result;
            }

            try
            {
                foreach (var item in cart.Items)
                {
                    item.Product.DecreaseStock(item.Quantity);

                }

                double customerBalance=customer.Balance-paidAmount;
                customer.AfterPaying(paidAmount);

                string shipmentNotice=_shippingService.ShipmentNotice(shippedItems);

                StringBuilder recipt= new StringBuilder();
                recipt.AppendLine("** Checkout receipt **");

                foreach (var item in cart.Items)
                {
                    recipt.AppendLine($"{item.Quantity}x {item.Product.Name}      {item.GetTotalItemPrice()}");

                }

                recipt.AppendLine("----------------------");
                recipt.AppendLine($"Subtotal      {subtotal}");
                recipt.AppendLine($"Shipping      {shippingFees}");
                recipt.AppendLine($"Amount      {paidAmount}");

                result.Success= true;
                result.Message = $"Checkout for {customer.Name} completed successfully";
                result.Subtotal=subtotal;
                result.ShippmentNotice=shipmentNotice;
                result.CustomerNewBalance=customerBalance;
                result.Receipt = recipt.ToString();
                result.PaidAmount = paidAmount;
                result.ShippingFees=shippingFees;





                return result;
            }
            catch (Exception ex)
            {
                result.Message= $"Checkout Failed due to {ex.Message} ";
                return result;
                
            }

        }


    }
}
