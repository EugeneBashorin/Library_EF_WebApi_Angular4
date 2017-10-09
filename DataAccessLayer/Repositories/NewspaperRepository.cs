﻿using DataAccessLayer.Context;
using DataAccessLayer.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;

namespace DataAccessLayer.Repositories
{
    public class NewspaperRepository : INewspaperRepository
    {
        private PublicationContext db;
        //        string _connectionString;

        public NewspaperRepository(string connectionString)
        {
            this.db = new PublicationContext(connectionString);
            //_connectionString = connectionString;
        }

        public List<Newspaper> GetAll()
        {
            List<Newspaper> newspapersList = new List<Newspaper>();
            var newspapers = db.Newspapers;
            foreach (var newspapersItem in newspapers)
            {
                newspapersList.Add(newspapersItem);
            }
            return newspapersList;
        }

        public Newspaper GetItemById(int? id)
        {
            Newspaper newspaper = db.Newspapers.Find(id);
            return newspaper;
        }

        public void Create(Newspaper newspaper)
        {
            db.Newspapers.Add(newspaper);
            db.SaveChanges();
        }

        public void Update(int? Id, Newspaper newspaper)
        {
            Newspaper newNewspaper = db.Newspapers.Find(Id);
            if (newNewspaper != null)
            {
                newNewspaper.Name = newspaper.Name;
                newNewspaper.Category = newspaper.Category;
                newNewspaper.Publisher = newspaper.Publisher;
                newNewspaper.Price = newspaper.Price;
            }
            db.Entry(newNewspaper).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int? id)
        {
            Newspaper newspaper = db.Newspapers.Find(id);
            if (newspaper != null)
            {
                db.Newspapers.Remove(newspaper);
                db.SaveChanges();
            }
        }

        public List<Newspaper> FilterByPublisher(string publisherName)
        {
            List<Newspaper> filteredPublisherList = new List<Newspaper>();
            var newspapersList = db.Newspapers;
            foreach (var newspapersItem in newspapersList)
            {
                if (newspapersItem.Publisher == publisherName)
                {
                    filteredPublisherList.Add(newspapersItem);
                }
            }
            return filteredPublisherList;
        }

        public List<string> GetAllPublishers()
        {
            List<string> publishersList = new List<string>();
            var newspaperList = db.Newspapers;
            foreach (var newspapersItem in newspaperList)
            {
                publishersList.Add(newspapersItem.Publisher);
            }
            return publishersList;
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
        /*
        public List<Newspaper> GetAll()
        {
            List<Newspaper> newspapersList;
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    newspapersList = new List<Newspaper>();
                    if (connection != null)
                    {
                        string newspapersSelectAllExpression = "SELECT * FROM Newspapers";
                        SqlCommand command = new SqlCommand(newspapersSelectAllExpression, connection);
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                newspapersList.Add(new Newspaper { Id = (int)reader.GetValue(0), Name = (string)reader.GetValue(1), Category = (string)reader.GetValue(2), Publisher = (string)reader.GetValue(3), Price = (int)reader.GetValue(4) });
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("problem with sql: " + ex);
            }
            return newspapersList;
        }

        public Newspaper GetItemById(int? id)
        {
            Newspaper newspaper = new Newspaper();
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    if (connection != null)
                    {
                        string searchNewspaperByIdExpression = $"SELECT * FROM Newspapers WHERE Id = '{id}'";
                        SqlCommand command = new SqlCommand(searchNewspaperByIdExpression, connection);
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                newspaper.Id = (int)reader.GetValue(0);
                                newspaper.Name = (string)reader.GetValue(1);
                                newspaper.Category = (string)reader.GetValue(2);
                                newspaper.Publisher = (string)reader.GetValue(3);
                                newspaper.Price = (int)reader.GetValue(4);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("problem with sql: " + ex);
            }
            return newspaper;
        }

        public void Create(Newspaper newspaper)
        {
            string createNewspaperExpression = $"INSERT INTO Newspapers ([Name], [Category], [Publisher],[Price]) VALUES('{newspaper.Name}','{newspaper.Category}','{newspaper.Publisher}','{newspaper.Price}')";
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(createNewspaperExpression, connection);
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        throw new Exception(e.Message);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("problem with sql: " + ex);
            }
        }

        public void Update(int? Id, Newspaper newspaper)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    if (connection != null)
                    {
                        string editNewspaperExpression = $"UPDATE Newspapers SET Name = '{newspaper.Name}', Category = '{newspaper.Category}', Publisher = '{newspaper.Publisher}', Price = '{newspaper.Price}' WHERE Id = '{Id}'";
                        SqlCommand command = new SqlCommand(editNewspaperExpression, connection);
                        try
                        {
                            command.ExecuteNonQuery();
                        }
                        catch (Exception e)
                        {
                            throw new Exception(e.Message);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("problem with sql: " + ex);
            }
        }

        public void Delete(int? id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    if (connection != null)
                    {
                        string deleteNewspaperExpression = $"DELETE FROM Newspapers WHERE Id = '{id}'";
                        SqlCommand command = new SqlCommand(deleteNewspaperExpression, connection);
                        try
                        {
                            command.ExecuteNonQuery();
                        }
                        catch (Exception e)
                        {
                            throw new Exception(e.Message);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("problem with sql: " + ex);
            }
        }

        public List<Newspaper> FilterByPublisher(string publisherName)
        {
            List<Newspaper> newspaperList;
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    newspaperList = new List<Newspaper>();
                    if (connection != null)
                    {
                        string selectAllExpression = $"SELECT * FROM Newspapers WHERE Publisher = '{publisherName}'";
                        SqlCommand command = new SqlCommand(selectAllExpression, connection);
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                newspaperList.Add(new Newspaper { Id = (int)reader.GetValue(0), Name = (string)reader.GetValue(1), Category = (string)reader.GetValue(2), Publisher = (string)reader.GetValue(3), Price = (int)reader.GetValue(4) });
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("problem with sql: " + ex);
            }
            return newspaperList;
        }

        public List<string> GetAllPublishers()
        {
            List<string> publishersList;
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    publishersList = new List<string>();
                    if (connection != null)
                    {
                        string selectAllExpression = $"SELECT DISTINCT Publisher FROM Newspapers";
                        SqlCommand command = new SqlCommand(selectAllExpression, connection);
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                publishersList.Add(reader.GetString(0));
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("problem with sql: " + ex);
            }
            return publishersList;
        }
    }
}
*/