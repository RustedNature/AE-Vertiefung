﻿using System;
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

namespace _08_WP_T_F_Einstieg
{
    /// <summary>
    /// Interaktionslogik für DockPanel.xaml
    /// </summary>
    public partial class DockPanel : Window
    {
        public DockPanel()
        {
            InitializeComponent();
        }

        private void BTN_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}