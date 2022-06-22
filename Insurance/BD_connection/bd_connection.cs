using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Threading.Tasks;

namespace Insurance.BD_connection
{
    class bd_connection
    {
        public static InsuranceEntities connection = new InsuranceEntities();
        public static ObservableCollection<Agent> agents { get; set; }
        public static ObservableCollection<Risk_Kategory> risks { get; set; }
        public static ObservableCollection<Fiz_lico> fizs { get; set; }
        public static ObservableCollection<Employee_strah_sluch> employees { get; set; }
        public static ObservableCollection<Type_Povred> types { get; set; }
        public static ObservableCollection<Contract_pred> contracts { get; set; }
        public static ObservableCollection<Predpriyat> predpriyats { get; set; }
        public static ObservableCollection<Enterprise_specialization> enterprises { get; set; }
        public bd_connection()
        {
            agents = new ObservableCollection<Agent>(connection.Agent.ToList());
            risks = new ObservableCollection<Risk_Kategory>(connection.Risk_Kategory.ToList());
            fizs = new ObservableCollection<Fiz_lico>(connection.Fiz_lico.ToList());
            employees = new ObservableCollection<Employee_strah_sluch>(connection.Employee_strah_sluch.ToList());
            types = new ObservableCollection<Type_Povred>(connection.Type_Povred.ToList());
            contracts = new ObservableCollection<Contract_pred>(connection.Contract_pred.ToList());
            predpriyats = new ObservableCollection<Predpriyat>(connection.Predpriyat.ToList());
            enterprises = new ObservableCollection<Enterprise_specialization>(connection.Enterprise_specialization.ToList());
        }
    }
}
