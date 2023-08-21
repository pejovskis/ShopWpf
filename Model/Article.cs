using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Text;
using SchuhLadenApp.Controller;

namespace SchuhLadenApp.Model
{
    internal class Article
    {

        private string ArticleId;
        private string Name;
        private string Supplier;
        private double Price;
        private int Quantity;

        public Article() { }
        public Article(string ArticleId, string Name, string Supplier, double Price, int Quantity)
        {
            this.ArticleId = ArticleId;
            this.Name = Name;
            this.Supplier = Supplier;
            this.Price = Price;
            this.Quantity = Quantity;
        }
        public Article(string Name, string Supplier, double Price, int Quantity)
        {
            this.Name = Name;
            this.Supplier = Supplier;
            this.Price = Price;
            this.Quantity = Quantity;
        }

        public static List<Article> RetrieveArticleFromDB()
        {

            List<Article> articles = new List<Article>();

            DatabaseHelper databaseHelper = new DatabaseHelper();

            using (SqliteConnection connection = databaseHelper.OpenConnection())
            {
                string query = "SELECT * FROM article";

                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {

                            string ArticleId = reader.GetString(0);
                            string Name = reader.GetString(1);
                            string Supplier = reader.GetString(2);
                            double Price = reader.GetDouble(3);
                            int Quantity = reader.GetInt32(4);

                            Article article = new Article(ArticleId, Name, Supplier, Price, Quantity);

                            articles.Add(article);

                        }

                    }
                }
                databaseHelper.CloseConnection(connection);
            }

            return articles;
        }

        public bool CheckIfArticleExists()
        {
            List<Article> articles = RetrieveArticleFromDB();

            foreach (Article article in articles)
            {
                if (this.ArticleId == article.ArticleId)
                {
                    return true;
                }
            }

            return false;

        }

        public Article getExistingArticle(string ArticleIdInput)
        {
            List<Article> artikels = RetrieveArticleFromDB();

            foreach (Article artikel in artikels)
            {

                if (artikel.GetArticleId() == ArticleIdInput)
                {

                    return artikel;
                }
            }

            return null;
        }

        public void AddNewArticle()
        {
            DatabaseHelper databaseHelper = new DatabaseHelper();

            using (SqliteConnection connection = databaseHelper.OpenConnection())
            {
                string query = "INSERT INTO article(name, supplier, price, quantity) " +
                    "VALUES (@LastName, @Supplier, @Price, @Quantity) ";

                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LastName", this.Name);
                    command.Parameters.AddWithValue("@Supplier", this.Supplier);
                    command.Parameters.AddWithValue("@Price", this.Price);
                    command.Parameters.AddWithValue("@Quantity", this.Quantity);

                    command.ExecuteNonQuery(); // Execute the INSERT query
                }
                databaseHelper.CloseConnection(connection);
            }
        }

        public void UpdateArticle()
        {
            DatabaseHelper databaseHelper = new DatabaseHelper();

            using (SqliteConnection connection = databaseHelper.OpenConnection())
            {
                string query = "UPDATE article SET name=@Name, supplier=@Supplier, price=@Price, quantity=@Quantity " +
                    "WHERE articleid=@ArticleId";

                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ArticleId", this.ArticleId);
                    command.Parameters.AddWithValue("@Name", this.Name);
                    command.Parameters.AddWithValue("@Supplier", this.Supplier);
                    command.Parameters.AddWithValue("@Price", this.Price);
                    command.Parameters.AddWithValue("@Quantity", this.Quantity);

                    command.ExecuteNonQuery(); // Execute the INSERT query
                }
                databaseHelper.CloseConnection(connection);
            }
        }

        public void SellArticle(int Quantity)
        {

            this.Quantity -= Quantity;

            DatabaseHelper databaseHelper = new DatabaseHelper();

            using (SqliteConnection connection = databaseHelper.OpenConnection())
            {
                string query = "UPDATE article SET quantity=@Quantity " +
                    "WHERE articleid=@ArticleId";

                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Quantity", this.Quantity);
                    command.Parameters.AddWithValue("@ArticleId", this.ArticleId);

                    command.ExecuteNonQuery(); // Execute the INSERT query
                }
                databaseHelper.CloseConnection(connection);
            }
        }

        public void SetName(string Name)
        {
            this.Name = Name;
        }

        public void SetSupplier(string Supplier)
        {
            this.Supplier = Supplier;
        }

        public void SetPrice(double Price)
        {
            this.Price = Price;
        }

        public void SetQuantity(int Quantity)
        {
            this.Quantity = Quantity;
        }

        public string GetArticleId()
        {
            return this.ArticleId;
        }

        public string GetName()
        {
            return this.Name;
        }

        public string GetSupplier()
        {
            return this.Supplier;
        }

        public double GetPrice()
        {
            return this.Price;
        }

        public int GetQuantity()
        {
            return this.Quantity;
        }
    }
}