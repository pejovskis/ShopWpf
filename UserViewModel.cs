using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchuhLadenApp
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
            get { return _user.getUserId(); }
            set { _user.setUserId(value); }
        }

        public string Name
        {
            get { return _user.getName(); }
            set { _user.setName(value); }
        }

        public string Vorname
        {
            get { return _user.getVorname(); }
            set { _user.setVorname(value); }
        }

        public string Strasse
        {
            get { return _user.getStrasse(); }
            set { _user.setStrasse(value); }
        }

        public string Hausnummer
        {
            get { return _user.getHausnummer(); }
            set { _user.setHausnummer(value); }
        }

        public int Plz
        {
            get { return _user.getPlz(); }
            set { _user.setPlz(value); }
        }

        public string Anstellungszeit
        {
            get { return _user.getAnstellungsZeit(); }
            set { _user.setAnstellungsZeit(value); }
        }

        public double Lohngehalt
        {
            get { return _user.getLohnGehalt(); }
            set { _user.setLohnGehalt(value); }
        }

        public string UserStatus
        {
            get { return _user.getUserStatus(); }
            set { _user.setUserStatus(value); }
        }

        public string Account
        {
            get { return _user.getAccount(); }
            set { _user.setAccount(value); }
        }

        public string Password
        {
            get { return _user.getPassword(); }
            set { _user.setPassword(value); }
        }

    }
}
