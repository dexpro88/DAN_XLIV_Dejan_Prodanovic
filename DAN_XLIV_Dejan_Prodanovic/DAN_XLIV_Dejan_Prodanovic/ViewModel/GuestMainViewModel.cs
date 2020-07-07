using DAN_XLIV_Dejan_Prodanovic.Command;
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
    class GuestMainViewModel:ViewModelBase
    {

        GuestMainView guestMainView;
        #region Constructors
        public GuestMainViewModel(GuestMainView guestMainViewOpen)
        {
            guestMainView = guestMainViewOpen;
        }
        #endregion

        #region Commands
        private ICommand showMenu;
        public ICommand ShowMenu
        {
            get
            {
                if (showMenu == null)
                {
                    showMenu = new RelayCommand(param => ShowMenuExecute(), param => CanShowMenuExecute());
                }
                return showMenu;
            }
        }

        private void ShowMenuExecute()
        {
            try
            {
                MenuView menuView = new MenuView();           
                menuView.Show();
                guestMainView.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanShowMenuExecute()
        {
            return true;
        }

        private ICommand logoutCommmand;
        public ICommand LogoutCommmand
        {
            get
            {
                if (logoutCommmand == null)
                {
                    logoutCommmand = new RelayCommand(param => LogoutExecute(), param => CanLogoutExecute());
                }
                return logoutCommmand;
            }
        }

        private void LogoutExecute()
        {
            try
            {
                LoginView loginView = new LoginView();
                guestMainView.Close();
                loginView.ShowDialog();
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

                guestMainView.Close();

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
    }
}
