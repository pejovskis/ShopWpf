using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchuhLadenApp.Model
{

    public class UserViewModel
    {

        private User _user;

        public UserViewModel(User user)
        {
            _user = user;
        }

        public string UserId
        {
            get { return _user.GetUserId(); }
        }

        public string Name
        {
            get { return _user.GetLastName(); }
            set { _user.SetLastName(value); }
        }

        public string Vorname
        {
            get { return _user.GetFirstName(); }
            set { _user.SetFirstName(value); }
        }

        public string Strasse
        {
            get { return _user.GetStreet(); }
            set { _user.SetStreet(value); }
        }

        public string Hausnummer
        {
            get { return _user.GetHouseNo(); }
            set { _user.SetHouseNo(value); }
        }

        public int Plz
        {
            get { return _user.GetPostcode(); }
            set { _user.SetPostcode(value); }
        }

        public string Anstellungszeit
        {
            get { return _user.GetDateOfEmployment(); }
            set { _user.SetDateOfEmployment(value); }
        }

        public double Lohngehalt
        {
            get { return _user.GetSalary(); }
            set { _user.SetSalary(value); }
        }

        public string UserStatus
        {
            get { return _user.GetUserStatus(); }
            set { _user.SetUserStatus(value); }
        }

        public string Account
        {
            get { return _user.GetAccount(); }
            set { _user.SetAccount(value); }
        }

        public string Password
        {
            get { return _user.GetPassword(); }
            set { _user.SetPassword(value); }
        }

    }
}
