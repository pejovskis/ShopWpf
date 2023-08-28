using System;
using System.Windows;
using System.Windows.Media;
using SchuhLadenApp.Model;
using SchuhLadenApp.Controller;
using System.Windows.Controls;

namespace SchuhLadenApp.View
{
    /// <summary>
    /// Interaction logic for AddNewArticle.xaml
    /// </summary>
    public partial class AddNewArticle : Window
    {
        public AddNewArticle()
        {
            InitializeComponent();
        }

        private void btnAddNewArticle_Click(object sender, RoutedEventArgs e)
        {
            MainController.AddNewArticle(tbxPrice, tbxQuantity, tbxName, tbxSupplier, lblStatus);
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainController.AddNewArticleBackBtn(this);
        }
    }
}
