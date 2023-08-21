using Microsoft.Data.Sqlite;
using SchuhLadenApp.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchuhLadenApp.Model
{
    public class User
    {

        private string UserId;
        private string LastName;
        private string FirstName;
        private string Street;
        private string HouseNo;
        private int Postcode;
        private string DateOfEmployment;
        private double Salary;
        private string UserStatus;
        private string Account;
        private string Password;

        // Constructor
        public User() { }
        public User(string UserId, string LastName, string FirstName, string Street, string HouseNo,
            int Postcode, string DateOfEmployment, double Salary, string UserStatus, string Password, string Account)
        {
            this.UserId = UserId;
            this.LastName = LastName;
            this.FirstName = FirstName;
            this.Street = Street;
            this.HouseNo = HouseNo;
            this.Postcode = Postcode;
            this.DateOfEmployment = DateOfEmployment;
            this.Salary = Salary;
            this.UserStatus = UserStatus;
            this.Account = Account;
            this.Password = Password;
        }

        public User(string UserId, string LastName, string FirstName, string Street, string HouseNo, 
            int Postcode, string DateOfEmployment, double Salary, string UserStatus, string Account)
        {
            this.UserId = UserId;
            this.LastName = LastName;
            this.FirstName = FirstName;
            this.Street = Street;
            this.HouseNo = HouseNo;
            this.Postcode = Postcode;
            this.DateOfEmployment = DateOfEmployment;
            this.Salary = Salary;
            this.UserStatus = UserStatus;
            this.Account = Account;
        }
        public User(string LastName, string FirstName, string Street, string HouseNo, 
            int Postcode, string DateOfEmployment, double Salary, string UserStatus, string Password, string Account)
        {
            this.LastName = LastName;
            this.FirstName = FirstName;
            this.Street = Street;
            this.HouseNo = HouseNo;
            this.Postcode = Postcode;
            this.DateOfEmployment = DateOfEmployment;
            this.Salary = Salary;
            this.UserStatus = UserStatus;
            this.Account = Account;
            this.Password = Password;
        }
        public User(string UserId, string LastName, string FirstName, string Street, string HouseNo, 
            int Postcode, string DateOfEmployment, double Salary, string UserStatus)
        {
            this.UserId = UserId;
            this.LastName = LastName;
            this.FirstName = FirstName;
            this.Street = Street;
            this.HouseNo = HouseNo;
            this.Postcode = Postcode;
            this.DateOfEmployment = DateOfEmployment;
            this.Salary = Salary;
            this.UserStatus = UserStatus;
        }
        public User(string LastName, string FirstName, string Street, string HouseNo, int Postcode,
            string DateOfEmployment, double Salary, string UserStatus)
        {
            this.LastName = LastName;
            this.FirstName = FirstName;
            this.Street = Street;
            this.HouseNo = HouseNo;
            this.Postcode = Postcode;
            this.DateOfEmployment = DateOfEmployment;
            this.Salary = Salary;
            this.UserStatus = UserStatus;
        }
        public User(string Account, string Password)
        {
            this.Account = Account;
            this.Password = Password;
        }

        // Retrieve all users from the DB 
        public static List<User> RetrieveUsersFromDB()
        {

            List<User> users = new List<User>();

            DatabaseHelper databaseHelper = new DatabaseHelper();

            using (SqliteConnection connection = databaseHelper.OpenConnection())
            {
                string query = "SELECT * FROM user";

                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            string UserId = reader.GetString(0);
                            string LastName = reader.GetString(1);
                            string FirstName = reader.GetString(2);
                            string Street = reader.GetString(3);
                            string HouseNo = reader.GetString(4);
                            int Postcode = reader.GetInt32(5);
                            string DateOfEmployment = reader.GetString(6);
                            double Salary = reader.GetDouble(7);
                            string UserStatus = reader.GetString(8);
                            string Password = reader.GetString(9);
                            string Account = reader.GetString(10);

                            User newUser = new User(UserId, LastName, FirstName, Street, HouseNo, Postcode, 
                                DateOfEmployment, Salary, UserStatus, Password, Account);

                            users.Add(newUser);

                        }

                    }
                }
                databaseHelper.CloseConnection(connection);
            }

            return users;
        }

        // Iterate through the list and check if the userID exists
        public bool CheckIfUserExists()
        {
            List<User> users = RetrieveUsersFromDB();

            foreach (User user in users)
            {
                if (this.UserId == user.UserId)
                {
                    return true;
                }
            }

            return false;

        }

        // Add new User to the DB
        public void AddNewUser()
        {
            DatabaseHelper databaseHelper = new DatabaseHelper();

            using (SqliteConnection connection = databaseHelper.OpenConnection())
            {
                string query = "INSERT INTO user(lastname, firstname, street, houseno, postcode, " +
                    "dateofemployment, salary, userstatus, account, password) " +
                    "VALUES (@LastName, @FirstName, @Street, @HouseNo, @Postcode, " +
                    "@DateOfEmployment, @Salary, @UserStatus, @Account, @Password) ";

                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LastName", this.LastName);
                    command.Parameters.AddWithValue("@FirstName", this.FirstName);
                    command.Parameters.AddWithValue("@Street", this.Street);
                    command.Parameters.AddWithValue("@HouseNo", this.HouseNo);
                    command.Parameters.AddWithValue("@Postcode", this.Postcode);
                    command.Parameters.AddWithValue("@DateOfEmployment", this.DateOfEmployment);
                    command.Parameters.AddWithValue("@Salary", this.Salary);
                    command.Parameters.AddWithValue("@UserStatus", this.UserStatus);
                    command.Parameters.AddWithValue("@Account", this.Account);
                    command.Parameters.AddWithValue("@Password", this.Password);

                    command.ExecuteNonQuery(); // Execute the INSERT query
                }
                databaseHelper.CloseConnection(connection);
            }
        }

        public void UpdateUser()
        {
            DatabaseHelper databaseHelper = new DatabaseHelper();

            using (SqliteConnection connection = databaseHelper.OpenConnection())
            {
                string query = "UPDATE user SET lastname=@LastName, firstname=@FirstName, street=@Street, houseno=@HouseNo," +
                    "postcode=@Postcode, dateofemployment=@DateOfEmployment, salary=@Salary, userstatus=@UserStatus, " +
                    "account=@Account " +
                    "WHERE userid=@Userid";

                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Userid", this.UserId);
                    command.Parameters.AddWithValue("@LastName", this.LastName);
                    command.Parameters.AddWithValue("@FirstName", this.FirstName);
                    command.Parameters.AddWithValue("@Street", this.Street);
                    command.Parameters.AddWithValue("@HouseNo", this.HouseNo);
                    command.Parameters.AddWithValue("@Postcode", this.Postcode);
                    command.Parameters.AddWithValue("@DateOfEmployment", this.DateOfEmployment);
                    command.Parameters.AddWithValue("@Salary", this.Salary);
                    command.Parameters.AddWithValue("@UserStatus", this.UserStatus);
                    command.Parameters.AddWithValue("@Account", this.Account);

                    command.ExecuteNonQuery(); // Execute the INSERT query
                }
                databaseHelper.CloseConnection(connection);
            }
        }

        // Check UserId and return the user if it exists in the db
        public User GetExistingUser(string UserId)
        {
            List<User> users = RetrieveUsersFromDB();

            foreach (User user in users)
            {

                if (user.UserId == UserId)
                {

                    return user;
                }
            }

            return null;
        }

        // Log in Check
        public bool CheckUserCredentials(string Account, string Password)
        {

            List<User> users = RetrieveUsersFromDB();

            foreach (User user in users)
            {
                if (user.Account == Account && user.Password == Password)
                {
                    return true;
                }
            }

            return false;
        }

        public User GetFullUserCredentials(string Account, string Password)
        {
            DatabaseHelper databaseHelper = new DatabaseHelper();

            using (SqliteConnection connection = databaseHelper.OpenConnection())
            {
                string query = "SELECT * FROM user WHERE Account=@Account AND Password=@Password";

                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Account", Account);
                    command.Parameters.AddWithValue("@Password", Password);

                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string UserId = reader.GetString(0);
                            string LastName = reader.GetString(1);
                            string FirstName = reader.GetString(2);
                            string Street = reader.GetString(3);
                            string HouseNo = reader.GetString(4);
                            int Postcode = reader.GetInt32(5);
                            string DateOfEmployment = reader.GetString(6);
                            double Salary = reader.GetDouble(7);
                            string UserStatus = reader.GetString(8);

                            User user = new User(UserId, LastName, FirstName, Street, HouseNo, Postcode, DateOfEmployment, Salary, UserStatus, Password, Account);

                            return user;
                        }
                    }
                }
                databaseHelper.CloseConnection(connection);
            }

            return null;
        }

        public string GetUserId()
        {
            return this.UserId;
        }

        public string GetLastName()
        {
            return this.LastName;
        }

        public string GetFirstName()
        {
            return this.FirstName;
        }

        public string GetStreet()
        {
            return this.Street;
        }

        public int GetPostcode()
        {
            return this.Postcode;
        }

        public string GetHouseNo()
        {
            return this.HouseNo;
        }

        public string GetDateOfEmployment()
        {
            return this.DateOfEmployment;
        }

        public double GetSalary()
        {
            return this.Salary;
        }

        public string GetUserStatus()
        {
            return this.UserStatus;
        }

        public string GetAccount()
        {
            return this.Account;
        }

        public string GetPassword()
        {
            return this.Password;
        }

        public void SetLastName(string LastName)
        {
            this.LastName = LastName;
        }

        public void SetFirstName(string FirstName)
        {
            this.FirstName = FirstName;
        }

        public void SetHouseNo(string HouseNo)
        {
            this.HouseNo = HouseNo;
        }

        public void SetStreet(string Strasse)
        {
            this.Street = Strasse;
        }

        public void SetPostcode(int Postcode)
        {
            this.Postcode = Postcode;
        }

        public void SetDateOfEmployment(string DateOfEmployment)
        {
            this.DateOfEmployment = DateOfEmployment;
        }

        public void SetSalary(double Salary)
        {
            this.Salary = Salary;
        }

        public void SetUserStatus(string UserStatus)
        {
            this.UserStatus = UserStatus;
        }

        public void SetPassword(string Password)
        {
            this.Password = Password;
        }

        public void SetAccount(string Account)
        {
            this.Account = Account;
        }

        override
        public string ToString()
        {
            return this.UserId + " " +
            this.LastName + " " +
            this.FirstName + " " +
            this.Street + " " +
            this.HouseNo + " " +
            this.Postcode + " " +
            this.DateOfEmployment + " " +
            this.Salary + " " +
            this.UserStatus + " " +
            this.Account + " " +
            this.Password;
        }

    }
}