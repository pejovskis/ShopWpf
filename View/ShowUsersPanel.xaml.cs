using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for ShowUsersPanel.xaml
    /// </summary>
    public partial class ShowUsersPanel : Window
    {

        public ShowUsersPanel()
        {
            InitializeComponent();
            DataContext = this;
            MainController.GenerateUserGridView(gridShowUsers);
        }

        private void btnEditUser_Click(object sender, RoutedEventArgs e)
        {
           MainController.EditUser(this, gridShowUsers);
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainController.AdminMenuBtnBack(this);
        }

    }
}
