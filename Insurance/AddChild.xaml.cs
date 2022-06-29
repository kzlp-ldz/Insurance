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
    /// Логика взаимодействия для AddChild.xaml
    /// </summary>
    public partial class AddChild : Page
    {
        public AddChild()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Child child = new Child();
            child.fio = tbxfio.Text;
            child.age = int.Parse(tbxage.Text);
            child.schoolNumber = int.Parse(tbxschool.Text);

            BD_connection.bd_connection.connection.Child.Add(child);
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
