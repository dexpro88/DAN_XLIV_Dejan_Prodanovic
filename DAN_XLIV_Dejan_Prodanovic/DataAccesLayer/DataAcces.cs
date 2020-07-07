using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccesLayer.Model;

namespace DataAccesLayer
{
    class DataAcces : IDataAccess
    {
        static List<Order> orders = new List<Order>();

        public void AddOrder(Order order)
        {
            orders.Add(order);
        }

        public void ApproveOrder(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteOrder(int id)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetOrdersOfGuest(string JMBG)
        {
            List<Order> returnList = new List<Order>();
            foreach (var order in orders)
            {
                if (order.JMBG.Equals(JMBG))
                {
                    returnList.Add(order);
                }
            }
            returnList.Sort((x, y) => DateTime.Compare(x.DateAndTimeOfOrder, y.DateAndTimeOfOrder));

            return returnList;
        }


    }
}
