using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SchuhLadenApp
{

    public class UserInformation
    {
        public string Userid { get; set; }
        public string Name { get; set; }
        public string Vorname { get; set; }
        public string Strasse { get; set; }
        public string Hausnummer { get; set; }
        public string Plz { get; set; }
        public string Anstellungszeit { get; set; }
        public string Lohngehalt { get; set; }
        public string Userstatus { get; set; }
        public string Account { get; set; }
    }


    public partial class EditUserInfo : Window
    {
        public List<string> userInfo { get; set; } = new List<string>();
        public ObservableCollection<UserInformation> Users { get; set; } = new ObservableCollection<UserInformation>();


        public EditUserInfo(List<string> userInfo)
        {
            this.userInfo = userInfo;
            InitializeComponent();

            Users.Add(new UserInformation
            {
                Userid = userInfo[0],
                Name = userInfo[1],
                Vorname = userInfo[2],
                Strasse = userInfo[3],
                Hausnummer = userInfo[4],
                Plz = userInfo[5],
                Anstellungszeit = userInfo[6],
                Lohngehalt = userInfo[7],
                Userstatus = userInfo[8],
                Account = userInfo[9]
            });

            DataContext = this; // Add this line
            generateUserGridView();
        }

        public void generateUserGridView()
        {
            // Create columns
            gridEditUsercell.Columns.Add(new DataGridTextColumn { Header = "Userid", IsReadOnly = true });
            gridEditUsercell.Columns.Add(new DataGridTextColumn { Header = "Name" });
            gridEditUsercell.Columns.Add(new DataGridTextColumn { Header = "Vorname" });
            gridEditUsercell.Columns.Add(new DataGridTextColumn { Header = "Strasse" });
            gridEditUsercell.Columns.Add(new DataGridTextColumn { Header = "Hausnummer" });
            gridEditUsercell.Columns.Add(new DataGridTextColumn { Header = "Plz" });
            gridEditUsercell.Columns.Add(new DataGridTextColumn { Header = "Anstellungszeit" });
            gridEditUsercell.Columns.Add(new DataGridTextColumn { Header = "Lohngehalt" });
            gridEditUsercell.Columns.Add(new DataGridTextColumn { Header = "Userstatus" });
            gridEditUsercell.Columns.Add(new DataGridTextColumn { Header = "Account" });

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (gridEditUsercell.Items.Count > 0)
            {
                dynamic row = gridEditUsercell.Items[0];
                User user = getUserInfo(row);
                user.updateUser();
                MessageBox.Show("User " + user.getVorname() + " updated successfully!");
            }

            ShowUsersPanel showUsersPanel = new ShowUsersPanel();
            showUsersPanel.Show();
            this.Close();
        }

        private User getUserInfo(dynamic row)
        {
            string userid = row.Userid;
            string name = row.Name;
            string vorname = row.Vorname;
            string strasse = row.Strasse;
            string hausnummer = row.Hausnummer;
            int plz = Convert.ToInt32(row.Plz);
            string anstellungszeit = row.Anstellungszeit;
            double lohngehalt = Convert.ToDouble(row.Lohngehalt);
            string userstatus = row.Userstatus;
            string account = row.Account;

            User user = new User(userid, name, vorname, strasse, hausnummer, plz,
                anstellungszeit, lohngehalt, userstatus, account);

            return user;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            ShowUsersPanel showUsersPanel = new ShowUsersPanel();
            showUsersPanel.Show();
            this.Close();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
