using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderCLI
{
    internal class Order
    {
        public int Id { get; set; }
        public double TotalPrice { get; set; }
        public int Quantity { get; set; }
        public string CustomerTcNumber { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public string CustomerGsmNumber { get; set; }
        public string CustomerAdress { get; set; }
        public string ProductTrademark { get; set; }
        public string ProductType { get; set; }
        public string ProductCapacity { get; set; }
        public string ProductCanal { get; set; }
        public string ProductFrequency { get; set; }
        public string ProductColor { get; set; }
    }
}
