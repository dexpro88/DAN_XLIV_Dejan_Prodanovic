using DAN_XLIV_Dejan_Prodanovic.Pizza;
using DAN_XLIV_Dejan_Prodanovic.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAN_XLIV_Dejan_Prodanovic.ViewModel
{
    class MenuViewModel:ViewModelBase
    {
        MenuView menuView;

        #region Constructors
        public MenuViewModel(MenuView menuViewOpen)
        {
            menuView = menuViewOpen;
            PizzaList = PizzaMetod.GetPizzas();
        }
        #endregion

        #region Properties
        private List<PizzaClass> pizzaList;
        public List<PizzaClass> PizzaList
        {
            get
            {
                return pizzaList;
            }
            set
            {
                pizzaList = value;
                OnPropertyChanged("PizzaList");
            }
        }
        #endregion
    }
}
