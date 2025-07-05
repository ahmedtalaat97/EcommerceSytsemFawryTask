using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceSytsem
{
    public class Customer
    {

        public string Name { get; private set; }

        public double Balance { get; private set; }

        public Customer(string name , double initBalance)
        { 
            Name = name;
            Balance = initBalance;
        }


        public void AfterPaying(double amount)
        {
            if (Balance < amount) { throw new Exception("Insufficient balance."); }

            Balance-=amount;
        }


       
    }
}
