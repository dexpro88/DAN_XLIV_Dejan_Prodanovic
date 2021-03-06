﻿using DAN_XLIV_Dejan_Prodanovic.Pizza;
using DAN_XLIV_Dejan_Prodanovic.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DAN_XLIV_Dejan_Prodanovic.View
{
    /// <summary>
    /// Interaction logic for ShowOrderView.xaml
    /// </summary>
    public partial class ShowOrderView : Window
    {
        public ShowOrderView()
        {
            InitializeComponent();
        }
        public ShowOrderView(List<tblPizzaOrder> pizzas, decimal totalAmount,string JMBG)
        {
            InitializeComponent();
            DataContext = new ShowOrderViewModel(this, pizzas, totalAmount,JMBG);
        }
    }
}
