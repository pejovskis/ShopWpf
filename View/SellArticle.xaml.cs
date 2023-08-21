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

        private void btnSellArticle_Click(object sender, RoutedEventArgs e)
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
