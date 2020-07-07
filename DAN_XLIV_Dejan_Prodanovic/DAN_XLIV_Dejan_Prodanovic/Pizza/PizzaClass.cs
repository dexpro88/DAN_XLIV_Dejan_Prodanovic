using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAN_XLIV_Dejan_Prodanovic.Pizza
{
    class PizzaClass
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }

        public PizzaClass()
        {

        }

        public PizzaClass(string name, decimal price)
        {
            Name = name;
            Price = price;
            Amount = 22;
        }
    }
}
