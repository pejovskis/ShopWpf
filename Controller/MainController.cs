using SchuhLadenApp.Model;
using SchuhLadenApp.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WpfApp1;

namespace SchuhLadenApp.Controller
{
    internal class MainController
    {

        // Admin Menu Functions
        public static void CheckUserLogin(Label lblLoggedInUser, Button btnAddNewArticle, Button btnAddNewUser)
        {
            if (MainWindow.LoggedInUser != null)
            {
                lblLoggedInUser.Content = MainWindow.LoggedInUser.GetLastName();
                if (MainWindow.LoggedInUser.GetUserStatus() != "admin")
                {
                    btnAddNewArticle.Visibility = Visibility.Hidden;
                    btnAddNewUser.Visibility = Visibility.Hidden;
                }
            }
        }

        public static void ShowUsersPanel(Window window)
        {
            var showUsersPanel = new ShowUsersPanel();
            showUsersPanel.Show();
            window.Close();
        }

        public static void UserLogout(Window window)
        {
            MainWindow.LoggedInUser = null;
            var mainWindow = new MainWindow();
            mainWindow.Show();
            window.Close();
        }

        public static void AddNewUser(Window window)
        {
            var addNewUserPanel = new AddNewUserPanel();
            addNewUserPanel.Show();
            window.Close();
        }

        public static void ShowArticlesPanel(Window window)
        {
            var showAllArticles = new ShowAllArticles();
            showAllArticles.Show();
            window.Close();
        }

        public static void AddNewArticle(Window window)
        {
            var addnewArticle = new AddNewArticle();
            addnewArticle.Show();
            window.Close();
        }

        public static void SellArticle(Window window)
        {
            var sellArticle = new SellArticle();
            sellArticle.Show();
            window.Close();
        }

        // Show Users Panel Functions
        public static void GenerateUserGridView(DataGrid dataGrid)
        {

            List<UserViewModel> userList = User.RetrieveUsersFromDB().Select(u => new UserViewModel(u)).ToList();

            dataGrid.Items.Clear();
            foreach (UserViewModel userViewModel in userList)
            {
                dataGrid.Items.Add(userViewModel);
            }
        }

        public static void EditUser(Window window, DataGrid dataGrid)
        {
            if (dataGrid.SelectedItems.Count > 0)
            {
                UserViewModel selectedUser = (UserViewModel)dataGrid.SelectedItems[0];
                List<string> userInfo = new List<string>
            {
                selectedUser.UserId,
                selectedUser.Name,
                selectedUser.Vorname,
                selectedUser.Strasse,
                selectedUser.Hausnummer,
                selectedUser.Plz.ToString(),
                selectedUser.Anstellungszeit,
                selectedUser.Lohngehalt.ToString(),
                selectedUser.UserStatus,
                selectedUser.Account
            };

                var editUsersListCellForm = new EditUserInfo(userInfo);
                editUsersListCellForm.userInfo = userInfo;
                editUsersListCellForm.Show();
                window.Close();
            }
        }

        public static void AdminMenuBtnBack(Window window)
        {
            var adminMenu = new AdminMenu();
            adminMenu.Show();
            window.Close();
        }

        // Edit User Panel Functions

        // Show Articles Panel Functions
        public static void GenerateArticleGridView(DataGrid dataGrid)
        {

            List<ArticleViewModel> articleList = Article.RetrieveArticleFromDB().Select(a => new ArticleViewModel(a)).ToList();

            dataGrid.Items.Clear();
            foreach (ArticleViewModel articleViewModel in articleList)
            {
                dataGrid.Items.Add(articleViewModel);
            }
        }

        public static void ShowArticleBtnEdit(Window window, DataGrid dataGrid)
        {
            if (dataGrid.SelectedItems.Count > 0)
            {
                ArticleViewModel selectedArticle = (ArticleViewModel)dataGrid.SelectedItems[0];
                List<string> articleInfo = new List<string>
            {
                selectedArticle.ArtikelId,
                selectedArticle.Name,
                selectedArticle.Lieferant,
                selectedArticle.Preis.ToString(),
                selectedArticle.Menge.ToString()
            };

                EditArticleInfo editArticleInfo = new EditArticleInfo(articleInfo);
                editArticleInfo.articleInfo = articleInfo;
                editArticleInfo.Show();
                window.Close();
            }
        }

        public static void ShowArticleBtnBack(Window window)
        {
            var adminMenu = new AdminMenu();
            adminMenu.Show();
            window.Close();
        }

        // Sell Articles 
        public static void SellArticleBtnBack(Window window)
        {
            var adminMenu = new AdminMenu();
            adminMenu.Show();
            window.Close();
        }

        public static void SellArticleBtnSell(TextBox tbxArticleId, TextBox tbxQuantity)
        {
            string articleId = tbxArticleId.Text.ToString();
            int quantity = Convert.ToInt32(tbxQuantity.Text.ToString());

            Article article = new Article();
            article = article.getExistingArticle(articleId);

            if (article != null)
            {
                if (article.GetQuantity() >= quantity)
                {
                    article.SellArticle(quantity);
                    MessageBox.Show("Article " + article.GetName() + " sold. Quantity: " + article.GetQuantity());
                }
                else
                {
                    MessageBox.Show("Article is sold out. Or quantity out of stock. Please update the database if the quantity is already changed.");
                }
            }
            else
            {
                MessageBox.Show("Invalid ArticleID");
            }
        }



    }
}
