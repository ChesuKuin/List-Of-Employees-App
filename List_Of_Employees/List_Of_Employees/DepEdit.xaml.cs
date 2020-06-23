using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;

namespace List_Of_Employees
{
    /// <summary>
    /// Логика взаимодействия для EditWindow.xaml
    /// </summary>
    public partial class DepEdit : Window
    {

        public DataRow resultRow { get; set; }
        public DepEdit(DataRow dataRow)
        {
            InitializeComponent();
            resultRow = dataRow;

        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DepartmentTextBox.Text = resultRow["Department"].ToString();
        }


        private void saveDepartment(object sender, RoutedEventArgs e)
        {
            resultRow["Department"] = DepartmentTextBox.Text;
            this.DialogResult = true;
        }

        private void cancelDepartment(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}