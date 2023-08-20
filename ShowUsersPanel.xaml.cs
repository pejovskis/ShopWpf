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

            List<User> userList = User.retrieveUsersFromDb();

            gridShowUsers.Items.Clear();

            // Add users to the DataGrid
            foreach (User user in userList)
            {
                gridShowUsers.Items.Add(user);
            }
        }

        private void gridShowUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
