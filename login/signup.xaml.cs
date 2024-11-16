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

namespace login
{
    public class data
    {
        public string Names { get; set; }
        public string Address { get; set; }
        public string Departmentt { get; set; }
        public int agee { get; set; }
    }
    public partial class signup : Page
    {
        FactoryEntities db = new FactoryEntities();
        public signup()
        {
            InitializeComponent();
        }

        private void sign_up(object sender, RoutedEventArgs e)
        {
            string name = nameTxt.Text;
            string email = emailTxt.Text;
            string password = passTxt.Password;
            string address = txtadd.Text;
            
           
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("invaild data");
            }
            else if(!email.Contains("@"))
            {
                MessageBox.Show("invaild email");
            }
            else
            {
                student ac = new student();
                ac.names = name;
                ac.Email = email;
                ac.passwordd = password;
                ac.addresss = address;
                ac.age =int.Parse(agetxt.Text);
                ac.department = new department();
                ac.department.specilaztion = txtdep.Text;

                db.students.Add(ac);
               
                db.SaveChanges();
                MessageBox.Show("Signup completed!");

               

                loginpade login = new loginpade();
                NavigationService.Navigate(login);


         

            }

        }

        private void log_in(object sender, RoutedEventArgs e)
        {
            loginpade loginpade = new loginpade();
            NavigationService.Navigate(loginpade);
        }

        
    }
}
