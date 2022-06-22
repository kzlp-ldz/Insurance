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
    /// Логика взаимодействия для organiz.xaml
    /// </summary>
    public partial class organiz : Page
    {
        public organiz()
        {
            InitializeComponent();
        }
        private void btnOut(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Точно выйти?", "Выйти",
            MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {

                System.Windows.Application.Current.Shutdown();
            }

        }

        private void btnFirst(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new main());
        }

        private void btnEmployees(object sender, RoutedEventArgs e)
        {
            if (BD_connection.User.IsAdmin)
                NavigationService.Navigate(new Employees());
            else
                MessageBox.Show("Недостаточно прав");
        }

        private void btnContracts(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new contracts());
        }
        private void tbxSearche(object sender, TextChangedEventArgs e)
        {
            ListOrganiz.ItemsSource = BD_connection.bd_connection.connection.Predpriyat.Where(x => x.short_name.Contains(searche.Text)).ToList();
        }

        private void ld(object sender, RoutedEventArgs e)
        {
            ListOrganiz.ItemsSource = BD_connection.bd_connection.connection.Predpriyat.ToList();
        }

        private void btnEnterp(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new organiz());
        }

        private void add_fiz_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddFiz());
        }

        private void add_pred_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddPred());
        }
    }
}
