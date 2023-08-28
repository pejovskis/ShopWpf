using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for SellArticle.xaml
    /// </summary>
    public partial class SellArticle : Window
    {
        ObservableCollection<Article> articleList = new ObservableCollection<Article>();
        public SellArticle()
        {
            InitializeComponent();
            this.GridSellArticles.ItemsSource = articleList;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainController.SellArticleBtnBack(this);
        }

        private void btnSellArticle_Click(object sender, RoutedEventArgs e)
        {
            MainController.SellArticleBtnSell(tbxArticleId, tbxQuantity);
        }

        private void btnAddArticle_Click(object sender, RoutedEventArgs e)
        {

            String articleId = tbxArticleId.Text;
            int quantity = 1;

            Article newArticle = Article.RetrieveInfosFromArticleFromDB(articleId);

            if (tbxQuantity.Text != "")
            {
                quantity = Convert.ToInt32(tbxQuantity.Text);
            }

            if (newArticle != null)
            {
                articleList.Add(newArticle);
            }
            else
            {
                MessageBox.Show("Item Not Found!");
            }    

        }
    }
}
