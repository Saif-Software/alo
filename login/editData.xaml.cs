using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Interaction logic for editData.xaml
    /// </summary>
    public partial class editData : Page
    {
        FactoryEntities db = new FactoryEntities();
        public editData(string names)
        {
            InitializeComponent();
            string Name;
            this.Name = names;
            loadData();
        }

        private void loadData()
        {
            student stu = new student();

            stu = db.students.First(x => x.names == Name);

            txtname.Text = stu.names;
            txtaddress.Text = stu.addresss;
            txtage.Text = stu.age.ToString();
            stu.department = new department();
            stu.department.specilaztion = txtdep.Text;
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            student stu = new student();
            stu = db.students.First(x => x.names == Name);
            stu.names = txtname.Text;
            stu.age = int.Parse(txtage.Text);
            stu.department = new department();
            stu.department.specilaztion = txtdep.Text;
            db.SaveChanges();
            MessageBox.Show("Data Saved");

        }
    }
}
