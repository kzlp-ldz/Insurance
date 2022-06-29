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
using System.Collections.ObjectModel;

namespace Insurance
{
    /// <summary>
    /// Логика взаимодействия для regist.xaml
    /// </summary>
    public partial class regist : Page
    {
        Users users = new Users();
        public static ObservableCollection<Users> user {get; set;}
        public regist()
        {
            InitializeComponent();
            
        }

        private void btnLogIn_click(object sender, RoutedEventArgs e)
        {
            if (login.Text != "" && password.Text != "")
            {
                user = new ObservableCollection<Users>(BD_connection.bd_connection.connection.Users.ToList());
                var z = user.Where(a => a.login == login.Text).FirstOrDefault();
                if (z == null)
                {
                    users.login = login.Text;
                    users.password = password.Text;
                    users.isAdmin = false;
                    BD_connection.bd_connection.connection.Users.Add(users);
                    BD_connection.bd_connection.connection.SaveChanges();
                    NavigationService.Navigate(new autho());
                }
                else
                    MessageBox.Show("Такой логин уже занят, введите другой");
            }
            else
                MessageBox.Show("Заполните все поля");
        }

        private void btnSign_click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new autho());
        }
    }
}
