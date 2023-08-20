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

namespace SchuhLadenApp
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
                lblLoggedInUser.Content = MainWindow.LoggedInUser.getStrasse();
            }
            else
            {
                lblLoggedInUser.Content = "Not logged in";
            }
        }

        private void btnShowAllUsers_Click(object sender, RoutedEventArgs e)
        {
            ShowUsersPanel showUsersPanel = new ShowUsersPanel();
            showUsersPanel.Show();
            this.Close();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.LoggedInUser = null;
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void btnAddNewUser_Click(object sender, RoutedEventArgs e)
        {
            AddNewUserPanel addNewUserPanel = new AddNewUserPanel();
            addNewUserPanel.Show();
            this.Close();
        }

        private void btnShowAllArticles_Click(object sender, RoutedEventArgs e)
        {
            ShowAllArticles showAllArticles = new ShowAllArticles();
            showAllArticles.Show();
            this.Close();
        }

        private void btnAddNewArticle_Click(object sender, RoutedEventArgs e)
        {
            AddNewArticle addNewArticle = new AddNewArticle();
            addNewArticle.Show();
            this.Close();
        }
    }
}
