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
using System.Windows.Shapes;
using SchuhLadenApp.Controller;
using SchuhLadenApp.Model;

namespace SchuhLadenApp.View
{
    /// <summary>
    /// Interaction logic for AddNewUserPanel.xaml
    /// </summary>
    public partial class AddNewUserPanel : Window
    {
        public AddNewUserPanel()
        {
            InitializeComponent();
        }

        private void btnAddNewUser_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string LastName = tbxName.Text;
                string FirstName = tbxFirstname.Text;
                string Street = tbxStreet.Text;
                string HouseNo = tbxHousenum.Text;
                int Postcode = Convert.ToInt32(tbxPostcode.Text);
                string DateOfEmployment = tbxEmployedOn.Text;
                double Salary = Convert.ToDouble(tbxSalary.Text);
                string UserStatus = tbxUserstatus.Text;
                string Account = tbxAccount.Text;
                string Password = tbxPassword.Text;

                DatabaseHelper databaseHelper = new DatabaseHelper();

                databaseHelper.OpenConnection();

                User newUser = new User(LastName, FirstName, Street, HouseNo, Postcode,
                    DateOfEmployment, Salary, UserStatus, Password, Account);

                newUser.AddNewUser();
                lblStatus.Visibility = Visibility.Visible;
                lblStatus.Foreground = new SolidColorBrush(Colors.Green);
                lblStatus.Content = "User succesfully added!";
            }
            catch (Exception ex)
            {
                lblStatus.Visibility = Visibility.Visible;
                lblStatus.Foreground = new SolidColorBrush(Colors.Red);
                lblStatus.Content = ex.Message + " Failed to add new User! User Already Exists.";
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            var adminMenu = new AdminMenu();
            adminMenu.Show();
            this.Close();
        }
    }
}
