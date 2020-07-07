using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Model
{
    class PizzaOrder
    {
        public int ID { get; set; }
        public Pizza Pizza { get; set; }
        public int Amount { get; set; }
 
    }
}
