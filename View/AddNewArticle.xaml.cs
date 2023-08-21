using System;
using System.Windows;
using System.Windows.Media;
using SchuhLadenApp.Model;
using SchuhLadenApp.Controller;

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
            try
            {
                string Name = tbxName.Text;
                string Supplier = tbxSupplier.Text;
                double Price = Convert.ToDouble(tbxPrice.Text);
                int Quantity = Convert.ToInt32(tbxQuantity.Text);

                DatabaseHelper databaseHelper = new DatabaseHelper();

                databaseHelper.OpenConnection();

                Article NewArticle = new Article(Name, Supplier, Price, Quantity);

                NewArticle.AddNewArticle();
                lblStatus.Visibility = Visibility.Visible;
                lblStatus.Foreground = new SolidColorBrush(Colors.Green);
                lblStatus.Content = "Article succesfully added!";
            }
            catch (Exception ex)
            {
                lblStatus.Visibility = Visibility.Visible;
                lblStatus.Foreground = new SolidColorBrush(Colors.Red);
                lblStatus.Content = ex.Message + " Failed to add new Article! Article Already Exists.";
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            var adminMenu = new AdminMenu();
            adminMenu.Show();
            this.Close();
        }
    }
}
