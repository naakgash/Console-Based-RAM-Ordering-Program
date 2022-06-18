using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderCLI
{
    internal class Customer
    {
        private string _name;
        private string _surname;
        private string _tcNumber;
        private string _gsmNumber;
        private string _address;
        public int Id { get; set; }
        public string TcNumber {
            get { return _tcNumber; }
            set // Checking the entered TC number
            {
                if (value.Length != 11 || !IsAllDigit(value)) // Checking the entered TC number
                    throw new Exception();
                _tcNumber = value;
            }
        }
        public string Name {
            get { return _name;  }
            set // Checking the entered name
            {
                if (!(value.Length >= 3 && value.Length <= 15) || !IsAllLetter(value)) 
                    throw new Exception();
                _name = value;
            } 
        }
        public string Surname {
            get { return _surname; }
            set // Checking the entered surname
            {
                if (!(value.Length >= 3 && value.Length <= 15) || !IsAllLetter(value)) 
                    throw new Exception();
                _surname = value;
            } 
        }
        public string GsmNumber {
            get { return _gsmNumber; }
            set // Checking the entered gsm number
            {
                if (value.Length != 10 || !IsAllDigit(value))
                    throw new Exception();
                _gsmNumber = value;
            }
        }
        public string Address {
            get { return _address; }
            set // Checking the entered address
            {
                if (value.Length <= 25)
                    throw new Exception();
                _address = value;
            }
        }
        private bool IsAllLetter(string str)
        {
            bool flag = true;
            char[] chr = str.ToCharArray();
            for(int i = 0; i < chr.Length; i++)
            {
                if(!(chr[i] is >= 'a' and <= 'z' or >= 'A' and <= 'Z'))
                    flag = false;
            }
            return flag;
        }
        public static bool IsAllDigit(string str)
        {
            bool flag = true;
            char[] chr = str.ToCharArray();
            for (int i = 0; i < chr.Length; i++)
            {
                if (chr[i] < '0' || chr[i] > '9')
                    flag = false;
            }
            return flag;
        }
    }
}
