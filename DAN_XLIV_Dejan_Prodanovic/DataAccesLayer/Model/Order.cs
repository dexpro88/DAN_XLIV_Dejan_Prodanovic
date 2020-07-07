using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Model
{
    class Order
    {
        public int ID { get; set; }
        public DateTime DateAndTimeOfOrder { get; set; }
        public string JMBG { get; set; }
        public string Status { get; set; }
        public List<Order> GetPizzaOrders { get; set; }

    }
}
