using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;

using System.Windows;


namespace List_Of_Employees
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection connection;
        SqlDataAdapter adapter;
        DataTable dt;
        DataTable dtdep;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var connectionStringBuilder = new SqlConnectionStringBuilder
            {
                DataSource = @"(localdb)\MSSQLLocalDB",
                InitialCatalog = "List Of Employees"
            };

            connection = new SqlConnection(connectionStringBuilder.ConnectionString);
            adapter = new SqlDataAdapter();

            #region select

            SqlCommand command =
                new SqlCommand("SELECT * FROM Employees",
                connection);
            adapter.SelectCommand = command;


            #endregion

            #region insert

            command = new SqlCommand(@"INSERT INTO Employees (LastName, FirstName, DepartmentId) 
                          VALUES (@LastName, @FirstName, @DepartmentId); SET @ID = @@IDENTITY;",
                          connection);

            command.Parameters.Add("@LastName", SqlDbType.NVarChar, -1, "LastName");
            command.Parameters.Add("@FirstName", SqlDbType.NVarChar, -1, "FirstName");
            command.Parameters.Add("@DepartmentId", SqlDbType.NVarChar, 0, "DepartmentId");

            SqlParameter param = command.Parameters.Add("@ID", SqlDbType.Int, 0, "ID");

            param.Direction = ParameterDirection.Output;

            adapter.InsertCommand = command;

            #endregion

            #region update

            command = new SqlCommand(@"UPDATE Employee SET DepartmentId = @DepartmentId
                                                           LastName = @LastName
                                                           FirstName = @FirstName
                                        WHERE ID = @ID", connection);

            command.Parameters.Add("@LastName", SqlDbType.NVarChar, -1, "LastName");
            command.Parameters.Add("@FirstName", SqlDbType.NVarChar, -1, "FirstName");
            command.Parameters.Add("@DepartmentId", SqlDbType.NVarChar, 0, "DepartmentId");

            param = command.Parameters.Add("@ID", SqlDbType.Int, 0, "ID");

            param.SourceVersion = DataRowVersion.Original;

            adapter.UpdateCommand = command;


            #endregion

            #region delete


            command = new SqlCommand("DELETE FROM Employees WHERE ID = @ID", connection);
            param = command.Parameters.Add("@ID", SqlDbType.Int, 0, "ID");
            // param.SourceVersion = DataRowVersion.Original;
            adapter.DeleteCommand = command;

            #endregion

            dt = new DataTable();
            adapter.Fill(dt);
            employeeDataGrid.DataContext = dt.DefaultView;

            #region select

            SqlCommand commanddep =
                new SqlCommand("SELECT * FROM Department",
                connection);
            adapter.SelectCommand = commanddep;


            #endregion

            #region insert

            commanddep = new SqlCommand(@"INSERT INTO Department (Department) 
                          VALUES (@Department); SET @ID = @@IDENTITY;",
                          connection);
            commanddep.Parameters.Add("@Department", SqlDbType.NVarChar, 0, "Department");

            SqlParameter paramdep = commanddep.Parameters.Add("@ID", SqlDbType.Int, 0, "ID");

            paramdep.Direction = ParameterDirection.Output;

            adapter.InsertCommand = commanddep;

            #endregion

            #region update

            commanddep = new SqlCommand(@"UPDATE Department SET Department = @Department
                                        WHERE ID = @ID", connection);
            commanddep.Parameters.Add("@Department", SqlDbType.NVarChar, 0, "Department");

            paramdep = commanddep.Parameters.Add("@ID", SqlDbType.Int, 0, "ID");

            paramdep.SourceVersion = DataRowVersion.Original;

            adapter.UpdateCommand = commanddep;


            #endregion

            #region delete


            commanddep = new SqlCommand("DELETE FROM Department WHERE DID = @DID", connection);
            paramdep = commanddep.Parameters.Add("@DID", SqlDbType.Int, 0, "DID");
            // param.SourceVersion = DataRowVersion.Original;
            adapter.DeleteCommand = commanddep;

            #endregion
            dtdep = new DataTable();
            adapter.Fill(dtdep);
            departmentDataGrid.DataContext = dtdep.DefaultView;
        }
        private void addemployee(object sender, RoutedEventArgs e)
        {
            DataRow newRow = dt.NewRow();
            EditWindow editWindow = new EditWindow(newRow);
            editWindow.ShowDialog();

            if (editWindow.DialogResult.Value)
            {
                dt.Rows.Add(editWindow.resultRow);
                adapter.Update(dt);
            }
        }

        private void changeemployee(object sender, RoutedEventArgs e)
        {
            DataRowView newRow = (DataRowView)employeeDataGrid.SelectedItem;
            newRow.BeginEdit();

            EditWindow editWindow = new EditWindow(newRow.Row);
            editWindow.ShowDialog();

            if (editWindow.DialogResult.HasValue && editWindow.DialogResult.Value)
            {
                newRow.EndEdit();
                adapter.Update(dt);
            }
            else
            {
                newRow.CancelEdit();
            }
        }

        private void deleteemployee(object sender, RoutedEventArgs e)
        {
            DataRowView newRow = (DataRowView)employeeDataGrid.SelectedItem;

            newRow.Row.Delete();
            adapter.Update(dt);
        }


        private void department(object sender, RoutedEventArgs e)
        {
            DataRow newRow = dtdep.NewRow();
            DepEdit depEdit = new DepEdit(newRow);
            depEdit.ShowDialog();

            if (depEdit.DialogResult.Value)
            {
                dtdep.Rows.Add(depEdit.resultRow);
                dtdep.Rows.Add(depEdit.resultRow);
                adapter.Update(dtdep);
            }
        }

        private void changedepartment(object sender, RoutedEventArgs e)
        {
            DataRowView newRow = (DataRowView)departmentDataGrid.SelectedItem;
            newRow.BeginEdit();

            DepEdit depEdit = new DepEdit(newRow.Row);
            depEdit.ShowDialog();

            if (depEdit.DialogResult.HasValue && depEdit.DialogResult.Value)
            {
                newRow.EndEdit();
                adapter.Update(dtdep);
            }
            else
            {
                newRow.CancelEdit();
            }
        }

        private void deletedepartment(object sender, RoutedEventArgs e)
        {
            DataRowView newRow = (DataRowView)departmentDataGrid.SelectedItem;

            newRow.Row.Delete();
            adapter.Update(dtdep);
        }


    }
}

