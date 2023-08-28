using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using SchuhLadenApp.Controller;
using SchuhLadenApp.Model;

namespace SchuhLadenApp.View
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

            DataContext = this;
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

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnUpdateUser_Click(object sender, RoutedEventArgs e)
        {
            if (Users.Count > 0)
            {
                UserInformation userInformation = Users[0];
                User user = new User(
                    userInformation.Userid,
                    userInformation.Name,
                    userInformation.Vorname,
                    userInformation.Strasse,
                    userInformation.Hausnummer,
                    Convert.ToInt32(userInformation.Plz),
                    userInformation.Anstellungszeit,
                    Convert.ToDouble(userInformation.Lohngehalt),
                    userInformation.Userstatus,
                    userInformation.Account
                );

                user.UpdateUser();
                MessageBox.Show("User " + user.GetFirstName() + " updated successfully!");
            }
            var showUsersPanel = new ShowUsersPanel();
            showUsersPanel.Show();
            this.Close();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainController.EditUserInfoBackBtn(this);
        }

    }
}
