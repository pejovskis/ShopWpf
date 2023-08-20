using SchuhLadenApp;
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
using SchuhLadenApp.Model;
using SchuhLadenApp.View;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public static User LoggedInUser { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = tbxUsername.Text;
            string password = tbxPassword.Text;

            User user = new User(username, password);
            bool logInApproved = user.checkUserCredentials(username, password);

            if (!logInApproved)
            {
                lblStatus.Content = "Wrong Username or Password";
                lblStatus.Visibility = Visibility.Visible;
            }
            else
            {
                LoggedInUser = user.getFullUserCredentials(username, password);
                AdminMenu adminMenu = new AdminMenu();
                adminMenu.Show();
                this.Close();
            }
        }
    }
}
