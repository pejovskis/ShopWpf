using SchuhLadenApp.Controller;
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
            MainController.CheckUserLogin(lblLoggedInUser, btnAddNewArticle, btnAddNewUser);
        }

        private void btnShowAllUsers_Click(object sender, RoutedEventArgs e)
        {
            MainController.ShowUsersPanel(this);
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            MainController.UserLogout(this);
        }

        private void btnAddNewUser_Click(object sender, RoutedEventArgs e)
        {
            MainController.AddNewUser(this);
        }

        private void btnShowAllArticles_Click(object sender, RoutedEventArgs e)
        {
            MainController.ShowArticlesPanel(this);
        }

        private void btnAddNewArticle_Click(object sender, RoutedEventArgs e)
        {
            MainController.AddNewArticle(this);
        }

        private void btnSellArticle_Click(object sender, RoutedEventArgs e)
        {
            MainController.SellArticle(this);
        }
    }
}
