using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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

namespace login
{
    /// <summary>
    /// Interaction logic for loginpade.xaml
    /// </summary>
    public partial class loginpade : Page
    {
        
        public loginpade()
        {
            InitializeComponent();
           
        
        }
        private void sign_up(object sender, RoutedEventArgs e)
        {
            signup signup = new signup();
            NavigationService.Navigate(signup);
        }
        private void login(object sender, RoutedEventArgs e)
        {
            FactoryEntities db = new FactoryEntities();
           
            var rec = db.students.FirstOrDefault(x=>x.names==nameTxt.Text && x.passwordd == passTxt.Password);
            if(nameTxt.Text == "admin" && passTxt.Password == "saif@123")
            {
                datagrid data = new datagrid();
                NavigationService.Navigate(data);
            }
            else if (rec!=null )
            {
                MessageBox.Show("login success!");

                editData edit = new editData(rec.names);
                NavigationService.Navigate(edit);
            }
            else
            {
                MessageBox.Show("invaild Name or Password");
            }
        }

       
    }
}
