using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Model
{
    public class Order
    {
        public int ID { get; set; }
        public DateTime DateAndTimeOfOrder { get; set; }
        public string JMBG { get; set; }
        public string Status { get; set; }
        public List<PizzaOrder> PizzaOrders { get; set; }

    }
}
