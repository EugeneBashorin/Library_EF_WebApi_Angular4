using DataAccessLayer.Context;
using DataAccessLayer.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;

namespace DataAccessLayer.Repositories
{
    public class MagazineRepository : IMagazineRepository
    {
        //string _connectionString;
        private PublicationContext db;

        public MagazineRepository(string connectionstring)
        {
            //    _connectionString = connectionString;
            this.db = new PublicationContext(connectionstring);
        }

        public List<Magazine> GetAll()
        {
            List<Magazine> magazinesList = new List<Magazine>();
            var magazines = db.Magazines;
            foreach (var magazinesItem in magazines)
            {
                magazinesList.Add(magazinesItem);
            }
            return magazinesList;
        }

        public Magazine GetItemById(int? id)
        {
            Magazine magazine = db.Magazines.Find(id);
            return magazine;
        }

        public void Create(Magazine magazine)
        {
            db.Magazines.Add(magazine);
            db.SaveChanges();
        }

        public void Update(int? Id, Magazine magazine)
        {
            Magazine newMagazine = db.Magazines.Find(Id);
            if (newMagazine != null)
            {
                newMagazine.Name = magazine.Name;
                newMagazine.Category = magazine.Category;
                newMagazine.Publisher = magazine.Publisher;
                newMagazine.Price = magazine.Price;
            }
            db.Entry(newMagazine).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int? id)
        {
            Magazine magazine = db.Magazines.Find(id);
            if (magazine != null)
            {
                db.Magazines.Remove(magazine);
                db.SaveChanges();
            }
        }

        public List<Magazine> FilterByPublisher(string publisherName)
        {
            List<Magazine> filteredPublisherList = new List<Magazine>();
            var magazinesList = db.Magazines;
            foreach (var magazinesItem in magazinesList)
            {
                if (magazinesItem.Publisher == publisherName)
                {
                    filteredPublisherList.Add(magazinesItem);
                }
            }
            return filteredPublisherList;
        }

        public List<string> GetAllPublishers()
        {
            List<string> publishersList = new List<string>();
            var magazineList = db.Magazines;
            foreach (var magazinesItem in magazineList)
            {
                publishersList.Add(magazinesItem.Publisher);
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

        //public List<Magazine> GetAll()
        //{
        //    List<Magazine> magazinesList;
        //    try
        //    {
        //        using (SqlConnection connection = new SqlConnection(_connectionString))
        //        {
        //            connection.Open();
        //            magazinesList = new List<Magazine>();
        //            if (connection != null)
        //            {
        //                string magazinesSelectAllExpression = "SELECT * FROM Magazines";
        //                SqlCommand command = new SqlCommand(magazinesSelectAllExpression, connection);
        //                SqlDataReader reader = command.ExecuteReader();
        //                if (reader.HasRows)
        //                {
        //                    while (reader.Read())
        //                    {
        //                        magazinesList.Add(new Magazine { Id = (int)reader.GetValue(0), Name = (string)reader.GetValue(1), Category = (string)reader.GetValue(2), Publisher = (string)reader.GetValue(3), Price = (int)reader.GetValue(4) });
        //                    }
        //                }
        //            }

        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        throw new Exception("problem with sql: " + ex);
        //    }
        //    return magazinesList;
        //}

        //public Magazine GetItemById(int? id)
        //{
        //    Magazine magazine = new Magazine();
        //    try
        //    {
        //        using (SqlConnection connection = new SqlConnection(_connectionString))
        //        {
        //            connection.Open();
        //            if (connection != null)
        //            {
        //                string searchMagazineByIdExpression = $"SELECT * FROM Magazines WHERE Id = '{id}'";
        //                SqlCommand command = new SqlCommand(searchMagazineByIdExpression, connection);
        //                SqlDataReader reader = command.ExecuteReader();
        //                if (reader.HasRows)
        //                {
        //                    while (reader.Read())
        //                    {
        //                        magazine.Id = (int)reader.GetValue(0);
        //                        magazine.Name = (string)reader.GetValue(1);
        //                        magazine.Category = (string)reader.GetValue(2);
        //                        magazine.Publisher = (string)reader.GetValue(3);
        //                        magazine.Price = (int)reader.GetValue(4);
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        throw new Exception("problem with sql: " + ex);
        //    }
        //    return magazine;
        //}

        //public void Create(Magazine magazine)
        //{
        //    string createMagazineExpression = $"INSERT INTO Magazines([Name], [Category], [Publisher],[Price]) VALUES('{magazine.Name}','{magazine.Category}','{magazine.Publisher}','{magazine.Price}')";
        //    try
        //    {
        //        using (SqlConnection connection = new SqlConnection(_connectionString))
        //        {
        //            connection.Open();
        //            SqlCommand command = new SqlCommand(createMagazineExpression, connection);
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

        //public void Update(int? Id, Magazine magazine)
        //{
        //    try
        //    {
        //        using (SqlConnection connection = new SqlConnection(_connectionString))
        //        {
        //            connection.Open();
        //            if (connection != null)
        //            {
        //                string editMagazineExpression = $"UPDATE Magazines SET Name = '{magazine.Name}', Category = '{magazine.Category}', Publisher = '{magazine.Publisher}', Price = '{magazine.Price}' WHERE Id = '{Id}'";
        //                SqlCommand command = new SqlCommand(editMagazineExpression, connection);
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
        //                string deleteMagazineExpression = $"DELETE FROM Magazines WHERE Id = '{id}'";
        //                SqlCommand command = new SqlCommand(deleteMagazineExpression, connection);
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

        //public List<Magazine> FilterByPublisher(string publisherName)
        //{
        //    List<Magazine> magazineList;
        //    try
        //    {
        //        using (SqlConnection connection = new SqlConnection(_connectionString))
        //        {
        //            connection.Open();
        //            magazineList = new List<Magazine>();
        //            if (connection != null)
        //            {
        //                string selectAllExpression = $"SELECT * FROM Magazines WHERE Publisher = '{publisherName}'";
        //                SqlCommand command = new SqlCommand(selectAllExpression, connection);
        //                SqlDataReader reader = command.ExecuteReader();
        //                if (reader.HasRows)
        //                {
        //                    while (reader.Read())
        //                    {
        //                        magazineList.Add(new Magazine { Id = (int)reader.GetValue(0), Name = (string)reader.GetValue(1), Category = (string)reader.GetValue(2), Publisher = (string)reader.GetValue(3), Price = (int)reader.GetValue(4) });
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        throw new Exception("problem with sql: " + ex);
        //    }
        //    return magazineList;
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
        //                string selectAllExpression = $"SELECT DISTINCT Publisher FROM Magazines";
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