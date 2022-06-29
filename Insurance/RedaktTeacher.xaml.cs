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
    /// Логика взаимодействия для RedaktTeacher.xaml
    /// </summary>
    public partial class RedaktTeacher : Page
    {
        Teacher teachers = new Teacher();

        public RedaktTeacher(Teacher teacherss)
        {
            InitializeComponent();
            teachers = teacherss;
            tbxfio.Text = teachers.Fio;
            tbxage.Text = teachers.phone;
            dpdate.SelectedDate = teachers.date;
            this.DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            teachers.Fio = tbxfio.Text;
            teachers.phone = tbxage.Text;
            teachers.date = dpdate.SelectedDate;

            BD_connection.bd_connection.connection.SaveChanges();

            MessageBox.Show("Changed");
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
