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
    /// Interaction logic for AddNewArticle.xaml
    /// </summary>
    public partial class AddNewArticle : Window
    {
        public AddNewArticle()
        {
            InitializeComponent();
        }

        private void btnAddNewUser_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = tbxName.Text;
                string supplier = tbxSupplier.Text;
                double price = Convert.ToDouble(tbxPrice.Text);
                int quantity = Convert.ToInt32(tbxQuantity.Text);

                DatabaseHelper databaseHelper = new DatabaseHelper();

                databaseHelper.OpenConnection();

                Artikel newArticle = new Artikel(name, supplier, price, quantity);

                newArticle.setArtikelId(newArticle.CalculateArtikelId());

                newArticle.addNewArtikel();
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
            AdminMenu adminMenu = new AdminMenu();
            adminMenu.Show();
            this.Close();
        }
    }
}
