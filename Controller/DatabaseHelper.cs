﻿using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchuhLadenApp.Controller
{
    internal class DatabaseHelper
    {

        string connectionString = "Data Source=storeapp.db";

        public SqliteConnection OpenConnection()
        {
            SqliteConnection connection = new SqliteConnection(connectionString);
            connection.Open();
            return connection;
        }

        public void CloseConnection(SqliteConnection connection)
        {
            connection.Close();
        }

    }
}