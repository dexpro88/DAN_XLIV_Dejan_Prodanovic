using DAN_XLIV_Dejan_Prodanovic.Service;
using DAN_XLIV_Dejan_Prodanovic.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAN_XLIV_Dejan_Prodanovic.ViewModel
{
    class EmployeeViewModel:ViewModelBase
    {
        EmployeeView employeeView;
        IPizzeriaService service;

        #region Constructors
        public EmployeeViewModel(EmployeeView employeeViewOpen)
        {
            employeeView = employeeViewOpen;
            service = new PizzeriaService();
            OrderList = service.GetOrders();
        }
        
        #endregion

        #region Propertires
        private List<tblPizzaOrder> orderList;
        public List<tblPizzaOrder> OrderList
        {
            get
            {
                return orderList;
            }
            set
            {
                orderList = value;
                OnPropertyChanged("OrderList");
            }
        }
        #endregion
    }
}
