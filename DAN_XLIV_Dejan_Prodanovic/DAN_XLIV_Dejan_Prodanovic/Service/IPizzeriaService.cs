using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAN_XLIV_Dejan_Prodanovic.Service
{
    interface IPizzeriaService
    {
        tblOrder AddOrder(tblOrder order);
        tblPizzaOrder AddPizzaOrder(tblPizzaOrder pizzaOrder);

        void DeleteOrder(int id);
        void ApproveOrder(int id);
        List<tblOrder> GetOrdersOfGuest(string JMBG);
        List<tblOrder> GetOrders();
        List<tblPizzaOrder> GetPizzaOrdersByOrderID(int orderId);

        List<tblPizza> GetPizzas();
        tblOrder GetOrderByID(int id);
        void EditOrder(tblOrder order);


    }
}
