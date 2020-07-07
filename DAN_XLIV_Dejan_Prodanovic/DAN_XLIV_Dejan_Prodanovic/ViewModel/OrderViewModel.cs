using DAN_XLIV_Dejan_Prodanovic.Command;
using DAN_XLIV_Dejan_Prodanovic.Pizza;
using DAN_XLIV_Dejan_Prodanovic.View;
using DataAccesLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DAN_XLIV_Dejan_Prodanovic.ViewModel
{
    class OrderViewModel:ViewModelBase
    {
        OrderView orderView = new OrderView();
        private string JMBG;
 
        #region Constructors
        public OrderViewModel(OrderView orderViewOpen, List<PizzaClass>pizzas,decimal totalAmountPar,string JMBG)
        {
            orderView = orderViewOpen;
            PizzaList = pizzas;
            
            totalAmount = String.Format("Total order price: {0}", totalAmountPar);
            this.JMBG = JMBG;
        }
        #endregion

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

        private bool orderConfirmed;
        public bool OrderConfirmed
        {
            get
            {
                return orderConfirmed;
            }
            set
            {
                orderConfirmed = value;
                OnPropertyChanged("OrderConfirmed");
            }
        }

        private string totalAmount;
        public string TotalAmount
        {
            get
            {
                return totalAmount;
            }
            set
            {
                totalAmount = value;
                OnPropertyChanged("TotalAmount");
            }
        }

        private ICommand confirmOrder;
        public ICommand ConfirmOrder
        {
            get
            {
                if (confirmOrder == null)
                {
                    confirmOrder = new RelayCommand(param => ConfirmOrderExecute(), param => CanConfirmOrderExecute());
                }
                return confirmOrder;
            }
        }

        private void ConfirmOrderExecute()
        {
            try
            {
                Order order = new Order();
                order.ID = 1;
                order.JMBG = JMBG;
                order.DateAndTimeOfOrder = DateTime.Now;
                order.Status = "W";
                OrderConfirmed = true;
                foreach (var pizza in pizzaList)
                {
                   
                }
                orderView.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanConfirmOrderExecute()
        {
            return true;
        }
    
        private ICommand close;
        public ICommand Close
        {
            get
            {
                if (close == null)
                {
                    close = new RelayCommand(param => CloseExecute(), param => CanCloseExecute());
                }
                return close;
            }
        }

        private void CloseExecute()
        {
            try
            {
                
                orderView.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanCloseExecute()
        {
            return true;
        }
    }
}
