using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appliances
{
    public class Appliance
    {
        private string _code;
        private string _manufacturer;
        private string _type;
        private double _price;
        private double _consumption;
        private string _efficiency;
        private int _quantity;

        public string Code
        {
            get { return _code; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Code cannot be null or empty");
                _code = value;
            }
        }
        public string Manufacturer
        {
            get { return _manufacturer; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Manufacturer cannot be null or empty");
                _manufacturer = value;
            }
        }
        public string Type
        {
            get { return _type; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Type cannot be null or empty");
                _type = value;
            }
        }
        public double Price {
            get { return _price; }
            set
            {
                if (value < 0)

                    throw new ArgumentException("Price cannot be less than 0");
                _price = value;
            }
        }
        public double Consumption {
            get { return _consumption; }
            set
            {
                if (value < 0)

                    throw new ArgumentException("Consumption cannot be less than 0");
                _consumption = value;
            }
        }
        public string Efficiency
        {
            get { return _efficiency; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Efficiency cannot be null or empty");
                _efficiency = value;
            }
        }
        public int Quantity
        {
            get { return _quantity; }
            set
            {
                if (value < 0)

                    throw new ArgumentException("Quantity cannot be less than 0");
                _quantity = value;
            }
        }

        public Appliance(string c, string m, string t, double p, double cons, string e, int q)
        {
            Code = c;
            Manufacturer = m;
            Type = t;
            Price = p;
            Consumption = cons;
            Efficiency = e;
            Quantity = q;
        }
        public double CalculateEnergyEfficiecy()
        {
            switch (Efficiency)
            {
                case "A++":
                    return 1.0;
                case "A+":
                    return 1.2;
                case "A":
                    return 1.5;
                case "B":
                    return 2.0;
                case "C":
                    return 2.5;
                default: return 3.0;
            }
        }
    }
}
