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
using System.ComponentModel;

namespace Insurance
{
    /// <summary>
    /// Логика взаимодействия для main.xaml
    /// </summary>
    public partial class main : Page
    {
        public ObservableCollection<Teacher> teacher { get; set; }
        public ObservableCollection<Child> child { get; set; }
        public Child children = new Child();
        public Teacher teacherss = new Teacher();
        public main()
        {
            InitializeComponent();
            teacher = new ObservableCollection<Teacher>(BD_connection.bd_connection.connection.Teacher.ToList());
            child = new ObservableCollection<Child>(BD_connection.bd_connection.connection.Child.ToList());
            this.DataContext = this;
        }

        

        private void cmbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbx.Text == teachers.Text)
            {
                btnaddchild.Visibility = Visibility.Visible;
                btndeletechild.Visibility = Visibility.Visible;
                txt.Text = "Childrens Info";
                ListChild.Visibility = Visibility.Visible;
                ListTeacher.Visibility = Visibility.Hidden;
                btndeleteteacher.Visibility = Visibility.Hidden;
                btnaddteacher.Visibility = Visibility.Hidden;
            }
            else if (cmbx.Text == childrens.Text)
            {
                btnaddteacher.Visibility = Visibility.Visible;
                btndeleteteacher.Visibility = Visibility.Visible;
                txt.Text = "Teachers Info";
                ListTeacher.Visibility = Visibility.Visible;
                ListChild.Visibility = Visibility.Hidden;
                btnaddchild.Visibility = Visibility.Hidden;
                btndeletechild.Visibility = Visibility.Hidden;
            }
        }

        private void btnaddchild_Click(object sender, RoutedEventArgs e)
        {
            if (BD_connection.User.IsAdmin == false)
                MessageBox.Show("Недостаточно прав");
            else
                NavigationService.Navigate(new AddChild());
        }

        private void btnaddteacher_Click(object sender, RoutedEventArgs e)
        {
            if (BD_connection.User.IsAdmin == false)
                MessageBox.Show("Недостаточно прав");
            else
                NavigationService.Navigate(new AddTeacher());
        }

        private void ListChild_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var z = ListChild.SelectedItem as Child;
            if (BD_connection.User.IsAdmin == false)
                MessageBox.Show("Недостаточно прав");
            else
                NavigationService.Navigate(new RedaktChild(z));
        }

        private void ListTeacher_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var z = ListTeacher.SelectedItem as Teacher;
            if (BD_connection.User.IsAdmin == false)
                MessageBox.Show("Недостаточно прав");
            else
                NavigationService.Navigate(new RedaktTeacher(z));
        }

        private void btndeletechild_Click(object sender, RoutedEventArgs e)
        {

            var z = ListChild.SelectedItem as Child;
            if (BD_connection.User.IsAdmin == false)
                MessageBox.Show("Недостаточно прав");
            else
            {
                if (z != null)
                {
                    BD_connection.bd_connection.connection.Child.Remove(z);
                    BD_connection.bd_connection.connection.SaveChanges();
                    NavigationService.Navigate(new main());
                }
                else
                    MessageBox.Show("Выберите поле для удаления");
            }
            
        }

        private void btndeleteteacher_Click(object sender, RoutedEventArgs e)
        {
            var z = ListTeacher.SelectedItem as Teacher;
            if (BD_connection.User.IsAdmin == false)
                MessageBox.Show("Недостаточно прав");
            else
            {
                if (z != null)
                {
                    BD_connection.bd_connection.connection.Teacher.Remove(z);
                    BD_connection.bd_connection.connection.SaveChanges();
                    NavigationService.Navigate(new main());
                }
                else
                    MessageBox.Show("Выберите поле для удаления");
            }
        }
    }
}
