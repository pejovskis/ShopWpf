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
            generateUserGridView();
        }

        private void generateUserGridView()
        {

            List<UserViewModel> userList = User.retrieveUsersFromDb().Select(u => new UserViewModel(u)).ToList();

            gridShowUsers.Items.Clear();
            foreach (UserViewModel userViewModel in userList)
            {
                gridShowUsers.Items.Add(userViewModel);
            }
        }

        private void gridShowUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnEditUser_Click(object sender, RoutedEventArgs e)
        {
            if (gridShowUsers.SelectedItems.Count > 0)
            {
                UserViewModel selectedUser = (UserViewModel)gridShowUsers.SelectedItems[0];
                List<string> userInfo = new List<string>
            {
                selectedUser.UserId,
                selectedUser.Name,
                selectedUser.Vorname,
                selectedUser.Strasse,
                selectedUser.Hausnummer,
                selectedUser.Plz.ToString(),
                selectedUser.Anstellungszeit,
                selectedUser.Lohngehalt.ToString(),
                selectedUser.UserStatus,
                selectedUser.Account
            };

                EditUserInfo editUsersListCellForm = new EditUserInfo(userInfo);
                editUsersListCellForm.userInfo = userInfo;
                editUsersListCellForm.Show();
                this.Close();
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            AdminMenu adminMenu = new AdminMenu();
            adminMenu.Show();
            this.Close();
        }

        private void gridShowUsers_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
