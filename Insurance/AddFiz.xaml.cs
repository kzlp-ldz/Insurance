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
    /// Логика взаимодействия для AddFiz.xaml
    /// </summary>
    public partial class AddFiz : Page
    {
        public AddFiz()
        {
            InitializeComponent();
        }

        private void cmbRisks_loaded(object sender, RoutedEventArgs e)
        {
            risks.ItemsSource = BD_connection.bd_connection.connection.Risk_Kategory.ToList();
        }

        private void cmbPred_loaded(object sender, RoutedEventArgs e)
        {
            pred.ItemsSource = BD_connection.bd_connection.connection.Predpriyat.ToList();
        }
        private void btnSafe(object sender, RoutedEventArgs e)
        {
            if (fio.Text != "" && birth.SelectedDate != null && risks.Text != "" && pred.Text != "")
            {
                Fiz_lico fiz = new Fiz_lico();
                fiz.fio = fio.Text;
                fiz.birth_date = birth.SelectedDate;
                fiz.id_risk_kategory = (risks.SelectedItem as Risk_Kategory).id_risk_kategory;
                fiz.id_predpriyat = (pred.SelectedItem as Predpriyat).id_predpriyat;

                BD_connection.bd_connection.connection.Fiz_lico.Add(fiz);
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
