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
        List<tblPizzaOrder> GetOrdersOfGuest(string JMBG);
        List<tblPizzaOrder> GetOrders();

        List<tblPizza> GetPizzas();

    }
}
