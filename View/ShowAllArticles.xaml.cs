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
using SchuhLadenApp.Controller;

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
            MainController.GenerateArticleGridView(gridArticleView);
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            MainController.ShowArticleBtnEdit(this, gridArticleView);
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainController.ShowArticleBtnBack(this);
        }

        private void gridArticleView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
