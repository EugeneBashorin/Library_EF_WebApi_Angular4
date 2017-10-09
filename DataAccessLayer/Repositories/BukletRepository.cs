using DataAccessLayer.Context;
using DataAccessLayer.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DataAccessLayer.Repositories
{
    public class BukletRepository : IBukletRepository
    {
        //string _connectionString;
        private PublicationContext db;

        public BukletRepository(string connectionString)
        {
            this.db = new PublicationContext(connectionString);
            //_connectionString = connectionString;
        }

        public List<Buklet> GetAll()
        {
            List<Buklet> bukletsList = new List<Buklet>();
            var buklets = db.Buklets;
            foreach (var bukletsItem in buklets)
            {
                bukletsList.Add(bukletsItem);
            }
            return bukletsList;
        }

        public Buklet GetItemById(int? id)
        {
            Buklet buklet = db.Buklets.Find(id); //=new Book();
            return buklet;
        }

        public void Create(Buklet buklet)
        {
            db.Buklets.Add(buklet);
            db.SaveChanges();
        }

        public void Update(int? Id, Buklet buklet)
        {
            Buklet newBuklet = db.Buklets.Find(Id);
            if (newBuklet != null)
            {
                newBuklet.Name = buklet.Name;
                newBuklet.Author = buklet.Author;
                newBuklet.Publisher = buklet.Publisher;
                newBuklet.Price = buklet.Price;
            }
            db.Entry(newBuklet).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int? id)
        {
            Buklet buklet = db.Buklets.Find(id);
            if (buklet != null)
            {
                db.Buklets.Remove(buklet);
                db.SaveChanges();
            }
        }

        public List<Buklet> FilterByPublisher(string publisherName)
        {
            List<Buklet> filteredPublisherList = new List<Buklet>();
            var bukletsList = db.Buklets;
            foreach (var bukletsItem in bukletsList)
            {
                if (bukletsItem.Publisher == publisherName)
                {
                    filteredPublisherList.Add(bukletsItem);
                }
            }
            return filteredPublisherList;
        }

        public List<string> GetAllPublishers()
        {
            List<string> publishersList = new List<string>();
            var bukletList = db.Buklets;
            foreach (var bukletsItem in bukletList)
            {
                publishersList.Add(bukletsItem.Publisher);
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

        //public List<Buklet> GetAll()
        //{
        //    List<Buklet> bukletsList;
        //    try
        //    {
        //        using (SqlConnection connection = new SqlConnection(_connectionString))
        //        {
        //            connection.Open();
        //            bukletsList = new List<Buklet>();
        //            if (connection != null)
        //            {
        //                string bukletsSelectAllExpression = "SELECT * FROM Buklets";
        //                SqlCommand command = new SqlCommand(bukletsSelectAllExpression, connection);
        //                SqlDataReader reader = command.ExecuteReader();
        //                if (reader.HasRows)
        //                {
        //                    while (reader.Read())
        //                    {
        //                        bukletsList.Add(new Buklet { Id = (int)reader.GetValue(0), Name = (string)reader.GetValue(1), Author = (string)reader.GetValue(2), Publisher = (string)reader.GetValue(3), Price = (int)reader.GetValue(4) });
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        throw new Exception("problem with sql: " + ex);
        //    }
        //    return bukletsList;
        //}

        //public Buklet GetItemById(int? id)
        //{
        //    Buklet buklet = new Buklet();
        //    try
        //    {
        //        using (SqlConnection connection = new SqlConnection(_connectionString))
        //        {
        //            connection.Open();
        //            if (connection != null)
        //            {
        //                string searchBukletByIdExpression = $"SELECT * FROM Buklets WHERE Id = '{id}'";
        //                SqlCommand command = new SqlCommand(searchBukletByIdExpression, connection);
        //                SqlDataReader reader = command.ExecuteReader();
        //                if (reader.HasRows)
        //                {
        //                    while (reader.Read())
        //                    {
        //                        buklet.Id = (int)reader.GetValue(0);
        //                        buklet.Name = (string)reader.GetValue(1);
        //                        buklet.Author = (string)reader.GetValue(2);
        //                        buklet.Publisher = (string)reader.GetValue(3);
        //                        buklet.Price = (int)reader.GetValue(4);
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        throw new Exception("problem with sql: " + ex);
        //    }
        //    return buklet;
        //}

        //public void Create(Buklet buklet)
        //{
        //    string createBukletExpression = $"INSERT INTO Buklets([Name], [Author], [Publisher],[Price]) VALUES('{buklet.Name}','{buklet.Author}','{buklet.Publisher}','{buklet.Price}')";
        //    try
        //    {
        //        using (SqlConnection connection = new SqlConnection(_connectionString))
        //        {
        //            connection.Open();
        //            SqlCommand command = new SqlCommand(createBukletExpression, connection);
        //            try
        //            {
        //                command.ExecuteNonQuery();
        //            }
        //            catch (Exception e)
        //            {
        //                throw new Exception(e.Message);
        //            }
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        throw new Exception("problem with sql: " + ex);
        //    }
        //}

        //public void Update(int? Id, Buklet buklet)
        //{
        //    try
        //    {
        //        using (SqlConnection connection = new SqlConnection(_connectionString))
        //        {
        //            connection.Open();
        //            if (connection != null)
        //            {
        //                string editBukletExpression = $"UPDATE Buklets SET Name = '{buklet.Name}', Author = '{buklet.Author}', Publisher = '{buklet.Publisher}', Price = '{buklet.Price}' WHERE Id = '{Id}'";
        //                SqlCommand command = new SqlCommand(editBukletExpression, connection);
        //                try
        //                {
        //                    command.ExecuteNonQuery();
        //                }
        //                catch (Exception e)
        //                {
        //                    throw new Exception(e.Message);
        //                }
        //            }
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        throw new Exception("problem with sql: " + ex);
        //    }
        //}

        //public void Delete(int? id)
        //{
        //    try
        //    {
        //        using (SqlConnection connection = new SqlConnection(_connectionString))
        //        {
        //            connection.Open();
        //            if (connection != null)
        //            {
        //                string deleteBukletExpression = $"DELETE FROM Buklets WHERE Id = '{id}'";
        //                SqlCommand command = new SqlCommand(deleteBukletExpression, connection);
        //                try
        //                {
        //                    command.ExecuteNonQuery();
        //                }
        //                catch (Exception e)
        //                {
        //                    throw new Exception(e.Message);
        //                }
        //            }
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        throw new Exception("problem with sql: " + ex);
        //    }
        //}

        //public List<Buklet> FilterByPublisher(string publisherName)
        //{
        //    List<Buklet> bukletsList;
        //    try
        //    {
        //        using (SqlConnection connection = new SqlConnection(_connectionString))
        //        {
        //            connection.Open();
        //            bukletsList = new List<Buklet>();
        //            if (connection != null)
        //            {
        //                string selectAllExpression = $"SELECT * FROM Buklets WHERE Publisher = '{publisherName}'";
        //                SqlCommand command = new SqlCommand(selectAllExpression, connection);
        //                SqlDataReader reader = command.ExecuteReader();
        //                if (reader.HasRows)
        //                {
        //                    while (reader.Read())
        //                    {
        //                        bukletsList.Add(new Buklet { Id = (int)reader.GetValue(0), Name = (string)reader.GetValue(1), Author = (string)reader.GetValue(2), Publisher = (string)reader.GetValue(3), Price = (int)reader.GetValue(4) });
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        throw new Exception("problem with sql: " + ex);
        //    }
        //    return bukletsList;
        //}

        //public List<string> GetAllPublishers()
        //{
        //    List<string> publishersList;
        //    try
        //    {
        //        using (SqlConnection connection = new SqlConnection(_connectionString))
        //        {
        //            connection.Open();
        //            publishersList = new List<string>();
        //            if (connection != null)
        //            {
        //                string selectAllExpression = $"SELECT DISTINCT Publisher FROM Buklets";
        //                SqlCommand command = new SqlCommand(selectAllExpression, connection);
        //                SqlDataReader reader = command.ExecuteReader();
        //                if (reader.HasRows)
        //                {
        //                    while (reader.Read())
        //                    {
        //                        publishersList.Add(reader.GetString(0));
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        throw new Exception("problem with sql: " + ex);
        //    }
        //    return publishersList;
        //}
    }
}