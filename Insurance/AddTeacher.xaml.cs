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
    /// Логика взаимодействия для AddTeacher.xaml
    /// </summary>
    public partial class AddTeacher : Page
    {
        public AddTeacher()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Teacher teacher = new Teacher();
            teacher.Fio = tbxfio.Text;
            teacher.phone = tbxage.Text;
            teacher.date = dpdate.SelectedDate;

            BD_connection.bd_connection.connection.Teacher.Add(teacher);
            BD_connection.bd_connection.connection.SaveChanges();

            MessageBox.Show("Added");
            NavigationService.Navigate(new main());
        }

        private void OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            CheckIsNumeric(e);
        }
        private void CheckIsNumeric(TextCompositionEventArgs e)
        {
            int result;

            if (!(int.TryParse(e.Text, out result) || e.Text == "."))
            {
                e.Handled = true;
            }
        }
    }
}
