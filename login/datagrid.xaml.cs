using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
    /// Interaction logic for datagrid.xaml
    /// </summary>
    public partial class datagrid : Page
    {
        FactoryEntities db =new FactoryEntities();
        public datagrid()
        {
            InitializeComponent();
            data.ItemsSource = db.students.ToList(); 
        }

        private void Search(object sender, RoutedEventArgs e)
        {

            List<student> students = new List<student>();
            if(txtSearch.Text != null)
            {
                students=db.students.Where(x=>x.names==txtSearch.Text).ToList();
                data.ItemsSource = students.ToList();
            }    
            else
            {
                MessageBox.Show("invaild data");
            }
        }

        private void Edit(object sender, RoutedEventArgs e)
        {
            student student = new student();
            if(idbox.Text != null)
            {
                int ID = int.Parse(idbox.Text);
                student = db.students.First(x => x.id ==ID);
                student.department = new department();
                student.department.specilaztion = deptxt.Text;

                db.students.AddOrUpdate(student);
                db.SaveChanges();

                MessageBox.Show("updated Success");
                data.ItemsSource = db.students.ToList();
            }
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            student student = new student();

            if (idbox.Text != null)
            {
                int ID = int.Parse(idbox.Text);

                student = db.students.Remove(db.students.First(x => x.id == ID));
                db.students.Remove(student);
                db.SaveChanges();

                MessageBox.Show("Removed Success");

                data.ItemsSource = db.students.ToList();
            }
        }
    }
}
