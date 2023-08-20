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
using SchuhLadenApp.Model;

namespace SchuhLadenApp.View
{
    /// <summary>
    /// Interaction logic for SellArticle.xaml
    /// </summary>
    public partial class SellArticle : Window
    {
        public SellArticle()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            var adminMenu = new AdminMenu();
            adminMenu.Show();
            this.Close();
        }

        private void btnAddNewUser_Click(object sender, RoutedEventArgs e)
        {
            string articleId = tbxArticleId.Text;

            Artikel article = new Artikel();

            article.getExistingArticle(articleId);

            if(article.getMenge() > 0)
            {
                article.sellArticle(articleId);
            } else
            {
                MessageBox.Show("Article sold out");
            }

        }
    }
}
