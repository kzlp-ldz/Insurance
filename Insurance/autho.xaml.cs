﻿using System;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Insurance
{
    /// <summary>
    /// Логика взаимодействия для autho.xaml
    /// </summary>
    public partial class autho : Page
    {
        public autho()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void btnLogIn_click(object sender, RoutedEventArgs e)
        {
            var z = BD_connection.bd_connection.connection.Agent.Where(a => a.login == login.Text && a.password == password.Text).FirstOrDefault();
            if (z != null)
            {
                if (z.isAdmin == true)
                {
                    BD_connection.User.IsAdmin = true;
                }
                else
                    BD_connection.User.IsAdmin = false;
                MessageBox.Show(z.fio);
                NavigationService.Navigate(new main());
            }
            else
            {
                MessageBox.Show("введи пароль и логин нормально дура", "error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
