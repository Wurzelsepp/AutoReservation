﻿using System.Windows.Controls;
using AutoReservation.Ui.ViewModels;

namespace AutoReservation.Ui.Views
{
    /// <summary>
    /// Interaction logic for AutoView.xaml
    /// </summary>
    public partial class AutoView : UserControl
    {
        public AutoView()
        {
            InitializeComponent();
            DataContext = new AutoViewModel();
        }
    }
}
