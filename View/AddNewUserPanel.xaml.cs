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
    /// Interaction logic for AddNewUserPanel.xaml
    /// </summary>
    public partial class AddNewUserPanel : Window
    {
        public AddNewUserPanel()
        {
            InitializeComponent();
        }

        private void btnAddNewUser_Click(object sender, RoutedEventArgs e)
        {
            MainController.AddNewUser(tbxName, tbxFirstname, tbxStreet,
                tbxHousenum, tbxPostcode, tbxEmployedOn, tbxSalary,
                tbxUserstatus, tbxAccount, tbxPassword, lblStatus);
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainController.AddNewUserBackBtn(this);
        }
    }
}
