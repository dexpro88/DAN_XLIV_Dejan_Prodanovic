using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAN_XLIV_Dejan_Prodanovic.Service
{
    class PizzeriaService : IPizzeriaService
    {
        public tblOrder AddOrder(tblOrder order)
        {
            try
            {
                using (PizzeriaDBEntities context = new PizzeriaDBEntities())
                {

                    tblOrder newOrder = new tblOrder();
                    newOrder.JMBG = order.JMBG;
                    newOrder.OrderStatus = order.OrderStatus;
                    newOrder.DateAndTimeOfOrder = order.DateAndTimeOfOrder;

                    context.tblOrders.Add(newOrder);
                    context.SaveChanges();
                    order.ID = newOrder.ID;

                    
                    return order;

                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public tblPizzaOrder AddPizzaOrder(tblPizzaOrder pizzaOrder)
        {
            try
            {
                using (PizzeriaDBEntities context = new PizzeriaDBEntities())
                {

                    tblPizzaOrder newPizzaOrder = new tblPizzaOrder();
                    newPizzaOrder.Amount = pizzaOrder.Amount;
                    newPizzaOrder.OrderID = pizzaOrder.OrderID;
                    newPizzaOrder.PizzaID = pizzaOrder.PizzaID;

                    context.tblPizzaOrders.Add(newPizzaOrder);
                    context.SaveChanges();
                    pizzaOrder.ID = newPizzaOrder.ID;


                    return pizzaOrder;

                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public void ApproveOrder(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteOrder(int id)
        {
            throw new NotImplementedException();
        }

        public List<tblPizzaOrder> GetOrders()
        {
            try
            {
                using (PizzeriaDBEntities context = new PizzeriaDBEntities())
                {
                    List<tblPizzaOrder> list = new List<tblPizzaOrder>();
                    list = (from x in context.tblPizzaOrders select x).ToList();
                    foreach (var item in list)
                    {
                        tblOrder order = (from e in context.tblOrders where e.ID == item.OrderID select e).First();
                        tblPizza pizza = (from e in context.tblPizzas where e.ID == item.PizzaID select e).First();

                        item.tblOrder.OrderStatus = order.OrderStatus;
                        item.tblOrder.JMBG = order.JMBG;
                        item.tblOrder.DateAndTimeOfOrder = order.DateAndTimeOfOrder;

                        item.tblPizza.PizzaType = pizza.PizzaType;
                        item.tblPizza.Price = pizza.Price;


                    }
                    return list;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public List<tblPizzaOrder> GetOrdersOfGuest(string JMBG)
        {
            try
            {
                using (PizzeriaDBEntities context = new PizzeriaDBEntities())
                {
                    List<tblPizzaOrder> list = new List<tblPizzaOrder>();
                    list = (from x in context.tblPizzaOrders select x).ToList();
                    foreach (var item in list)
                    {
                        tblOrder order = (from e in context.tblOrders where e.ID == item.OrderID select e).First();
                        tblPizza pizza = (from e in context.tblPizzas where e.ID == item.PizzaID select e).First();

                        item.tblOrder.OrderStatus = order.OrderStatus;
                        item.tblOrder.JMBG = order.JMBG;
                        item.tblOrder.DateAndTimeOfOrder = order.DateAndTimeOfOrder;

                        item.tblPizza.PizzaType = pizza.PizzaType;
                        item.tblPizza.Price = pizza.Price;


                    }
                    return list;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public List<tblPizza> GetPizzas()
        {
            try
            {
                using (PizzeriaDBEntities context = new PizzeriaDBEntities())
                {
                    List<tblPizza> list = new List<tblPizza>();
                    list = (from x in context.tblPizzas select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }
    }
}
