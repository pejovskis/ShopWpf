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
using SchuhLadenApp.Model;

namespace SchuhLadenApp.View
{
    /// <summary>
    /// Interaction logic for ShowAllArticles.xaml
    /// </summary>
    public partial class ShowAllArticles : Window
    {
        public ShowAllArticles()
        {
            InitializeComponent();
            DataContext = this;
            generateArticleGridView();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void generateArticleGridView()
        {

            List<ArticleViewModel> articleList = Artikel.retrieveArtikelFromDb().Select(a => new ArticleViewModel(a)).ToList();

            gridArticleView.Items.Clear();
            foreach (ArticleViewModel articleViewModel in articleList)
            {
                gridArticleView.Items.Add(articleViewModel);
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (gridArticleView.SelectedItems.Count > 0)
            {
                ArticleViewModel selectedArticle = (ArticleViewModel)gridArticleView.SelectedItems[0];
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
