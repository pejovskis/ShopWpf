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

            List<ArticleViewModel> articleViewModels = Artikel.retrieveArtikelFromDb().Select(a => new ArticleViewModel(a)).ToList();

            gridArticleView.Items.Clear();
            foreach (ArticleViewModel articleViewModel in articleViewModels)
            {
                gridArticleView.Items.Add(articleViewModel);
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
