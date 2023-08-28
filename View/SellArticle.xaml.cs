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
using SchuhLadenApp.Controller;
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
            MainController.SellArticleBtnBack(this);
        }

        private void btnSellArticle_Click(object sender, RoutedEventArgs e)
        {
            MainController.SellArticleBtnSell(tbxArticleId, tbxQuantity);
        }
    }
}
