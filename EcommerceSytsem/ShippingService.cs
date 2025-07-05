using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceSytsem
{
    public class ShippingService 
    {

        private const double ShippingFee = 30;
        private const double WeightPerKilo = 5;

        public double CalculateShippingFee(List<ShippedItem> items)
        {
            if(items==null || items.Count<=0) return 0;


            double totalWeightinGm = items.Sum(i=>i.GetWeight());

            double totalWeightinKg = totalWeightinGm / 1000;
            if(totalWeightinKg > 1)
            {
                return ShippingFee + (totalWeightinKg * WeightPerKilo);
            }

            return ShippingFee;
           
            
        }


        public string ShipmentNotice(List<ShippedItem> items)
        {

            if(items ==null || items.Count<=0) return string.Empty;


            StringBuilder notice = new StringBuilder();
            notice.AppendLine("** Shipment notice **");
            double totalWeightinGm = 0;
            foreach(ShippedItem item in items)
            {
                notice.AppendLine($"{item.GetName()}      {item.GetWeight()}g ");
                totalWeightinGm += item.GetWeight();


            }

            notice.AppendLine($"Total package weight {totalWeightinGm/1000}kg");


            return notice.ToString();
        }


    }
}
