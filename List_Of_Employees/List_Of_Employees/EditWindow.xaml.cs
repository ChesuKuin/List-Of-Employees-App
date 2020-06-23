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
    public partial class EditWindow : Window
    {

        public DataRow resultRow { get; set; }
        public EditWindow(DataRow dataRow)
        {
            InitializeComponent();

            resultRow = dataRow;

        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LastNameTextBox.Text = resultRow["LastName"].ToString();
            FirstNameTextBox.Text = resultRow["FirstName"].ToString();
            DepartmentTextBox.Text = resultRow["DepartmentId"].ToString();
        }


        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            resultRow["LastName"] = LastNameTextBox.Text;
            resultRow["FirstName"] = FirstNameTextBox.Text;
            resultRow["DepartmentId"] = DepartmentTextBox.Text;
            this.DialogResult = true;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
