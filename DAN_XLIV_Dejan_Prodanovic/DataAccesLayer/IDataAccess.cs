using DataAccesLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer
{
    interface IDataAccess
    {
        void AddOrder(Order order);
        void DeleteOrder(int id);
        void ApproveOrder(int id);
        List<Order> GetOrdersOfGuest(string JMBG);
    }
}
