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
using SchuhLadenApp.Model;

namespace SchuhLadenApp.View
{
    /// <summary>
    /// Interaction logic for EditArticleInfo.xaml
    /// </summary>

    public class ArticleInformation
    {
        public string ArticleId { get; set; }
        public string Name { get; set; }
        public string Supplier { get; set; }
        public string Price { get; set; }
        public string Quantity { get; set; }
    }

    public partial class EditArticleInfo : Window
    {

        public List<string> articleInfo { get; set; } = new List<string>();
        public ObservableCollection<ArticleInformation> Articles { get; set; } = new ObservableCollection<ArticleInformation>();

        public EditArticleInfo(List<string> articleInfo)
        {
            this.articleInfo = articleInfo;
            InitializeComponent();

            Articles.Add(new ArticleInformation
            {
                ArticleId = articleInfo[0],
                Name = articleInfo[1],
                Supplier = articleInfo[2],
                Price = articleInfo[3],
                Quantity = articleInfo[4],
            });

            DataContext = this;

        }

        private Artikel getUserInfo(dynamic row)
        {
            string ArticleId = row.ArticleId;
            string Name = row.Name;
            string Lieferant = row.Lieferant;
            double Price = Convert.ToDouble(row.Price);
            int Quantity = Convert.ToInt32(row.Quantity);

            Artikel article = new Artikel(ArticleId, Name, Lieferant, Price, Quantity);

            return article;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Articles.Count > 0)
            {
                ArticleInformation articleInformation = Articles[0];
                Artikel article = new Artikel(
                    articleInformation.ArticleId,
                    articleInformation.Name,
                    articleInformation.Supplier,
                    Convert.ToDouble(articleInformation.Price),
                    Convert.ToInt32(articleInformation.Quantity)
                );

                article.updateArticle();
                MessageBox.Show("Article " + article.getName() + " updated successfully!");
            }
            var showAllArticles = new ShowAllArticles();
            showAllArticles.Show();
            this.Close();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            var showAllArticles = new ShowAllArticles();
            showAllArticles.Show();
            this.Close();
        }
    }
}
