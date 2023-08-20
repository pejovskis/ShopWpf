using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SchuhLadenApp
{
    public partial class EditUserInfo : Window
    {
        public List<string> userInfo { get; set; } = new List<string>();

        public EditUserInfo(List<string> userInfo)
        {
            this.userInfo = userInfo;
            InitializeComponent();
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

            gridEditUsercell.Items.Add(new
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
    }
}
