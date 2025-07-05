using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceSytsem
{
    public class CheckoutResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public double Subtotal { get; set; }

        public double ShippingFees { get; set; }

        public double PaidAmount { get; set; }
        
        public double CustomerNewBalance { get; set; }

        public string ShippmentNotice { get; set; }

        public string Receipt { get; set; }
    }
}
