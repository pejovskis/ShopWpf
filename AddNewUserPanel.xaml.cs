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

namespace SchuhLadenApp
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
                string name = tbxName.Text;
                string firstName = tbxFirstname.Text;
                string street = tbxStreet.Text;
                string housenum = tbxHousenum.Text;
                int postcode = Convert.ToInt32(tbxPostcode.Text);
                string employedOn = tbxEmployedOn.Text;
                double salary = Convert.ToDouble(tbxSalary.Text);
                string userstatus = tbxUserstatus.Text;
                string account = tbxAccount.Text;
                string password = tbxPassword.Text;

                DatabaseHelper databaseHelper = new DatabaseHelper();

                databaseHelper.OpenConnection();

                User newUser = new User(name, firstName, street, housenum, postcode,
                    employedOn, salary, userstatus, password, account);

                newUser.setUserId(newUser.CalculateUserId());

                newUser.addNewUser();
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
            AdminMenu adminMenu = new AdminMenu();
            adminMenu.Show();
            this.Close();
        }
    }
}
