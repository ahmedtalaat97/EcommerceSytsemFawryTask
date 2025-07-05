using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceSytsem
{
    public class Product
    {

        public string Name { get; set; }
        public double Price { get; private set; }
        public int StockQuantity { get; private set; }
        public bool CanBeShipped { get; private set; }
        public double Weight { get; private set; }
        public bool CanExpire { get; private set; }
        public DateTime? ExpiryDate { get; private set; }



        public Product(string name, double price, int stockQuantity, bool canBeShipped, bool canExpire = false, DateTime? expiryDate = null, double weight = 0)
        {
            Name = name;
            Price = price;
            StockQuantity = stockQuantity;
            CanBeShipped = canBeShipped;
            Weight = weight;
            CanExpire = canExpire;
            ExpiryDate = expiryDate;
        }



        // m7tag a check 3ala el quantity w date


        public bool IsOutOfStock()
        {
            return StockQuantity <= 0;
        }

        public bool IsExpired()
        {
            return (CanExpire && ExpiryDate.HasValue && ExpiryDate.Value < DateTime.Today);
        }


        //hazawd product aw an2as


        public void DecreaseStock(int quantity)
        {

            if (StockQuantity < quantity)
            {
                throw new Exception($"not enough stock for {Name} available");

            }

            if (quantity < 0)
            {
                throw new Exception($"Please enter a postive number this  {quantity} is not valid ");


            }

            StockQuantity -= quantity;


        }

        public void IncreaseStock(int quantity)
        {

            if (quantity < 0)
            {
                throw new Exception($"Please enter a postive number this  {quantity} is not valid ");


            }
            StockQuantity += quantity;

        }
    }
}
