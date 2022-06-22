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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Insurance
{
    /// <summary>
    /// Логика взаимодействия для AddPred.xaml
    /// </summary>
    public partial class AddPred : Page
    {
        public AddPred()
        {
            InitializeComponent();
        }

        private void cmbPred_loaded(object sender, RoutedEventArgs e)
        {
            spec.ItemsSource = BD_connection.bd_connection.connection.Enterprise_specialization.ToList();
        }
        private void btnSafe(object sender, RoutedEventArgs e)
        {
            if (full_name.Text != "" && short_name.Text != "" && address.Text != "" && bank.Text != "" && spec.Text != "")
            {
                
                Predpriyat predpriyat = new Predpriyat();
                predpriyat.full_name = full_name.Text;
                predpriyat.short_name = short_name.Text;
                predpriyat.address = address.Text;
                predpriyat.bank = bank.Text;
                predpriyat.id_specialization = (spec.SelectedItem as Enterprise_specialization).id_specialization;

                BD_connection.bd_connection.connection.Predpriyat.Add(predpriyat);
                BD_connection.bd_connection.connection.SaveChanges();

                MessageBox.Show("Добавлено!");

                NavigationService.Navigate(new organiz());
            }
            else
                MessageBox.Show("Введите значения!!!");
        }

        private void btnEnd(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new organiz());
        }
    }
}
