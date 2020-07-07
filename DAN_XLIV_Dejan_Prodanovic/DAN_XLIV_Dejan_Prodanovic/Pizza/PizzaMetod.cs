using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAN_XLIV_Dejan_Prodanovic.Pizza
{
    class PizzaMetod
    {
        static List<PizzaClass> pizzas = new List<PizzaClass>()
        {
            new PizzaClass("Pepperoni Pizza",15), new PizzaClass("Meat Pizza",20), new PizzaClass("Pizza Margherita",10),
            new PizzaClass("Hawaiian Pizza",22), new PizzaClass("Buffalo  Pizza",22),new PizzaClass("Pizza Marinara",17),
            new PizzaClass("Pizza Capricciosa",21), new PizzaClass("Pizza Mexicana",21),  new PizzaClass("Pizza Napolitana",21)
        };

        public static List<PizzaClass> GetPizzas()
        {
            return pizzas;
        }
    }
}
