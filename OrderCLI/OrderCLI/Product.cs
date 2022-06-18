using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderCLI
{
    internal class Product
    {
        private int _stock;
        public int Id { get; set; }
        public string Trademark { get; set; }
        public string Type { get; set; }
        public string Capacity { get; set; }
        public string Canal { get; set; }
        public string Frequency { get; set; }
        public string Color { get; set; }
        public int Stock {
            get { return _stock; }
            set { _stock = value; } 
        }
        public double Price { get; set; }
        public void DecrementStock (int quantity)
        {
            _stock = _stock - quantity;
        }
        public bool CheckStock(int quantity)
        {
            if(_stock > 0 && _stock >= quantity)
                return true;
            else return false;
        }

    }
}
