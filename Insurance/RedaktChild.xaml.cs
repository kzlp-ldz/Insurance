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
    /// Логика взаимодействия для RedaktChild.xaml
    /// </summary>
    public partial class RedaktChild : Page
    {
        Child childs = new Child();
        
        public RedaktChild(Child children)
        {
            InitializeComponent();
            childs = children;

            tbxfio.Text = childs.fio;
            tbxage.Text = childs.age.ToString();
            tbxschool.Text = childs.schoolNumber.ToString();
            this.DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            childs.fio = tbxfio.Text;
            childs.age = int.Parse(tbxage.Text);
            childs.schoolNumber = int.Parse(tbxschool.Text);

            
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
