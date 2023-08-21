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
using WpfApp1;

namespace SchuhLadenApp.View
{
    /// <summary>
    /// Interaction logic for AdminMenu.xaml
    /// </summary>
    public partial class AdminMenu : Window
    {
        public AdminMenu()
        {
            InitializeComponent();
            if (MainWindow.LoggedInUser != null)
            {
                lblLoggedInUser.Content = MainWindow.LoggedInUser.GetLastName();
                if(MainWindow.LoggedInUser.GetUserStatus() != "admin")
                {
                    btnAddNewArticle.Visibility = Visibility.Hidden;
                    btnAddNewUser.Visibility = Visibility.Hidden;
                }
            }
        }

        private void btnShowAllUsers_Click(object sender, RoutedEventArgs e)
        {
            var showUsersPanel = new ShowUsersPanel();
            showUsersPanel.Show();
            this.Close();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.LoggedInUser = null;
            var mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void btnAddNewUser_Click(object sender, RoutedEventArgs e)
        {
            var addNewUserPanel = new AddNewUserPanel();
            addNewUserPanel.Show();
            this.Close();
        }

        private void btnShowAllArticles_Click(object sender, RoutedEventArgs e)
        {
            var showAllArticles = new ShowAllArticles();
            showAllArticles.Show();
            this.Close();
        }

        private void btnAddNewArticle_Click(object sender, RoutedEventArgs e)
        {
            var addnewArticle = new AddNewArticle();
            addnewArticle.Show();
            this.Close();
        }

        private void btnSellArticle_Click(object sender, RoutedEventArgs e)
        {
            var sellArticle = new SellArticle();
            sellArticle.Show();
            this.Close();
        }
    }
}
