﻿using DAN_XLIV_Dejan_Prodanovic.Command;
using DAN_XLIV_Dejan_Prodanovic.Pizza;
using DAN_XLIV_Dejan_Prodanovic.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DAN_XLIV_Dejan_Prodanovic.ViewModel
{
    class MenuViewModel:ViewModelBase
    {
        MenuView menuView;
        private decimal totalAmountNum = 0;
        private bool orderConfirmed = false;
        private string JMBG;

        #region Constructors
        public MenuViewModel(MenuView menuViewOpen)
        {
            menuView = menuViewOpen;
            PizzaList = PizzaMetod.GetPizzas();
            orederedPizzas = new List<PizzaClass>();
        }

        public MenuViewModel(MenuView menuViewOpen,string JMBG)
        {
            menuView = menuViewOpen;
            PizzaList = PizzaMetod.GetPizzas();
            orederedPizzas = new List<PizzaClass>();
            this.JMBG = JMBG;
        }
        #endregion

        #region Properties
        private PizzaClass selectedPizza;
        public PizzaClass SelectedPizza
        {
            get
            {
                return selectedPizza;
            }
            set
            {
                selectedPizza = value;
                OnPropertyChanged("SelectedPizza");
            }
        }

        private string totalAmount ="Total order amount: 0";
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

        private int currentAmount = 0;
        public int CurrentAmount
        {
            get
            {
                return currentAmount;
            }
            set
            {
                currentAmount = value;
                OnPropertyChanged("CurrentAmount");

            }
        }

        private Visibility viewMakeOrder = Visibility.Visible;
        public Visibility ViewMakeOrder
        {
            get
            {
                return viewMakeOrder;
            }
            set
            {
                viewMakeOrder = value;
                OnPropertyChanged("ViewMakeOrder");
            }
        }

        private Visibility viewShowOrder = Visibility.Collapsed;
        public Visibility ViewShowOrder
        {
            get
            {
                return viewShowOrder;
            }
            set
            {
                viewShowOrder = value;
                OnPropertyChanged("ViewShowOrder");
            }
        }


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

        private List<PizzaClass> orederedPizzas;
        public List<PizzaClass> OrederedPizzas
        {
            get
            {
                return orederedPizzas;
            }
            set
            {
                orederedPizzas = value;
                OnPropertyChanged("OrederedPizzas");
            }
        }
        #endregion

        #region Commands

        private ICommand addToOrder;
        public ICommand AddToOrder
        {
            get
            {
                if (addToOrder == null)
                {
                    addToOrder = new RelayCommand(param => AddToOrderExecute(), param => CanAddToOrderExecute());
                }
                return addToOrder;
            }
        }

        private void AddToOrderExecute()
        {
            try
            {
                PizzaClass thisPizza = FindPizzaByName(SelectedPizza.Name);

                if (thisPizza!=null && currentAmount==0)
                {
                    CurrentAmount = thisPizza.Amount;
                }
                if (CurrentAmount <=0 || CurrentAmount > 50)
                {
                    MessageBox.Show("You have to order between 1 and 50 pizzas of one type");
                    return;
                }
                
                SelectedPizza.Amount = currentAmount;
                
                PizzaClass newPizza = new PizzaClass(SelectedPizza.Name, SelectedPizza.Price) { Amount = currentAmount};
               
                if (thisPizza!=null)
                {
                    //MessageBox.Show(thisPizza.Amount.ToString());
                    totalAmountNum -= (thisPizza.Amount * thisPizza.Price);
                    OrederedPizzas.Remove(thisPizza);
                }

                
                totalAmountNum += (CurrentAmount * SelectedPizza.Price);
                OrederedPizzas.Add(newPizza);
                 
                TotalAmount = string.Format("Total order price {0}", totalAmountNum);
                string outputStr = string.Format("Your order will contain {0} {1}", CurrentAmount, SelectedPizza.Name);
                CurrentAmount = 0;
                MessageBox.Show(outputStr);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanAddToOrderExecute()
        {
            if (orderConfirmed)
            {
                return false;
            }
            return true;
        }

        private ICommand makeOrder;
        public ICommand MakeOrder
        {
            get
            {
                if (makeOrder == null)
                {
                    makeOrder = new RelayCommand(param => MakeOrderExecute(), param => CanMakeOrderExecute());
                }
                return makeOrder;
            }
        }

        private void MakeOrderExecute()
        {
            try
            {
                OrderView orderView = new OrderView(orederedPizzas, totalAmountNum,JMBG);
                orderView.ShowDialog();

                if ((orderView.DataContext as OrderViewModel).OrderConfirmed == true)
                {
                    ViewMakeOrder = Visibility.Hidden;
                    ViewShowOrder = Visibility.Visible;
                    orderConfirmed = true;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanMakeOrderExecute()
        {
            if (!orederedPizzas.Any()||orderConfirmed)
            {
                return false;
            }
            return true;
        }

        private ICommand showOrder;
        public ICommand ShowOrder
        {
            get
            {
                if (showOrder == null)
                {
                    showOrder = new RelayCommand(param => ShowOrderExecute(), param => CanShowOrderExecute());
                }
                return showOrder;
            }
        }

        private void ShowOrderExecute()
        {
            try
            {
                ShowOrderView orderView = new ShowOrderView(orederedPizzas, totalAmountNum,JMBG);
                orderView.ShowDialog();

                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanShowOrderExecute()
        {
            if (!orederedPizzas.Any())
            {
                return false;
            }
            return true;
        }

        private ICommand logout;
        public ICommand Logout
        {
            get
            {
                if (logout == null)
                {
                    logout = new RelayCommand(param => LogoutExecute(), param => CanLogoutExecute());
                }
                return logout;
            }
        }

        private void LogoutExecute()
        {
            try
            {
                LoginView loginView = new LoginView();
                loginView.Show();
                menuView.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanLogoutExecute()
        {
            return true;
        }

        private ICommand back;
        public ICommand Back
        {
            get
            {
                if (back == null)
                {
                    back = new RelayCommand(param => BackExecute(), param => CanBackExecute());
                }
                return back;
            }
        }

        private void BackExecute()
        {
            try
            {
                GuestMainView guestMain = new GuestMainView();
                guestMain.Show();
                menuView.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanBackExecute()
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

                menuView.Close();

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
        #endregion

        #region Methods
        private PizzaClass FindPizzaByName(string name)
        {
            foreach (var pizza in orederedPizzas)
            {
                if (pizza.Name.Equals(name))
                {
                    return pizza;
                }
            }
            return null;
        }
        #endregion
    }
}
