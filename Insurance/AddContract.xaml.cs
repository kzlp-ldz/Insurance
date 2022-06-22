using System;
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
    /// Логика взаимодействия для AddContract.xaml
    /// </summary>
    public partial class AddContract : Page
    {
        public static List<Fiz_lico> lico { get; set; }
        public static ObservableCollection<Predpriyat> predpriyats { get; set; }
        public static float summ;
        
        Employee_strah_sluch sluch = new Employee_strah_sluch();
        public AddContract()
        {
            InitializeComponent();
            lico = new List<Fiz_lico>();
            predpriyats = new ObservableCollection<Predpriyat>(BD_connection.bd_connection.connection.Predpriyat.ToList());
            fiz.ItemsSource = lico;
            sum.Text = summ.ToString();
            this.DataContext = this;
        }

        private void cmbPred_loaded(object sender, RoutedEventArgs e)
        {
            agent.ItemsSource = BD_connection.bd_connection.connection.Agent.ToList();
            type.ItemsSource = BD_connection.bd_connection.connection.Type_Povred.ToList();
            
            
        }

        private void btnSafe(object sender, RoutedEventArgs e)
        {
            if (agent.Text != "" && type.Text != "" && fiz.Text != "" && pred.Text != "" && sum.Text != "" && dateFirst.SelectedDate != null && dateSec.SelectedDate != null)
            {

                Contract_pred contract_ = new Contract_pred();
                contract_.date_conclusion = dateFirst.SelectedDate;
                contract_.end_date = dateSec.SelectedDate;
                contract_.id_agent = (agent.SelectedItem as Agent).id_agent;
                contract_.id_predriyat = (pred.SelectedItem as Predpriyat).id_predpriyat;
                contract_.sum_pay = decimal.Parse(sum.Text);

                BD_connection.bd_connection.connection.Contract_pred.Add(contract_);
                BD_connection.bd_connection.connection.SaveChanges();

                sluch.id_contract = contract_.id_contract;
                sluch.id_fiz_lica = (fiz.SelectedItem as Fiz_lico).id_fiz_lica;
                sluch.id_type = (type.SelectedItem as Type_Povred).id_type;

                BD_connection.bd_connection.connection.SaveChanges();

                MessageBox.Show("Добавлено!");

                NavigationService.Navigate(new contracts());
            }
            else
                MessageBox.Show("Введите значения!!!");
        }
        private void btnEnd(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new contracts());
        }

        private void pred_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var predrpiyat = (sender as ComboBox).SelectedItem as Predpriyat;
            lico = BD_connection.bd_connection.connection.Fiz_lico.Where(x => x.id_predpriyat == predrpiyat.id_predpriyat).ToList();
            fiz.ItemsSource = lico;
            this.DataContext = this;
        }

        private void type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            summ = (float)(fiz.SelectedItem as Fiz_lico).Risk_Kategory.pay * (float)(type.SelectedItem as Type_Povred).pay;
            sum.Text = summ.ToString();
            this.DataContext = this;
        }
    }
}
