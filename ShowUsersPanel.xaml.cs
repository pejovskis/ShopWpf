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
    }
}
