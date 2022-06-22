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
    /// Логика взаимодействия для AddEmployee.xaml
    /// </summary>
    public partial class AddEmployee : Page
    {
        public AddEmployee()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void btnSafe(object sender, RoutedEventArgs e)
        {
            if (fio.Text != "" && passport.Text != "" && login.Text != "" && passport.Text != "")
            {
                Agent agent = new Agent();
                agent.fio = fio.Text;
                agent.pasport = passport.Text;
                agent.login = login.Text;
                agent.password = password.Text;
                agent.isAdmin = false;

                BD_connection.bd_connection.connection.Agent.Add(agent);
                BD_connection.bd_connection.connection.SaveChanges();

                MessageBox.Show("Добавлено!");

                NavigationService.Navigate(new Employees());
            }
            else
                MessageBox.Show("Введите значения!!!");
        }

        private void btnEnd(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Employees());
        }
    }
}
